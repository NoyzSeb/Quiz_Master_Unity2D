using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
     float QuestionComplete = 10f;
     float AfterShow = 5f;

    [SerializeField] Image timerImage;
    
    public float fillFraction;
    float timerValue;
    
    public bool nextQuestion ;

    
     
    public bool IsAnsweringQuestion; 
    void Start() {
        
    }

    public void CancelTimer(){
        timerValue =0;
    }
    void UpdateTimer() {
        
        timerValue -= Time.deltaTime;

        fillFraction =timerValue/QuestionComplete;
         
        if(timerValue>0){
           timerImage.fillAmount = fillFraction;
           
        }
                
        if(IsAnsweringQuestion){
            
            if (timerValue<=0){
                IsAnsweringQuestion = false;
                timerValue=AfterShow;
                
            }
                
        }else{
            if(timerValue<=0){
                IsAnsweringQuestion= true;
                timerValue= QuestionComplete;
                nextQuestion = true;

            }
              
        }          
        
    }
    

    void FixedUpdate()
    {   
        UpdateTimer();
        
        
       
    }
}
