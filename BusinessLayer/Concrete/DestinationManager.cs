using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DestinationManager:IDestinationService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public Destination GetById(int id)
        {
            return _destinationDal.GetById(id);
        }

        public Destination GetDestinationWithGuide(int id)
        {
            return _destinationDal.GetDestinationWithGuide(id);
        }

        public List<Destination> GetLast4Destinations()
        {
            return _destinationDal.GetLast4Destinations();
        }

        public List<Destination> GetList()
        {
            return _destinationDal.GetList();
        }

        public void TAdd(Destination entity)
        {
            _destinationDal.Insert(entity);
        }

        public void TDelete(Destination entity)
        {
            _destinationDal.Delete(entity);
        }

        public void TUpdate(Destination entity)
        {
            _destinationDal.Update(entity);
        }
    }
}
