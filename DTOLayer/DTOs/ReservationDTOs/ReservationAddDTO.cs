using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ReservationDTOs
{
    public class ReservationAddDTO
    {
        public int? AppUserID { get; set; }
        public int? PersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int DestinationID { get; set; }
       

    }
}
