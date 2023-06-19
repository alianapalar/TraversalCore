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
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void ChangePastReservation(int id)
        {
            _reservationDal.ChangePastReservation(id);
        }

        public void ChangeReservationStatus(int id)
        {
            _reservationDal.ChangeReservationStatus(id);
        }

        public Reservation GetById(int id)
        {
           return _reservationDal.GetById(id);
        }

        public List<Reservation> GetList()
        {
            return _reservationDal.GetList();
        }

        public List<Reservation> GetListWithAcceptedReservation()
        {
            return _reservationDal.GetListWithAcceptedReservation();
        }

        public List<Reservation> GetListWithPastReservation()
        {
            return _reservationDal.GetListWithPastReservation();
        }

        public List<Reservation> GetListWithReservationAppUserAndDestination()
        {
            return _reservationDal.GetListWithReservationAppUserAndDestination();
        }

        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            return _reservationDal.GetListWithReservationByAccepted(id);
        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            return _reservationDal.GetListWithReservationByPrevious(id);
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            return _reservationDal.GetListWithReservationByWaitApproval(id);
        }

        public List<Reservation> GetListWithWaitApprovalReservation()
        {
            return _reservationDal.GetListWithWaitApprovalReservation();
        }

        public void TAdd(Reservation entity)
        {
           _reservationDal.Insert(entity);
        }

        public void TDelete(Reservation entity)
        {
            _reservationDal.Delete(entity);
        }

        public void TUpdate(Reservation entity)
        {
            _reservationDal.Update(entity); 
        }
    }
}
