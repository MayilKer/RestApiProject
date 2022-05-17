using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Learning.DTOs.ProductDtos
{
    public class ProductPutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
    }

    public class ProductPutDtoValidator : AbstractValidator<ProductPutDto>
    {
        public ProductPutDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id ni duzgun daxil et");
            RuleFor(x => x.Name)
                .MaximumLength(40).WithMessage("Maximum 40 imvol oal biler")
                .MinimumLength(3).WithMessage("Minimum 3 simvol ola biler")
                .NotEmpty().WithMessage("Bos ola bilmez");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Mecburidi bratan")
                .GreaterThanOrEqualTo(1).WithMessage("0-dan cox olmalidir");
            RuleFor(x => x.DiscountPrice)
                .GreaterThanOrEqualTo(1).WithMessage("0-dan cox olmalidir");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Price < x.DiscountPrice)
                    context.AddFailure("Endirim qiymeti esas qiymetden cox ola bilmez");
            });
        }
    }
}
