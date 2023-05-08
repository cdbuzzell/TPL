using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Model
{
    public class RoundRsvp
    {
        [Key]
        public Guid RoundId { get; set; }

        public DateTime Date { get; set; }

        public Golfer Golfer { get; set; }

        public DateTime Responded { get; set; }

        public bool IsGolfing { get; set; }
    }
}
