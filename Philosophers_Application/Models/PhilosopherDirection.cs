using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Philosophers_Application.Models
{
    public class PhilosopherDirection
    {
        public int PhilosopherId { get; set; }
        [Required]
        public Philosopher Philosopher { get; set; }

        public int DirectionId { get; set; }
        [Required]
        public Direction Direction { get; set; }
    }
}