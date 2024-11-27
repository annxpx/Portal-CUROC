using Shared;
using Mediator;

namespace Application.Features.Activities.Commands;
public record ConfirmUserAttendanceCommand(
    int ActivityId,
    int UserId,
    bool Attended
) : ICommand<Result>;