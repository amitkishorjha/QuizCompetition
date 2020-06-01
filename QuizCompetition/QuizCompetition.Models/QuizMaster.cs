using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCompetition.Models
{
    public class QuizMaster : BaseModel
    {
        [Required]
        public string Title { get; set; }

        public string Decription { get; set; }

        public decimal MarksPerQuestion { get; set; }

        [Required]
        [Display(Name = "Level")]
        public int LevelId { get; set; }

        [Required]
        [Display(Name = "Round")]
        public int RoundId { get; set; }

        [Required]
        public bool IsMCQ { get; set; }

        [Required]
        [Display(Name = "Time/Question")]
        public decimal TimePerQuestion { get; set; }

    }
}
