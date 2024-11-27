using Application.Features.Activities.Commands;
using FluentValidation;

namespace Application.Features.Activities.Validators;
public class ConfirmUserAttendanceValidator : AbstractValidator<ConfirmUserAttendanceCommand>
{
    public ConfirmUserAttendanceValidator()
    {
        RuleFor(x => x.ActivityId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Attended)
            .NotNull();
    }
}