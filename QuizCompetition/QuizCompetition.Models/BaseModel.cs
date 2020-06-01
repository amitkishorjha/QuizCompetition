using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCompetition.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            IsActive = true;
            CreatedDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; }

        [StringLength(30)]
        public string CreatedBy { get; set; }

        [StringLength(30)]
        public string UpdatedBy { get; set; }

        [StringLength(30)]
        public string DeletedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedDate { get; set; }

    }
}
