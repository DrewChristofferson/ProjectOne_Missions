using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectOne_Missions.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [Required]
        public int UserID { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string UserFName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string UserLName { get; set; }
        [DisplayName("Email")]
        [Required]
        public string UserEmail { get; set; }
        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }
    }

}