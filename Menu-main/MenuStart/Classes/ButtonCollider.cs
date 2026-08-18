using UnityEngine;
using static Menu.Menu.Main;
using Menu.Settings;

namespace Menu.Classes
{
    public class Button : MonoBehaviour
    {
        public string relatedText;

        public static float buttonCooldown = 0f;

        public void OnTriggerEnter(Collider collider)
        {
            if (Time.time > buttonCooldown && collider == buttonCollider && menu != null)
            {
                buttonCooldown = Time.time + 0.2f;
                GorillaTagger.Instance.StartVibration(MenuSettings.rightHanded, GorillaTagger.Instance.tagHapticStrength / 2f, GorillaTagger.Instance.tagHapticDuration / 2f);
                VRRig.LocalRig.PlayHandTapLocal(8, MenuSettings.rightHanded, 0.4f);
                Toggle(this.relatedText);
            }
        }
    }
}
