using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ReservationDTOs
{
	public class ReservationListDTO
	{
		public int ReservationID { get; set; }
		public int AppUserID { get; set; }
		public AppUser? AppUser { get; set; }
		public string? PersonCount { get; set; }
		public int DestinationID { get; set; }
		public Destination? Destination { get; set; }
		public string? Status { get; set; }
	}
}
