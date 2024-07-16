using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            this.cargoDetailDal = cargoDetailDal;
        }

        public void TDelete(int id)
        {
            cargoDetailDal.Delete(id);
        }

        public List<CargoDetail> TGetAll()
        {
            return cargoDetailDal.GetAll();
        }

        public CargoDetail TGetById(int id)
        {
            return cargoDetailDal.GetById(id);
        }

        public void TInsert(CargoDetail entity)
        {
            cargoDetailDal.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            cargoDetailDal.Update(entity);
        }
    }
}
