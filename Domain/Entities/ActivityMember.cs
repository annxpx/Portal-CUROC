using Domain.Base;

namespace Domain.Entities;

public class ActivityMember : EntityBase
{
    public required int ActivityId { get; set; }

    public Activity Activity { get; set; } = null!;

    public required int MemberId { get; set; }

    public User Member { get; set; } = null!;
    public required bool Attended { get; set; } = false;
    
    public required ICollection<ActivityMemberScope> Scopes { get; set; } 
}