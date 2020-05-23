using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Philosophers_Application.Models
{
    [Table("philosophers_tbl")]
    public class Philosopher
    {
        [Required, Key, DataMember(Name = "Key")]
        public int Id { get; set; }
        
        [Required]
        public string PhilosopherName { get; set; }
        
        public int CountryId { get; set; }
        [Required]
        public Country Country { get; set; }

        public List<PhilosopherDirection> PhilosopherDirection { get; set; }

        public Philosopher()
        {
            this.PhilosopherDirection = new List<PhilosopherDirection>();
        }
    }
}
