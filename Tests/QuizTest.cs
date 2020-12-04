using System;
using Xunit;
using KlaipedaCity.Models;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void RightAnswerTest()
        {
            // Arrange
            var quiz = new QuizVM()
            {
                UserAnswer1 = "baltic sea",
                UserAnswer2 = "lithuanian",
                UserAnswer3 = "true",
                UserAnswer4 = "true",
                UserAnswer5 = "true"
            };

            // Act
            quiz.CheckAnswers();

            // Assert
            Assert.True("Right" == quiz.RightOrWrong1 &&
                "Right" == quiz.RightOrWrong2 && "Right" == quiz.RightOrWrong3
                && "Right" == quiz.RightOrWrong4 && "Right" == quiz.RightOrWrong5);
        }

        [Fact]
        public void WrongAnswerTest()
        {
            // Arrange
            var quiz = new QuizVM()
            {
                UserAnswer1 = "black sea",
                UserAnswer2 = "russian",
                UserAnswer3 = "false",
                UserAnswer4 = "false",
                UserAnswer5 = "false"
            };

            // Act
            quiz.CheckAnswers();

            // Assert
            Assert.True("Wrong - Correct answer is: Baltic sea" == quiz.RightOrWrong1 &&
                "Wrong - Correct answer is: Lithuanian" == quiz.RightOrWrong2 
                && "Wrong - Correct answer is: True" == quiz.RightOrWrong3
                && "Wrong - Correct answer is: Memel" == quiz.RightOrWrong4 
                && "Wrong - Correct answer is: True" == quiz.RightOrWrong5);
        }
    }
}
