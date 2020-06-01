using System.ComponentModel.DataAnnotations;

namespace QuizCompetition.Models
{
    public class QuizLevel : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
