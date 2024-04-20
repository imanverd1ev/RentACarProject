using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class RentACarContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=LAPTOP-S4ROCGFN\SQLEXPRESS01;Database=RentACar;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true");
		}
		public DbSet<Brand> Brands;
		public DbSet<Car> Cars;
		public DbSet<Color> Colors;
	}
}
