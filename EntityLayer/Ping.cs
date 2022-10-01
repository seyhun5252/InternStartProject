using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Ping
    {
        [Key]
        public int PingId { get; set; }
        public string PingUrl { get; set; }
        public string PingDescription { get; set; }
        public string PingStatusCode { get; set; }

        public DateTime AddedDate { get; set; }
        public int UserId { get; set; }

    }
}
