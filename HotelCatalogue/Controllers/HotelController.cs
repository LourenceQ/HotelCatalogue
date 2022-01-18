using AutoMapper;
using HotelCatalogue.Data;
using HotelCatalogue.IRepository;
using HotelCatalogue.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCatalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnityOfWork unityOfWork, 
                               ILogger<HotelController> logger,
                               IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _unityOfWork.Hotels.GetAll();
                var results = _mapper.Map<IList<HotelDTO>>(hotels);
                return Ok(results);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetHotels)}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [Authorize]
        [HttpGet("{id:int}", Name = "GetHotel")]
        public async Task<IActionResult> GetByIdHotel(int id)
        {
            try
            {
                var hotel = await _unityOfWork.Hotels.Get(c => c.Id == id, new List<string> { "Country" });
                var result = _mapper.Map<HotelDTO>(hotel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong int the {nameof(GetByIdHotel)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDTO hotelDTO)
        {
            if(!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateHotel)}");
                return BadRequest(ModelState);
            }

            try
            {
                var hotel = _mapper.Map<Hotel>(hotelDTO);
                await _unityOfWork.Hotels.Insert(hotel);
                await _unityOfWork.Save();

                return CreatedAtRoute("GetHotel", new { id = hotel.Id}, hotel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong int the {nameof(CreateHotel)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateHotel(int id,[FromBody] UpdateHotelDTO hotelDTO)
        {
            if(!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(UpdateHotel)}");
                return BadRequest(ModelState);
            }

            try
            {
                var hotel = await _unityOfWork.Hotels.Get(q => q.Id == id);
                if(hotel == null)
                {
                    _logger.LogError($"Invalid POST attempt in {nameof(UpdateHotel)}");
                    return BadRequest("Submitted data is invalid");
                }
                _mapper.Map(hotelDTO, hotel);
                _unityOfWork.Hotels.Update(hotel);
                await _unityOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong int the {nameof(UpdateHotel)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(DeleteHotel)}");
                return BadRequest(ModelState);
            }

            try
            {
                var hotel = await _unityOfWork.Hotels.Get(q => q.Id == id);
                if (hotel == null)
                {
                    _logger.LogError($"Invalid POST attempt in {nameof(DeleteHotel)}");
                    return BadRequest("Submitted data is invalid");
                }
               
                await _unityOfWork.Hotels.Delete(id);
                await _unityOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong int the {nameof(DeleteHotel)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

    }
}
