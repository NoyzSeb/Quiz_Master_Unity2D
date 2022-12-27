using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionsSO questions;
    [SerializeField] GameObject[] answersButtons;
    
    [SerializeField] Sprite defaultSprite;

    [SerializeField] Sprite correctAnswerSprite;
    int correctAnswerIndex;
    
    
    void Start()
    {
        DisplayQuestion();
       
    }
     
    public void OnAnswerSelected (int index) 
        {   
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
            SetButtonState(false);
        }

    
    void DisplayNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonColorSpirites();
        DisplayQuestion();
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
