using System.Collections.Generic;

namespace FlagQuizGame.Models
{
    public class Game
    {
        public List<Answer> Answers { get; set; }
        public int CorrectAnswers { get; set; }
        public int Points { get; set; }
    }
}