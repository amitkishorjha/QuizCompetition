using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCompetition.Models
{
    public class QuizTeam : BaseModel
    {
        public string Name { get; set; }


        public string Schoolname { get; set; }

        public decimal Marks { get; set; }
    }
}
