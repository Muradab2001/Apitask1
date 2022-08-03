using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.DTOs.Processor
{
    public class ProcessorPostDto
    {
        public string Model { get; set; }
        public decimal GHz { get; set; }
        public byte Cores { get; set; }
    }
    public class PhonePostDtoValidation : AbstractValidator<ProcessorPostDto>
    {
        public PhonePostDtoValidation()
        {
            RuleFor(p => p.Model).NotNull().WithMessage("please enter value").MaximumLength(30).WithMessage("max length 30");
            RuleFor(p => p.GHz).NotNull().WithMessage("please enter value").GreaterThanOrEqualTo(10).WithMessage("minimum price 50").LessThanOrEqualTo(100.00m).WithMessage("max price 999999.99");
            RuleFor(p => p.Cores).NotNull().WithMessage("please enter value");
        }
    }
}
