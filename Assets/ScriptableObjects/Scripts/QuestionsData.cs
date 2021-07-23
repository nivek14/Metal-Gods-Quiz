using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestionsData : ScriptableObject{

    [TextArea(5,5)] public string question;
    [Range(1,3)] public int correctAnswer;
    public List<string> answers = new List<string>();
 
  
}
