using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace PrisonServClient.Validation
{
    class StringLengthValidationRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public StringLengthValidationRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = (string)value;

            if (text.Length > Max || text.Length < Min)
            {
                return new ValidationResult(false, $"Max lenght: {Max}!");
            }
            return ValidationResult.ValidResult;
        }
    }
}
