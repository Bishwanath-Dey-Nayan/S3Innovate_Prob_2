using BuildingData.Model;
using BuildingData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildingData.Repository.Repo
{
    public class DataFieldDataRepo : IDataFieldDataRepo
    {
        private readonly ApplicationContext _context;
        public DataFieldDataRepo(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<DataField> GetAllData()
        {
            return _context.DataField.ToList();
        }
    }
}
