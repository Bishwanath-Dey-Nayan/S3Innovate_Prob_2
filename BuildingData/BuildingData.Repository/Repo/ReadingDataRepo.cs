using BuildingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildingData.Repository
{
    public class ReadingDataRepo : IReadingDataRepo
    {
        private readonly ApplicationContext _context;

        public ReadingDataRepo(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Reading> GetAllData()
        {
            return _context.Reading.ToList();
        }

        public IEnumerable<Reading> SearchData(Int16 buildingId, byte objectDataId, byte dataFieldId, DateTime startDate, DateTime endDate)
        {
            return _context.Reading.Where(u => u.BuildingId == buildingId && u.ObjectId == objectDataId && u.DataFieldId == dataFieldId
            && u.Timestamp >= startDate && u.Timestamp <= endDate
            ).ToList();
        }

    }
}
