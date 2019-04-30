using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Database.DTO
{
    public class LogDTO
    {
        public LogDTO()
        { }
        public string Message
        { get; set; }

        public DateTime DateStamp
        { get; set; }
    }
}
