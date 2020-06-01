using System.ComponentModel.DataAnnotations;

namespace QuizCompetition.Models
{
    public class QuizRound :BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public int NoOfQuestions { get; set; }
    }
}
