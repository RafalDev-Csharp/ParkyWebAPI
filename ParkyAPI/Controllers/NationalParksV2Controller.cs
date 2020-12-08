﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.Models;
using ParkyAPI.Models.Dtos;
using ParkyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/nationalparks")]
    [ApiVersion("2.0")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "ParkyOpenAPISpecNP")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class NationalParksV2Controller : Controller
    {
        private readonly INationalParkRepository _npRepo;
        private readonly IMapper _mapper;

        public NationalParksV2Controller(INationalParkRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }


        /// <summary>
        /// Get list of national parks.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<NationalParkDto>))]
        //[Route("api/[controller]")]
        public IActionResult GetNationalParks()
        {
            var obj = _npRepo.GetNationalParks().FirstOrDefault();

            return Ok(_mapper.Map<NationalParkDto>(obj));
        }


        ///// <summary>
        ///// Get individual national park
        ///// </summary>
        ///// <param name="nationalParkId"> The Id of national park.</param>
        ///// <returns></returns>
        //[HttpGet("{nationalParkId:int}", Name = "GetNationalPark")]
        //[ProducesResponseType(200, Type = typeof(NationalParkDto))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        ////[Route("api/[controller]/{nationalParkId}")]
        //public IActionResult GetNationalPark(int nationalParkId)
        //{
        //    var obj = _npRepo.GetNationalPark(nationalParkId);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    var objDto = _mapper.Map<NationalParkDto>(obj);
        //    return Ok(objDto);
        //}


        
        //[HttpPost]
        //[ProducesResponseType(201, Type = typeof(NationalParkDto))]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public IActionResult CreateNationalPark([FromBody] NationalParkDto nationalParkDto)
        //{
        //    if (nationalParkDto == null)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    if (_npRepo.NationalParkExists(nationalParkDto.Name))
        //    {
        //        ModelState.AddModelError("", "National Park name exists!");
        //        return StatusCode(404, ModelState);
        //    }

        //    var nationalParkObj = _mapper.Map<NationalPark>(nationalParkDto);

        //    if(!_npRepo.CreateNationalPark(nationalParkObj))
        //    {
        //        ModelState.AddModelError("", $"Something went wrong when saving the record {nationalParkObj.Name}");
        //        return StatusCode(500, ModelState);
        //    }
        //    return CreatedAtRoute("GetNationalPark", new { nationalParkId = nationalParkObj.Id }, nationalParkObj);
        //}


        //[HttpPatch("{nationalParkId:int}", Name = "UpdateNationalPark")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public IActionResult UpdateNationalPark(int nationalParkId, [FromBody] NationalParkDto nationalParkDto)
        //{
        //    if (nationalParkDto == null || nationalParkId != nationalParkDto.Id)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    //if (_npRepo.NationalParkExists(nationalParkDto.Name))
        //    //{
        //    //    ModelState.AddModelError("", "National Park name exists!");
        //    //    return StatusCode(404, ModelState);
        //    //}

        //    var nationalParkObj = _mapper.Map<NationalPark>(nationalParkDto);
        //    if (!_npRepo.UpdateNationalPark(nationalParkObj))
        //    {
        //        ModelState.AddModelError("", $"Something went wrong when updating the record {nationalParkObj.Name}");
        //        return StatusCode(500, ModelState);
        //    }
        //    return NoContent();
        //}


        //[HttpDelete("{nationalParkId:int}", Name = "DeleteNationalPark")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status409Conflict)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public IActionResult DeleteNationalPark(int nationalParkId)
        //{
        //    if (!_npRepo.NationalParkExists(nationalParkId))
        //    {
        //        return NotFound();
        //    }

        //    var nationalParkObj = _npRepo.GetNationalPark(nationalParkId);
        //    if (!_npRepo.DeleteNationalPark(nationalParkObj))
        //    {
        //        ModelState.AddModelError("", $"Something went wrong when deleting the record {nationalParkObj.Name}");
        //        return StatusCode(500, ModelState);
        //    }
        //    return NoContent();
        //}

    }
}