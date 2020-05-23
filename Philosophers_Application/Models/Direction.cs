using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Philosophers_Application.Models
{
    [Table("directions_tbl")]
    public class Direction
    {
        [Required, Key, DataMember(Name = "Key")]
        public int Id { get; set; }

        [Required]
        public string DirectionName { get; set; }

        public List<PhilosopherDirection> PhilosopherDirection { get; set; }

        public Direction()
        {
            this.PhilosopherDirection = new List<PhilosopherDirection>();
        }
    }
}
