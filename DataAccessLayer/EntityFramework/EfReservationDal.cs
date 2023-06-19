using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public void ChangePastReservation(int id)
        {
            Context c = new Context();
            var reservation = c.Reservations.Find(id);

            reservation.Status = (reservation.ReservationDate > DateTime.Now) ? "Onaylandı" : "Geçmiş Rezervasyon";
            c.SaveChanges();

        }

        public void ChangeReservationStatus(int id)
        {
            Context c=new Context();
            var reservation = c.Reservations.Find(id);

            reservation.Status = (reservation.Status == "Onay Bekliyor") ? "Onaylandı" : "Onay Bekliyor";
            c.SaveChanges();
        }

        public List<Reservation> GetListWithAcceptedReservation()
        {
            using (var context=new Context()) 
            {
                return context.Reservations.Include(x => x.AppUser).Include(x => x.Destination)
                    .Where(x => x.Status == "Onaylandı").ToList();
            }
        }

        public List<Reservation> GetListWithPastReservation()
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.AppUser).Include(x => x.Destination)
                    .Where(x => x.Status == "Geçmiş Rezervasyon").ToList();
            }
        }

        public List<Reservation> GetListWithReservationAppUserAndDestination()
        {
            using (var context=new Context()) 
            {
                return context.Reservations.Include(x => x.AppUser).Include(x => x.Destination).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Include(y=>y.AppUser)
                    .Where(x => x.AppUserId == id && x.Status == "Onaylandı")
                    .ToList();
            }
        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination)
                    .Where(x => x.AppUserId == id && x.Status == "Geçmiş Rezervasyon")
                    .ToList();
            }
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            using(var context=new Context()) 
            {
                return context.Reservations.Include(x => x.Destination)
                    .Where(x => x.AppUserId == id && x.Status == "Onay Bekliyor")
                    .ToList();
            }
        }

        public List<Reservation> GetListWithWaitApprovalReservation()
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.AppUser).Include(x => x.Destination)
                    .Where(x => x.Status == "Onay Bekliyor").ToList();
            }
        }
    }
}
