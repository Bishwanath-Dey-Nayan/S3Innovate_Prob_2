using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Service.Interface
{
    public interface IObjectService
    {
        IEnumerable<Model.Object> GetAllObjects();
    }
}
