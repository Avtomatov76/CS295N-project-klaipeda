using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlaipedaCity.Models
{
    public class QuizVM
    {
        // User's answers and whether right or wrong is chosen for the questions
        public String UserAnswer1 { get; set; }
        public String RightOrWrong1 { get; set; }

        public String UserAnswer2 { get; set; }
        public String RightOrWrong2 { get; set; }

        public String UserAnswer3 { get; set; }
        public String RightOrWrong3 { get; set; }

        // Checks each answer got right or wrong; returns "Right" or "Wrong"
        public void CheckAnswers()
        {
            RightOrWrong1 = UserAnswer1 == "" ? "Right" : "Wrong";
            RightOrWrong2 = UserAnswer2 == "" ? "Right" : "Wrong";
            RightOrWrong3 = UserAnswer3 == "" ? "Right" : "Wrong";
        }
    }
}
