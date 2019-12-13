using System;
using System.ComponentModel.DataAnnotations;

namespace balmoozdaq.Attributes
{
    public class PhoneNumberAttribute: ValidationAttribute
    {
        private string val;

        public PhoneNumberAttribute(string val, string error)
        {
            this.val = val;
            ErrorMessage = error;
        }

        protected override ValidationResult IsValid(object val, ValidationContext validationContext)
        {
            {
                string NUMBER = val.ToString();

                if (NUMBER.Length < 11)
                {
                    return new ValidationResult(ErrorMessage);
                }
                return ValidationResult.Success;
            }
        }
    }
}
