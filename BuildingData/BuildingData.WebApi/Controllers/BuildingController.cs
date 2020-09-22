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
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            List<BuildingVM> model = new List<BuildingVM>();
            _buildingService.GetAllBuildings().ToList().ForEach(u =>
            {
                BuildingVM buildingData = new BuildingVM
                {
                    Id = u.Id,
                    Name = u.Name,
                    Location = u.Location
                };
                model.Add(buildingData);
            });

            return Ok(model);
        }
    }
}