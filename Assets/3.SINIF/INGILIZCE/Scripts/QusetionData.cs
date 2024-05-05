using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New QuestionData", menuName = "QuestionData")]
public class QuestionData : ScriptableObject
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