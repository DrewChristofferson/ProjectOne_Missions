using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectOne_Missions.Models
{
    [Table("MissionQuestions")]
    public class MissionQuestions
    {
        [Key]
        public int MissionQ_ID { get; set; }
        public String Question { get; set; }
        public String Answer { get; set; }
        public virtual int MissionID { get; set; }
        public virtual Missions Missions { get; set; }
        public virtual int UserID { get; set; }
        public virtual Users Users { get; set; }
        

  


    }
}