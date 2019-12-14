using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace ProjectOne_Missions.Models
{
    public class Missions
    {
        [Key]
        [Required]
        public int MissionID { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        [Display(Name = "Mission Name")]
        public string MissionName { get; set; }
        [Required]
        [Display(Name = "Mission President")]
        public string PresLastName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string MissionAddress { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Climate { get; set; }
        [Required]
        [Display(Name = "Dominant Religion")]
        public string DomReligion { get; set; }
        [Required]
        public string Flag { get; set; }
    }

    /* 
     public class Missions
    {
        [Key]
        [Required]
        public int MissionCode { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        [Display(Name = "Mission Name")]
        public string MissionName { get; set; }
        [Required]
        [Display(Name = "Mission President")]
        public string PresName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [RegularExpression("[A-Z]{2}")]
        public string State { get; set; }
        [Required]
        [RegularExpression("[0-9]{5,7}(-[0-9]{4})?")]
        public string ZipCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Climate { get; set; }
        [Required]
        [Display(Name = "Dominant Religion")]
        public string Religion { get; set; }
        [Required]
        public string flagImage { get; set; }
    }
     */
}