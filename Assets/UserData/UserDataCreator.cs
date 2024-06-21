using UnityEngine;
using UnityEditor;

public class UserDataCreator : MonoBehaviour
{
    [MenuItem("Assets/Create/UserData")]
    public static void CreateUserData()
    {
        UserData asset = ScriptableObject.CreateInstance<UserData>();

        AssetDatabase.CreateAsset(asset, "Assets/UserData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
