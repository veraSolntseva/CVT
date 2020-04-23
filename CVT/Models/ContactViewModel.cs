using BL;
using CVT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CVT.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [Range(1, 4, ErrorMessage ="Тип контактной информации не определен.")]
        [Required(ErrorMessage =" Тип контактной информации неизвестен.")]
        public TypeContactEnum Type { get; set; }

        [ContactValidation(nameof(Type))]
        public string Value { get; set; }

        public int PersonId { get; set; }
    }
}
