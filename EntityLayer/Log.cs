using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public string LogStatus { get; set; }
        public string LogDescirption { get; set; }
        public int PingId { get; set; }

        public DateTime AddedDate { get; set; }
        public int UserId { get; set; }

    }
}
