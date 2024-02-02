using FluentValidation;

namespace Application.Features.AccountLessons.Commands.Update;

public class UpdateAccountLessonCommandValidator : AbstractValidator<UpdateAccountLessonCommand>
{
    public UpdateAccountLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.Points).NotEmpty();
        RuleFor(c => c.IsComplete).NotNull();

        RuleFor(c => c.Points).GreaterThanOrEqualTo(0);
        RuleFor(c => c.Points).LessThanOrEqualTo(100);

    }
}