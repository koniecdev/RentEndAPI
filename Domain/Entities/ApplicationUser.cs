using Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;
public class ApplicationUser : IdentityUser
{
    public string Address { get; set; }

	public ApplicationUser(string address)
	{
		Address = address;
	}
}