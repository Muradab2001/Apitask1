using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.DTOs
{
    public class PhonePostDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public bool Display { get; set; }
    }
    public class PhonePostDtoValidation : AbstractValidator<PhonePostDto>
    {
        public PhonePostDtoValidation()
        {
            RuleFor(p => p.Brand).NotNull().WithMessage("please enter value").MaximumLength(30).WithMessage("max length 30");
            RuleFor(p => p.Model).NotNull().WithMessage("please enter value").MaximumLength(30).WithMessage("max length 30");
            RuleFor(p => p.Color).NotNull().WithMessage("please enter value").MaximumLength(20).WithMessage("max length 30");
            RuleFor(p => p.Price).NotNull().WithMessage("please enter value").GreaterThanOrEqualTo(50).WithMessage("minimum price 50").LessThanOrEqualTo(999999.99m).WithMessage("max price 999999.99");


        }
    }
}
