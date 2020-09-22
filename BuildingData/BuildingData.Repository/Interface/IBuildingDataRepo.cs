using BuildingData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Repository
{
    public interface IBuildingDataRepo
    {
            IEnumerable<Building> GetAllData();
    }
}
