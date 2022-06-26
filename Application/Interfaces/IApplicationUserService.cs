using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;
public interface IApplicationUserService
{
	Task<IEnumerable<ApplicationUserDto>> GetAllApplicationUsers();
	Task<ApplicationUserDto> GetById(string id);
	Task<ApplicationUserDto> AddNewApplicationUser(CreateApplicationUserDto applicationUser, string password);
	Task UpdateApplicationUser(string id, UpdateApplicationUserDto applicationUser);
	Task UpdateApplicationUser(string id, string password);
	Task DeleteApplicationUser(string id);
}

