using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Question", fileName ="New Question")]
public class QuestionsSO : ScriptableObject
{ 
    [TextArea(2,6)]
    [SerializeField]string question = "Enter your question here";
    
    [SerializeField] string[] answers = new string[4];

    [SerializeField] int correctAnswer ;
    
     
    public int CorrectAnswer()
    {
        return correctAnswer;
    }

    public string GetAnswer(int index)
    {
        return answers [index];
    }

    public string GetQuestion()
    {
      
      return question;
    }

      


}

public class Test
{
   QuestionsSO questionsSO;
   void TestA()
   {
     string questionText = questionsSO.GetQuestion();


   }
}