using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCompetition.Models
{
    public class QuizQuestion : BaseModel
    {
        [Required]
        public string AcademicYear { get; set; }

        [Required]
        public string Question { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Option3 { get; set; }

        public string Option4 { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }

        [Required]
        public int LevelId { get; set; }

        [Required]
        public string QuestionType { get; set; }

        [Required]
        public int RoundId { get; set; }

        [Required]
        public bool IsMCQ { get; set; }

        [Required]
        public decimal Time { get; set; }

        public string DocUrl { get; set; }

        [NotMapped]
        public string Level { get; set; }

        [NotMapped]
        public string Round { get; set; }

    }
}
