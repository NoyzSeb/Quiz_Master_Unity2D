using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{   [Header("Question")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionsSO questions;

    [Header("Answers")]
    [SerializeField] GameObject[] answersButtons;
    [SerializeField] Sprite correctAnswerSprite;
    int correctAnswerIndex;
    bool hasAnsweredQuestion;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    
    [Header("Sprites")]
    [SerializeField] Sprite defaultSprite;
    
    void Start()
    {   
        timer = FindObjectOfType<Timer>();
        DisplayQuestion();
       
    }

    void FixedUpdate(){
        
        if(timer.nextQuestion){
            hasAnsweredQuestion =false;
            DisplayNextQuestion();
            timer.nextQuestion=false;
        }else if(!hasAnsweredQuestion && !timer.IsAnsweringQuestion){
           //On Answer Did not selected in time.
           DisplayAnswer(-1);
           SetButtonState(false);

        }
        
    }
     
    
    public void OnAnswerSelected (int index) 
        {   hasAnsweredQuestion = true;            
            DisplayAnswer(index);
            SetButtonState(false);
            timer.CancelTimer();
        }

    
    void DisplayNextQuestion()
    {
        DisplayQuestion();
        SetButtonState(true);
        SetDefaultButtonColorSpirites();
    }
    

    void DisplayAnswer(int index){
        Image buttonImage;
        
           if(index == correctAnswerIndex)
            {  
               questionText.text = "Correct Answer";
               buttonImage = answersButtons[index].GetComponent<Image>();
               //buttonImage.sprite = correctAnswerSprite; 
               //I decided go with color according to the correctness of the answer.
               buttonImage.color = (new Vector4(0,255,0,255));
            }else
            {
                buttonImage = answersButtons[index].GetComponent<Image>();
                questionText.text = ("Correct Answer is : " + questions.GetAnswer(correctAnswerIndex));
                buttonImage.color = (new Vector4(255,0,0,255));
            }
         
    }
    void SetDefaultButtonColorSpirites()
    {
       for(int i = 0; i<answersButtons.Length; i++)
      {
        Image buttonImage = answersButtons[i].GetComponent<Image>();
        buttonImage.color = (new Vector4(255,255,255,255));
      }
    }
   void DisplayQuestion()
   {
        
        questionText.text = questions.GetQuestion();
        
        for (int i = 0; i<answersButtons.Length; i++)
        {
            correctAnswerIndex = questions.CorrectAnswer();
            TextMeshProUGUI buttonText = answersButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = questions.GetAnswer(i);
      
        }
        timer.nextQuestion= false;
        
   }

   void SetButtonState (bool state)
   {  
       
      for(int i = 0; i<answersButtons.Length; i++)
      {
        Button button = answersButtons[i].GetComponent<Button>();
        button.interactable = state;
      }
   }

}
