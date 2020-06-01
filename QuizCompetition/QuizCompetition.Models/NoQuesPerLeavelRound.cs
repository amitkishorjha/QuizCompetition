using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCompetition.Models
{
    public class NoQuesPerLeavelRound : BaseModel
    {
        public int LevelId { get; set; }

        public int RoundId { get; set; }

        public int NoOfQuestion { get; set; }
    }
}
