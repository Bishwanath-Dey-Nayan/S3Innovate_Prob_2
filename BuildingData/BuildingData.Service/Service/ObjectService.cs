using BuildingData.Repository;
using BuildingData.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Service.Service
{
    public class ObjectService : IObjectService
    {
        private readonly IObjectDataRepo _objectRepo;
        public ObjectService(IObjectDataRepo objectRepo)
        {
            _objectRepo = objectRepo;
        }
        public IEnumerable<Model.Object> GetAllObjects()
        {
            return _objectRepo.GetAllData();
        }
    }
}
