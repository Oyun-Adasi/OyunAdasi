using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "ScriptableObjects/UserData", order = 1)]
public class UserData : ScriptableObject
{
    public int classYear;
    public string userName;
    public string surname;
    public string role;
    public string school;
    public int score;
}
