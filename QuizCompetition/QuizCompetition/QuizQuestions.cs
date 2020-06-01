using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCompetition
{
    public class QuizQuestions
    {
        public int Id { get; set; }
        public string AcademicYear { get; set; }

        public string QuestionText { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Option3 { get; set; }

        public string Option4 { get; set; }

        public string CorrectAnswer { get; set; }

        public string QuestionType { get; set; }

        public bool IsMCQ { get; set; }

        public string Time { get; set; }

        public string DocUrl { get; set; }

        public string Level { get; set; }

        public string Round { get; set; }
    }
}
