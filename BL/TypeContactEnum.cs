using System.ComponentModel.DataAnnotations;

namespace BL
{
    public enum TypeContactEnum
    {
        [Display(Name = "Телефон")]
        Phone = 1,

        [Display(Name = "Email")]
        Email = 2,

        [Display(Name = "Skype")]
        Skype = 3,

        [Display(Name = "Другое")]
        Other = 4
    }
}
