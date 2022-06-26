using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ApplicationUserRepository : IApplicationUserRepository //jubel
{
	private readonly RentendContext _db;
	private readonly UserManager<ApplicationUser> _userManager;
	public ApplicationUserRepository(RentendContext db, UserManager<ApplicationUser> userManager)
	{
		_db = db;
		_userManager = userManager;
	}
	public async Task<IEnumerable<ApplicationUser>> GetAll()
	{
		var list = await _db.ApplicationUsers.ToListAsync();
		return list;
	}
	public async Task<ApplicationUser> GetById(string id)
	{
		var r = await _db.ApplicationUsers.FirstOrDefaultAsync(m => m.Id.Equals(id));
		if(r == null)
		{
			throw new Exception("No such item exists");
		}
		return r;
	}
	public async Task<ApplicationUser> Add(ApplicationUser applicationUser, string password)
	{
		var x = await _userManager.CreateAsync(applicationUser, password);
		if (!x.Succeeded)
		{
			throw new Exception("Sorry, something went wrong");
		}
		return applicationUser;
	}
	public async Task Update(ApplicationUser applicationUser)
	{
		var x = await _userManager.UpdateAsync(applicationUser);
		if (!x.Succeeded)
		{
			throw new Exception("Sorry, couldnt apply changes");
		}
	}
	public async Task Update(ApplicationUser usr, string password)
	{
		if(usr == null)
		{
			throw new Exception("User not found");
		}
		var token = await _userManager.GeneratePasswordResetTokenAsync(usr);
		await _userManager.ResetPasswordAsync(usr, token, password);
	}
	public async Task Delete(ApplicationUser applicationUser)
	{
		if(applicationUser != null)
		{
			await _userManager.DeleteAsync(applicationUser);
		}
	}
}

