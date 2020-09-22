using BuildingData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Service
{
    public interface IReadingService
    {
        IEnumerable<Reading> GetAllReadings();
        IEnumerable<Reading> SearchData(Int16 buildingId, byte objectDataId, byte dataFieldId, DateTime startDate, DateTime endDate);
    }
}
