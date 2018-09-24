using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Common
{
    public class JobHistory
    {
        public long Id { get; set; }
        public Guid SensorId { get; set; }
        public string SensorName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public bool Notified { get; set; }
    }
}
