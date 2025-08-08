using UnityEngine;

namespace Cobra.UnitTesting
{
    public class WCT_RemapHappening : MonoBehaviour
    {
        public void OnDrop()
        {
            Debug.Log("Drop");
        }

        public void OnInventory()
        {
            Debug.Log("Inven");
        }

        public void OnReset()
        {
            Debug.Log("Reset");
        }
    }
}