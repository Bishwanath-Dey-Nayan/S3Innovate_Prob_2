using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Repository
{
    public interface IObjectDataRepo
    {
            IEnumerable<Model.Object> GetAllData();

    }
}
