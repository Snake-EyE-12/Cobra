using TMPro;
using UnityEngine;

namespace Cobra.GUI
{
    public class WCT_KeyRebindListener : MonoBehaviour
    {
        [SerializeField] private TMP_Text bindingDisplayText;
        public void BindingDisplayChange(KeyRebindController rebind, string displayString, string deviceLayoutName, string controlPath)
        {
            if(rebind.IsDuplicate) bindingDisplayText.color = Color.red;
            else bindingDisplayText.color = Color.black;
            bindingDisplayText.text = displayString;
        }
    }
}
