using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.DbObjects
{
    public class ContactInfo
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(1,4)]
        public int Type { get; set; }

        [Required]
        public string Value { get; set; }

        public int PersonId { get; set; }


        public virtual Person Person {get; set;}
    }
}
