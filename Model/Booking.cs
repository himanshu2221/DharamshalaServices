using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DharamshalaServices.Model
{
    public class Booking
    {
        public int TokenAmount { get; set; }
        public int TotalAmount { get; set; }
        public int UserId { get; set; }
        public int DharamshalaId { get; set; }
        public string  CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public int ConvenienceFee { get; set; }
        public List<Room> rooms { get; set; }
        public BookingState state;
    }
}