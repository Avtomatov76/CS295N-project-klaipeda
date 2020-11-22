using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlaipedaCity.Models
{
    public class QuizVM
    {
        // User's answers and whether right or wrong is chosen for each question
        public String UserAnswer1 { get; set; }
        public String RightOrWrong1 { get; set; }

        public String UserAnswer2 { get; set; }
        public String RightOrWrong2 { get; set; }

        public String UserAnswer3 { get; set; }
        public String RightOrWrong3 { get; set; }

        public String UserAnswer4 { get; set; }
        public String RightOrWrong4 { get; set; }

        public String UserAnswer5 { get; set; }
        public String RightOrWrong5 { get; set; }

        public String UserAnswer6 { get; set; }
        public String RightOrWrong6 { get; set; }

        public String UserAnswer7 { get; set; }
        public String RightOrWrong7 { get; set; }

        public String UserAnswer8 { get; set; }
        public String RightOrWrong8 { get; set; }

        public String UserAnswer9 { get; set; }
        public String RightOrWrong9 { get; set; }

        public String UserAnswer10 { get; set; }
        public String RightOrWrong10 { get; set; }

        // Checks each answer got right or wrong; returns "Right" or "Wrong"
        public void CheckAnswers() // NEEDS WORK
        {
            RightOrWrong1 = UserAnswer1 == "Baltic" ? "Right" : "Wrong";
            RightOrWrong2 = UserAnswer2 == "Lithuanian" ? "Right" : "Wrong";
            RightOrWrong3 = UserAnswer3 == "true" ? "Right" : "Wrong";
            RightOrWrong4 = UserAnswer4 == "Baltic" ? "Right" : "Wrong";
            RightOrWrong5 = UserAnswer5 == "Baltic" ? "Right" : "Wrong";
            RightOrWrong6 = UserAnswer6 == "Baltic" ? "Right" : "Wrong";
            RightOrWrong7 = UserAnswer7 == "Baltic" ? "Right" : "Wrong";
            RightOrWrong8 = UserAnswer8 == "Baltic" ? "Right" : "Wrong";
            RightOrWrong9 = UserAnswer9 == "Baltic" ? "Right" : "Wrong";
            RightOrWrong10 = UserAnswer10 == "Baltic" ? "Right" : "Wrong";
        }
    }
}
