using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SYNCWITHUSERDATA : MonoBehaviour
{
    [SerializeField] UserData userData;

    [SerializeField] TMP_Text studentNameText;
    [SerializeField] TMP_Text classYearText;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text schoolName;

    void Awake()
    {
        Debug.Log(userData.userName);
        studentNameText.text = userData.userName;
        classYearText.text = userData.classYear.ToString();
        score.text = userData.score.ToString();
        schoolName.text = userData.school;
    }
}
