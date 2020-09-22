using BuildingData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Repository.Interface
{
    public interface IDataFieldDataRepo
    {
        IEnumerable<DataField> GetAllData();
    }
}
