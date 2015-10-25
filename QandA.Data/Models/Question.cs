using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Data.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionPhrase { get; set; }
        public List<Answer> Answers { get; set; }

        public List<Answer> CorrectAnswers
        {
            get { return Answers.Where(x => x.IsCorrectAnswer == true).ToList(); }
        }

        public bool IsKeyQuestion { get; set; }
        
    }
}
