using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Philosophers_Application.Models
{
    [Table("countries_tbl")]
    public class Country
    {
        [Required, Key, DataMember(Name = "Key")]
        public int Id { get; set; }

        public string CountryName { get; set; }
    }
}
