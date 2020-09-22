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
    public class ObjectController : ControllerBase
    {
        private readonly IObjectService _objectService;
        public ObjectController(IObjectService objectService)
        {
            _objectService = objectService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<ObjectVM> model = new List<ObjectVM>();
            _objectService.GetAllObjects().ToList().ForEach(u =>
            {
                ObjectVM objectData = new ObjectVM()
                {
                    Id = u.Id,
                    Name = u.Name
                };
                model.Add(objectData);

            });
            return Ok(model);
        }
    }
}