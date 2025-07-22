using NaughtyAttributes;
using UnityEngine;

public class WCT_AssetUser : MonoBehaviour
{
    [Button]
    public void Testing()
    {
        Sprite sp = WCT_AssetSingleton.Instance.sprite1;
        Debug.Log(WCT_AssetSingleton.Instance.theName);
    }
}
