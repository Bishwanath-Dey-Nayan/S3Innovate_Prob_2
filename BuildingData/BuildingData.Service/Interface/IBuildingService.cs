using BuildingData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Service.Interface
{
    public interface IBuildingService
    {
        IEnumerable<Building> GetAllBuildings();
    }
}
