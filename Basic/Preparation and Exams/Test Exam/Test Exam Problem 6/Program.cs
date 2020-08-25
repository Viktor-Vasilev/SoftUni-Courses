using System;

namespace Test_Exam_Problem_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());  

            int lastNum = 0; 
            
            int middleNum = 0;
            
            int firstNum = 0;

             // Поради особености на вашата програма вземаме цифрите на въведеното число в обратен ред.
            // Максималната стойност на множителите е
            // определена от всяка една от 3 - те цифри на въведеното число.

            lastNum = number % 10;
           
            middleNum = (number / 10) % 10;
            
            firstNum = number / 100;
            
            for (int edinici = 1; edinici <= lastNum; edinici++)         
            {
                for (int desetki = 1; desetki <= middleNum; desetki++)   
                {
                    for (int stotici = 1; stotici <= firstNum; stotici++) 
                    {
                        Console.WriteLine($"{edinici} * {desetki} * {stotici} = {edinici * desetki * stotici};");                       
                    }
                }
            }
        }
    }
}
