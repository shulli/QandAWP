using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Data.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerPhrase { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
