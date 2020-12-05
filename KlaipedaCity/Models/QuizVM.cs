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
        public void CheckAnswers() 
        {
            string [] answers = { "Baltic sea", "Lithuanian", "True", "Memel", "True", "Dane", "Amber", "98", "Jazz Festival", "Cepelinai" };
            string response = " - Correct answer is: ";       

            RightOrWrong1 = UserAnswer1?.ToLower() == "baltic sea" ? "Right" : "Wrong" + response + answers[0];
            RightOrWrong2 = UserAnswer2?.ToLower() == "lithuanian" ? "Right" : "Wrong" + response + answers[1];
            RightOrWrong3 = UserAnswer3 == "true" ? "Right" : "Wrong" + response + answers[2];
            RightOrWrong4 = UserAnswer4 == "true" ? "Right" : "Wrong" + response + answers[3];
            RightOrWrong5 = UserAnswer5 == "true" ? "Right" : "Wrong" + response + answers[4];
            RightOrWrong6 = UserAnswer6?.ToLower() == "dane" ? "Right" : "Wrong" + response + answers[5];
            RightOrWrong7 = UserAnswer7?.ToLower() == "amber" ? "Right" : "Wrong" + response + answers[6];
            RightOrWrong8 = UserAnswer8 == "98" ? "Right" : "Wrong" + response + answers[7];
            RightOrWrong9 = UserAnswer9?.ToLower() == "jazz festival" ? "Right" : "Wrong" + response + answers[8];
            RightOrWrong10 = UserAnswer10?.ToLower() == "cepelinai" ? "Right" : "Wrong" + response + answers[9];
        }
    }
}
