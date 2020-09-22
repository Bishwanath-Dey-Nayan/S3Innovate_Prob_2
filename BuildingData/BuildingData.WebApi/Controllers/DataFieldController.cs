using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingData.Service.Interface;
using BuildingData.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingData.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataFieldController : ControllerBase
    {
        private readonly IDataFieldService _dataFieldService;
        public DataFieldController(IDataFieldService dataFieldServie)
        {
            _dataFieldService = dataFieldServie;
        }
        [HttpGet]
        public ActionResult Get()
        {
            List<DataFieldVM> model = new List<DataFieldVM>();
            _dataFieldService.GetAllDataField().ToList().ForEach(u =>
            {
                DataFieldVM dataFieldData = new DataFieldVM
                {
                    Id = u.Id,
                    Name = u.Name
                };
                model.Add(dataFieldData);
            });
            return Ok(model);
        }
    }
}