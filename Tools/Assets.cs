using UnityEngine;
using Cobra.DesignPattern;

/*
 * Global Asset references
 * Edit Asset references in the prefab Resources/[ResourcesAsset]
 */
public class Assets : Singleton<Assets>
{
	[Tooltip("Name of prefab asset created in a Resources folder to load")]
	public static string ResourcesAsset = "AssetRefs";

	// Hides Instance property in Singleton to:
	// add functionality for creating the instance when it does not exist in the scene
	public static new Assets Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindFirstObjectByType<Assets>();

				if (instance == null)
				{
					Debug.LogError("Assets Singleton: Instance not found in scene! \n Trying to load resource.");
				}

				instance = Instantiate(Resources.Load<Assets>(ResourcesAsset));

				if (instance == null)
				{
					Debug.LogError("Assets Singleton: Unable to load resource [" + ResourcesAsset + "]! Instance inaccessable! \n Make sure asset is within a 'Resources' folder");
				}
			}
			return instance;
		}
	}

	[Header("Assets")]
	public Transform exampleReference;
}
