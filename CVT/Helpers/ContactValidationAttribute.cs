using BL;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CVT.Helpers
{
    /// <summary>
    /// Валидация контактной информации в зависимости от типа
    /// </summary>
    public class ContactValidationAttribute : CompareAttribute
    {
        public ContactValidationAttribute(string typeProperty) : base(typeProperty)
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var type = validationContext.ObjectInstance.GetType();

            var prop = type.GetProperty(this.OtherProperty);

            var propValue = (TypeContactEnum)prop?.GetValue(validationContext.ObjectInstance);

            bool result = value != null;

            switch (propValue)
            {
                case TypeContactEnum.Phone:
                    if(!result)
                        this.ErrorMessage = "Введите номер телефона.";
                    else
                    {
                        string strRegex = @"^((\+7\()+([0-9]{3})+(\))+([0-9]{3})+(-)+([0-9]{2})+(-)+([0-9]{2}))$";

                        Regex re = new Regex(strRegex);

                        result = re.IsMatch(value?.ToString());

                        if (!result)
                            this.ErrorMessage = "Некорректный формат номера телефона.";
                    }

                    break;
                case TypeContactEnum.Email:
                    if (!result)
                        this.ErrorMessage = "Введите Email.";
                    else
                    {
                        string strRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

                        Regex re = new Regex(strRegex);

                        result = re.IsMatch(value?.ToString());

                        if (!result)
                            this.ErrorMessage = "Некорректный формат электронной почты.";
                    }

                    break;
                case TypeContactEnum.Skype:
                    if (!result)
                        this.ErrorMessage = "Введите Skype.";
                    break;
                case TypeContactEnum.Other:
                    if (!result)
                        this.ErrorMessage = "Введите информацию в модуле \"Другое\"";
                    break;
            }

            return result ? ValidationResult.Success : new ValidationResult(this.ErrorMessage);
        }
    }
}
