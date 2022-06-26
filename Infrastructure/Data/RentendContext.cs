using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class RentendContext : IdentityDbContext
{
	public RentendContext(DbContextOptions options) : base(options) { }

	public DbSet<Brand> Brands { get; set; }
	public DbSet<Department> Departments { get; set; }
	public DbSet<Car> Cars { get; set; }
	public DbSet<Pin> Pins { get; set; }
	public DbSet<Rent> Rent { get; set; }
	public DbSet<ApplicationUser> ApplicationUsers { get; set; }
}

