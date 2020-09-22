using BuildingData.Model;
using BuildingData.Repository.Interface;
using BuildingData.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Service.Service
{
    public class DataFieldService:IDataFieldService
    {
        private readonly IDataFieldDataRepo _dataFieldRepo;
        public DataFieldService(IDataFieldDataRepo dataFieldRepo)
        {
            _dataFieldRepo = dataFieldRepo;
        }
        public IEnumerable<DataField> GetAllDataField()
        {
            return _dataFieldRepo.GetAllData();
        }

    }
}
