using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoWebAPI.Model
{
    public class BookValidation : AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty().NotNull().Must(ValidateInputString);
            RuleFor(x => x.Author).NotEmpty().NotNull().Must(ValidateInputString);
            RuleFor(x => x.Category).NotEmpty().NotNull().Must(ValidateInputString);
            RuleFor(x => x.Price).NotNull().GreaterThanOrEqualTo(0);

        }
        private bool ValidateInputString(string input)
        {
            input = Format(input);
            string pattern = "^[a-zA-Z ]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
        private string Format(string input)
        {
            input = input.Replace("\t", " ");
            while (input.IndexOf("  ") >= 0)
            {
                input = input.Replace("  ", " ");
            }
            return input;
        }
    }
}
