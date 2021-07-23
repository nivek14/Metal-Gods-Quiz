using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameToUseData : ScriptableObject{
    [Range(0,2)] public int gameToUse;
    public List<GamesData> games = new List<GamesData>();
}
