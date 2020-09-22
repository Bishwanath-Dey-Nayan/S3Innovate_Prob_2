using BuildingData.Model;
using BuildingData.Repository;
using BuildingData.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Service.Service
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingDataRepo _buildingRepo;

        public BuildingService(IBuildingDataRepo buildingRepo)
        {
            _buildingRepo = buildingRepo;
        }
        public IEnumerable<Building> GetAllBuildings()
        {
            return _buildingRepo.GetAllData();
        }
    }
}
