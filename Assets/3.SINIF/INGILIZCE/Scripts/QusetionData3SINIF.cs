using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New QusetionData-3-SINIF", menuName = "QusetionData-3-SINIF")]
public class QusetionData3SINIF : ScriptableObject
{
    [System.Serializable]

    public struct Question
    {
        public string questionText;
        public string[] replies;
        public int correctReplyIndex;
    }

    public Question[] questions;
}