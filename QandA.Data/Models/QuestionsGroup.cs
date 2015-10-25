using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Data.Models
{
    public class QuestionsGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public List<Question> Questions { get; set; }
    }
}
