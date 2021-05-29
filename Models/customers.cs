using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AeroLion.Models
{
    public class customers
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string user_name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Compare("password")]
        public string ConfirmPassword { get; set; }
        public string SingaporeIC { get; set; }
        public string passport_no { get; set; }
        public string full_name { get; set; }
        public string phone_no { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public bool is_admin { get; set; }
        public DateTime date_of_birth { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
