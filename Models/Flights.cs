using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AeroLion.Models
{
    public class Flights
    {
        [Required]
        public int ID { get; set; }
        public string Flight_Id { get; set; }
        public string from_city { get; set; }
        public string to_city { get; set; }
        public DateTime arrival_time { get; set; }
        public DateTime depart_time { get; set; }
        public float fare { get; set; }
        public int max_seats { get; set; }
    }
}
