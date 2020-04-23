using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DataModels
{
    public class ContactDataModel
    {
        public int Id { get; set; }

        public TypeContactEnum Type { get; set; }

        public string Value { get; set; }

        public int PersonId { get; set; }

    }
}
