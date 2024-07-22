using ejpservice.Domain.Entities;

namespace ejpservice.Domain.Interface
{
    public interface IAdmin : IBaseRepository<Admin>
    {
        List<Admin> GetAdmin();
    }
}
