using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingData.Service;
using BuildingData.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingData.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingDataController : ControllerBase
    {
        private readonly IReadingService _readingService;
        public ReadingDataController(IReadingService readingService)
        {
            _readingService = readingService;
        }

        /// <summary>
        /// Method to get all the Reading Data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetReadingData()
        {
            List<ReadingDataVM> model = new List<ReadingDataVM>();
            _readingService.GetAllReadings().ToList().ForEach(u =>
            {
                ReadingDataVM readingData = new ReadingDataVM
                {
                    BuildingId = u.BuildingId,
                    ObjectId = u.ObjectId,
                    DataFieldId = u.DataFieldId,
                    Value = u.Value,
                    Timestamp = u.Timestamp
                };
                model.Add(readingData);
            });
            return Ok(model);

        }
        /// <summary>
        /// Search Method
        /// </summary>
        /// <param name="buildingId"></param>
        /// <param name="objectDataId"></param>
        /// <param name="dataFieldId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Search")]
        public IActionResult Search(Int16 buildingId, byte objectDataId, byte dataFieldId, DateTime startDate, DateTime endDate)
        {
            List<ReadingDataVM> model = new List<ReadingDataVM>();
            _readingService.SearchData(buildingId, objectDataId, dataFieldId, startDate, endDate).ToList().ForEach(u =>
            {
                ReadingDataVM readingData = new ReadingDataVM
                {
                    BuildingId = u.BuildingId,
                    ObjectId = u.ObjectId,
                    DataFieldId = u.DataFieldId,
                    Value = u.Value,
                    Timestamp = u.Timestamp
                };
                model.Add(readingData);
            });
            return Ok(model);
        }
    }
}