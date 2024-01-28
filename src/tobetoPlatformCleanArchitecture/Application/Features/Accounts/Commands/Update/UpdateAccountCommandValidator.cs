using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Features.Accounts.Commands.Update;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.NationalIdentificationNumber).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        //RuleFor(c => c.ProfilePhotoPath).NotEmpty();
        RuleFor(c => c.ShareProfile).NotEmpty();
        RuleFor(c => c.ProfileLinkUrl).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();

        RuleFor(a => a.PhoneNumber).Length(12).Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"));
        RuleFor(a => a.NationalIdentificationNumber).Length(11).Matches(new Regex(@"^[1-9]{1}[0-9]{9}[02468]{1}$"));
    }
}