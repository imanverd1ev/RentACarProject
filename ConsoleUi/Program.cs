using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUi
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager=new CarManager(new EfCarDal());

            Console.WriteLine(carManager.GetAll().Success);
        }
	}
}