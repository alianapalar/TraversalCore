using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByAccepted(int id);
        List<Reservation> GetListWithReservationByPrevious(int id);
        List<Reservation> GetListWithReservationByWaitApproval(int id);
        List<Reservation> GetListWithReservationAppUserAndDestination();
        List<Reservation> GetListWithAcceptedReservation();
        List<Reservation> GetListWithWaitApprovalReservation();
        List<Reservation> GetListWithPastReservation();
        void ChangeReservationStatus(int id);
        void ChangePastReservation(int id);

    }
}
