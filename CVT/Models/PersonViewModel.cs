using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CVT.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        public string FullName => Surname + " " + Name + (string.IsNullOrEmpty(MiddleName) ? string.Empty : " " + MiddleName);

        [Display(Name = "Дата рождения")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Организация")]
        public string Organization { get; set; }

        [Display(Name = "Должность")]
        public string Position { get; set; }

        public List<ContactViewModel> Contacts { get; set; } = new List<ContactViewModel>();

        public string BirthDateString => BirthDate.HasValue ? BirthDate.Value.ToString("dd.MM.yyyy") : string.Empty;
    }
}
