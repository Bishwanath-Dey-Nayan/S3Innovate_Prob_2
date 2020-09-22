using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingData.WebApi.Models
{
    public class ReadingDataVM
    {
        public int BuildingId { get; set; }
        public int ObjectId { get; set; }
        public int DataFieldId { get; set; }
        public decimal Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
