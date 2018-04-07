using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlagQuizGame.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public List<Flag> Options { get; set; }
        public int CorrectAnswerId { get; set; }
        public int Value { get; set; }
    }
}