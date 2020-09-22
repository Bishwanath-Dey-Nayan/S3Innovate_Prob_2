using BuildingData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Repository
{
    public interface IReadingDataRepo
    {
        IEnumerable<Reading> GetAllData();
        IEnumerable<Reading> SearchData(Int16 buildingId, byte objectDataId, byte dataFieldId, DateTime startDate, DateTime endDate);
    }
}
