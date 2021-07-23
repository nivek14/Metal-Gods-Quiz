using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Result : MonoBehaviour{

    [SerializeField] private GameToUseData quizToPlay;
    [SerializeField] private GameScoreData score;
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Awake(){
        MessageToShow();
        PlayerGameScore();
        UpdateGameScore();
    }

    private void MessageToShow(){

        if(score.gameScore < (score.totalQuestions/3)) message.text = "You have a lot to learn about the teachings of metal, poser!";

        else if((score.gameScore > (score.totalQuestions/3)) && 
                (score.gameScore < (score.totalQuestions + 1))) message.text = "Not bad, you still need to learn more about the metal gods, now look bad, put on your leather jacket and pick up your guitar for us to continue.";

        else message.text = "You're a born headbanger, your ears are already calloused from so much weight, put your hands up and make the sign for the metal gods to bless you!";
    }

    private void PlayerGameScore(){
        scoreText.text = score.gameScore.ToString();
    }

    private void UpdateGameScore(){
        if(score.gameScore > quizToPlay.games[quizToPlay.gameToUse].GeneralScore) quizToPlay.games[quizToPlay.gameToUse].GeneralScore = score.gameScore;
    }
     
}
