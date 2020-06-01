using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCompetition.Models
{
    public class AttamtedQuestions : BaseModel
    {
        public int QuestionId { get; set; }

        public string TeamName { get; set; }

        public int TeamId { get; set; }

        public int LevelId { get; set; }

        public int RoundId  { get; set; }

        public decimal Marks { get; set; }

        public string AcademicYear { get; set; }

        public bool IsTrue { get; set; }

        public bool IsSkip { get; set; }

    }
}
