using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildingData.Repository
{
    public class ObjectDataRepo : IObjectDataRepo
    {
        private readonly ApplicationContext _context;

        public ObjectDataRepo(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Model.Object> GetAllData()
        {
            return _context.Object.ToList();
        }
    }
}
