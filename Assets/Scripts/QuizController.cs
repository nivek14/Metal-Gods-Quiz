using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class QuizController : MonoBehaviour{

    [SerializeField] private GameToUseData quizToPlay;
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private GameScoreData score;
    [SerializeField] private List<TextMeshProUGUI> answers = new List<TextMeshProUGUI>();
    [SerializeField] private TextMeshProUGUI currentQuestionText;
    [SerializeField] private TextMeshProUGUI totalQuestionsText;
    [SerializeField] private Button continueButton;
    [SerializeField] private List<Button> answersButtons = new List<Button>();
    
    private int currentQuestionAux;
    private bool isFinished = false, isCorrect = false;
    public int questionToUse = 0, points = 0;
    
    void Awake(){
        score.totalQuestions = quizToPlay.games[quizToPlay.gameToUse].quiz[questionToUse].answers.Count;
        continueButton.gameObject.SetActive(false);
        CurrentQuestion();
    }

    void Update(){
        SetCurrentQuestionText();
        ScoreScene();
    }

    public void CurrentQuestion(){

        if(!isFinished){

            question.text = quizToPlay.games[quizToPlay.gameToUse].quiz[questionToUse].question;

            for(int i=0; i <  quizToPlay.games[quizToPlay.gameToUse].quiz[questionToUse].answers.Count; i++){
                answers[i].text =  quizToPlay.games[quizToPlay.gameToUse].quiz[questionToUse].answers[i];
            }

        }

        foreach(Button b in answersButtons){
            ColorBlock cb = b.colors;
            cb.normalColor = Color.white;
            b.colors = cb;
        }

    }

    public void UpdateQuestion(){
        if(!isFinished){
            questionToUse++;
            CurrentQuestion();
        }

        continueButton.gameObject.SetActive(false);
    }

    public void ActiveContinue(){
        continueButton.gameObject.SetActive(true);
    }

    public void VerifyEndGame(){
        if(questionToUse < quizToPlay.games[quizToPlay.gameToUse].quiz.Count - 1) UpdateQuestion();
        else{
            isFinished = true;
            DisableButtons();
        }
    }

    private void SetCurrentQuestionText(){
        currentQuestionAux = questionToUse + 1;
        currentQuestionText.text = currentQuestionAux.ToString();
        totalQuestionsText.text = quizToPlay.games[quizToPlay.gameToUse].quiz.Count.ToString();
    }

    private void ScoreScene(){
        if(isFinished) Invoke("NextScene", 2f);
    }

    private void NextScene(){
        SceneManager.LoadScene("Result");
    }

    public void CheckAnswer(int value){

        if(value == quizToPlay.games[quizToPlay.gameToUse].quiz[questionToUse].correctAnswer){
            points++;
            score.gameScore = points;
            isCorrect = true;
        }
        else isCorrect = false;

    }

    public void ChangeButtonColor(Button button){
        
        ColorBlock cb = button.colors;

        if(isCorrect){
            cb.selectedColor = Color.green;
            button.colors = cb;
        }

        else{
            cb.selectedColor = Color.red;
            button.colors = cb;
            FindCorrectAnswer();
        }

    }

    private void FindCorrectAnswer(){
        foreach(Button b in answersButtons){
            if(b.GetComponent<AnswerButton>().buttonID.ID == quizToPlay.games[quizToPlay.gameToUse].quiz[questionToUse].correctAnswer){
                ColorBlock cb = b.colors;
                cb.normalColor = Color.green;
                b.colors = cb;
            } 
        }
    }

    private void DisableButtons(){
        foreach(Button b in answersButtons) b.interactable = false;
    }

}
