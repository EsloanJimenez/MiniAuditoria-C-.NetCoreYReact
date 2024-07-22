using ejpservice.Domain.Entities;
using ejpservice.Domain.Models;


namespace ejpservice.Domain.Interface
{
    public interface ITeamMemberRepository : IBaseRepository<TeamMember>
    {
        List<TeamMemberModel> GetTeamMember();
    }
}
