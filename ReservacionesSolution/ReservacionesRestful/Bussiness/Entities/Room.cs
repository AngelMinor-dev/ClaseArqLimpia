﻿using System.Security.Policy;
using System.Text.Json.Serialization;

namespace ReservacionesRestful.Bussiness.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public string RoomId { get; set; }

        public bool Available { get; set; }

        [JsonIgnoreAttribute]
        public ICollection<Reservation> Reservations { get; set; }  
    }
}
