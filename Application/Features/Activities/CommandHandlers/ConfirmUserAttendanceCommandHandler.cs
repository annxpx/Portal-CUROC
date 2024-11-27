using Application.Contracts;
using Application.Features.Activities.Commands;
using Domain.Contracts;
using Domain.Enums;
using Domain.Errors;
using Mediator;
using Shared;

namespace Application.Features.Activities.CommandHandlers;
public record ConfirmUserAttendanceCommandHandler(
    IActivityRepository ActivityRepository,
    ICurrentUserService CurrentUserService
) : ICommandHandler<ConfirmUserAttendanceCommand, Result>
{
    public async ValueTask<Result> Handle(ConfirmUserAttendanceCommand request, CancellationToken cancellationToken)
    {
        var activity = await ActivityRepository.GetByIdAsync(request.ActivityId, cancellationToken);
        if (activity is null) return Result.Failure(ActivityErrors.ActivityNotFound);

        if (activity.ActivityStatus != ActivityStatus.InProgress || activity.ActivityStatus != ActivityStatus.Completed)
            return Result.Failure(ActivityErrors.InvalidActivityStatusForAttendance);

        var currentUser = await CurrentUserService.GetCurrentUserAsync(cancellationToken);
        if (currentUser != activity.Coordinator || currentUser != activity.Supervisor)
            return Result.Failure(ActivityErrors.InvalidWriteAttendanceRole);

        var activityMember = activity.Members.FirstOrDefault(member => member.MemberId == request.UserId);
        if (activityMember is null) return Result.Failure(ActivityErrors.UserNotJoinedActivity);
        
        activityMember.Attended = request.Attended;
        await ActivityRepository.UpdateMemberAsync(activityMember, cancellationToken);

        return Result.Success();
    }
}