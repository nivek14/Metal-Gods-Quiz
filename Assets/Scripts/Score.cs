using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour{

    [SerializeField] private TextMeshProUGUI poser;
    [SerializeField] private TextMeshProUGUI metalHead;
    [SerializeField] private TextMeshProUGUI truee;
    [SerializeField] private GameToUseData game;

    void Awake() {
        ShowScore();   
    }

    private void ShowScore(){
        poser.text      = game.games[1].GeneralScore.ToString();
        metalHead.text  = game.games[0].GeneralScore.ToString();
        truee.text      = game.games[2].GeneralScore.ToString();
    }

}
