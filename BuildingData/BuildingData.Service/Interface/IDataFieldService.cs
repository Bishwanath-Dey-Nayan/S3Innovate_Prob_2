using BuildingData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Service.Interface
{
    public interface IDataFieldService
    {
        IEnumerable<DataField> GetAllDataField();
    }
}
