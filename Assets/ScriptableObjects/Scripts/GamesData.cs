using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GamesData : ScriptableObject{

    public List<QuestionsData> quiz = new List<QuestionsData>();
    public int GeneralScore;

}