namespace Application.Features.Activities.Models;

public record ActivityAttendanceRequest(
    int UserId,
    bool Attended
);