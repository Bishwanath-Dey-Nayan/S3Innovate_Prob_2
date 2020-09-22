using BuildingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildingData.Repository
{
    public class BuildingDataRepo:IBuildingDataRepo
    {
        private readonly ApplicationContext _context;

        public BuildingDataRepo(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Building> GetAllData()
        {
            return _context.Building.ToList();
        }
    }
}
