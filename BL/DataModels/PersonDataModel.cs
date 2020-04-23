using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DataModels
{
    public class PersonDataModel
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Organization { get; set; }

        public string Position { get; set; }

        public List<ContactDataModel> Contacts { get; set; } = new List<ContactDataModel>();

    }
}
