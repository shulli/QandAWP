using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Data.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public List<QuestionsGroup> QuestionsGroups { get; set; }
    }
}
