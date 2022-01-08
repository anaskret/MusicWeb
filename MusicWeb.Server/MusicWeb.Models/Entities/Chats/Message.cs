using MusicWeb.Models.Entities.Base;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public string ImagePath { get; set; }

        public int ChatId { get; set; }
        public string SenderId { get; set; }
        public virtual Chat Chat { get; set; }
        public virtual ApplicationUser Sender{ get; set; }
    }
}
