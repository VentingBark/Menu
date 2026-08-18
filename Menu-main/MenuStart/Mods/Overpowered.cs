using static Menu.Menu.Main;
using UnityEngine;
using UnityEngine.XR;
using GorillaGameModes;
using static Menu.Classes.RigManager;    
using Menu.Notifications;
using System;





namespace Menu.Mods
{
    internal class Overpowered
    {
        public static void InstantTagGun()
        {
        }
        public static void TagGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Other.GunLibfix();
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;
                NewPointer.name = "GunPointer"; // if you change the name of the pointer make sure change it in the gunlib fix as well

                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f)
                {
                    var VrRigGunTarget = GetClosestVRRig();
                    if (VrRigGunTarget != null)
                    {

                        GameMode.ReportTag(GetPlayerFromVRRig(VrRigGunTarget));
                    }
                }
            }
        }
        public static void InstantTagPlayer(NetPlayer Target)
        {
            if (!ControllerInputPoller.instance.rightGrab)
                return;

            var GunData = RenderGun();
            GameObject NewPointer = GunData.NewPointer;
            NewPointer.name = "GunPointer"; // if you change the name of the pointer make sure change it in the gunlib fix as well

            GameMode.ReportTag(Target);

            Safety.Flushrpc();
        }
        private static GameObject NameTagObject;
        private static TextMesh NameTagText;
        private static bool previousTeleportTrigger;

        private static void EnsureNameTag()
        {
            if (NameTagObject != null)
                return;

            NameTagObject = new GameObject("GunPointerNameTag");
            NameTagText = NameTagObject.AddComponent<TextMesh>();
            NameTagText.characterSize = 0.1f;
            NameTagText.fontSize = 48;
            NameTagText.anchor = TextAnchor.LowerCenter;
            NameTagText.alignment = TextAlignment.Center;
            NameTagText.color = Color.white;

            // Make sure it renders on top and always faces the camera-ish
            var renderer = NameTagObject.GetComponent<Renderer>();
            renderer.material.shader = Shader.Find("GUI/Text Shader");

            NameTagObject.SetActive(false);
        }

        public static void FireGunAtPlayer()
        {
            if (!ControllerInputPoller.instance.rightGrab)
                return;

            var GunData = RenderGun();
            GameObject NewPointer = GunData.NewPointer;
            NewPointer.name = "GunPointer"; // if you change the name of the pointer make sure change it in the gunlib fix as well

            EnsureNameTag();

            VRRig hitPlayer = RaycastForPlayer();
            string playerName = TryGetPlayerName(hitPlayer);

            if (hitPlayer != null && playerName != null)
            {
                NameTagObject.SetActive(true);
                NameTagText.text = playerName;
                NameTagObject.transform.position = NewPointer.transform.position + Vector3.up * 0.3f;

                if (GorillaTagger.Instance != null && GorillaTagger.Instance.headCollider != null)
                {
                    Vector3 lookDir = NameTagObject.transform.position - GorillaTagger.Instance.headCollider.transform.position;
                    if (lookDir.sqrMagnitude > 0.0001f)
                        NameTagObject.transform.rotation = Quaternion.LookRotation(lookDir);
                }
            }
            else
            {
                NameTagObject.SetActive(false);
            }

            if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f && !previousTeleportTrigger)
            {
                if (playerName != null)
                {
                    NotifiLib.SendNotification($"<color=grey>[</color><color=purple>GUN</color><color=grey>]</color> You fired at <color=purple>{playerName}</color>.");
                }
                else
                {
                    NotifiLib.SendNotification("<color=grey>[</color><color=purple>GUN</color><color=grey>]</color> You fired at nothing.");
                }

                if (GorillaTagger.Instance != null && GorillaTagger.Instance.rigidbody != null)
                    GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
            }

            previousTeleportTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f;
        }

        private static VRRig RaycastForPlayer()
        {
            Transform GunTransform = GorillaTagger.Instance.rightHandTransform;
            Vector3 StartPosition = GunTransform.position;
            Vector3 Direction = GunTransform.forward;

            // ~0 = hit every layer; swap for a specific player layer mask if you have one.
            // QueryTriggerInteraction.Collide forces trigger colliders (common for player rigs) to register hits.
            if (Physics.Raycast(StartPosition + Direction / 4f, Direction, out RaycastHit hit, 512f, ~0, QueryTriggerInteraction.Collide))
            {
                return hit.collider.GetComponentInParent<VRRig>();
            }

            return null;
        }

        public static string TryGetPlayerName(VRRig rig)
        {
            if (rig == null)
                return null;

            try
            {
                var player = GetPlayerFromVRRig(rig);
                if (player == null)
                    return null;
                // PhotonNicknameGetter is not available in this project; fall back to common
                // nickname properties via reflection so this still works with custom player types.
                return player.NickName;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
