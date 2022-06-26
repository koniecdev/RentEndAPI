using Domain.Entities;

namespace Domain.Interfaces;
public interface IApplicationUserRepository
{
	Task<IEnumerable<ApplicationUser>> GetAll();
	Task<ApplicationUser> GetById(string id);
	Task<ApplicationUser> Add(ApplicationUser applicationUser, string password);
	Task Update(ApplicationUser applicationUser);
	Task Update(ApplicationUser applicationUser, string password);
	Task Delete(ApplicationUser applicationUser);
}
