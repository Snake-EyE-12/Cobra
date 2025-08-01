using UnityEngine;
using UnityEngine.InputSystem;

namespace Cobra.UnitTesting
{
    public class WCT_UniqueActionMaps : MonoBehaviour
    {
        public void DoSomething()
        {
            Debug.Log("Print");
        }
        
        public void OnFire()
        {
            Debug.Log("Firing");
        }

        public void OnDrop()
        {
            Debug.Log("Dropping");
        }
    }
}
