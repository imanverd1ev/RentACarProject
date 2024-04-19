using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using (RentACarContext context=new RentACarContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands on c.BrandId equals b.BrandId
							 join k in context.Colors on c.ColorId equals k.ColorId
							 select new CarDetailDto {
								 Description = c.Description,
								 BrandName = b.BrandName,
								 ColorName = k.ColorName,
								 DailyPrice = c.DailyPrice,
							 };
				return result.ToList();


			}
		}
	}
}
