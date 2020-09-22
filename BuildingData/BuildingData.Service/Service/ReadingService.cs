using BuildingData.Model;
using BuildingData.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Service
{
    public class ReadingService : IReadingService
    {
        private IReadingDataRepo _readingRepo;
        public ReadingService(IReadingDataRepo readingRepo)
        {
            _readingRepo = readingRepo;
        }
        public IEnumerable<Reading> GetAllReadings()
        {
            return _readingRepo.GetAllData();
        }

        public IEnumerable<Reading> SearchData(short buildingId, byte objectDataId, byte dataFieldId, DateTime startDate, DateTime endDate)
        {
            return _readingRepo.SearchData(buildingId,objectDataId,dataFieldId,startDate,endDate);
        }
    }
}
