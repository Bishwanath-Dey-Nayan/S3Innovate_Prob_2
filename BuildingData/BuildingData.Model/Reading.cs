using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Model
{
    public class Reading
    {
        public Int16 BuildingId { get; set; }
        public byte ObjectId { get; set; }
        public byte DataFieldId { get; set; }
        public decimal Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
