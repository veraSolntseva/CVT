using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DbObjects
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        public string MiddleName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Organization { get; set; }

        public string Position { get; set; }


        public virtual ICollection<ContactInfo> Contacts { get; set; }
    }
}
