﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public IResult Add(Car car)
		{
            if (car.DailyPrice<50)
            {
			return new ErrorResult(Messages.CarNameInvalid);

			}
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
        }

		public IDataResult<List<Car>> GetAll()
		{
            if (DateTime.Now.Hour==22)
            {
            return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

			}
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
		}

		public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
		}

		public IDataResult<List<Car>> GetCarsByColorId(int colorId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
		}
	}
}
