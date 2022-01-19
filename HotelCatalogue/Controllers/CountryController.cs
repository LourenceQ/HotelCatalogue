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
    public class CountryController : ControllerBase
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnityOfWork unityOfWork, 
            ILogger<CountryController> logger,
            IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllCountries([FromQuery] RequestParams requestParams)
        {
           
                var countries = await _unityOfWork.Countries.GetPagedList(requestParams);
                var results = _mapper.Map<List<CountryDTO>>(countries);
                return Ok(results);            
        }

        [Authorize]
        [HttpGet("{id:int}", Name = "GetCountry")]
        public async Task<IActionResult> GetByIdCountry(int id)
        {
            
            var country = await _unityOfWork.Countries.Get(c => c.Id == id, new List<string> { "Hotels" });
            var result = _mapper.Map<CountryDTO>(country);
            return Ok(result);
            
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDTO countryDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateCountry)}");
                return BadRequest(ModelState);
            }
                var country = _mapper.Map<Country>(countryDTO);
                await _unityOfWork.Countries.Insert(country);
                await _unityOfWork.Save();

                return CreatedAtRoute("GetCountry", new { id = country.Id }, country);
            
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] UpdateCountryDTO countryDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(UpdateCountry)}");
                return BadRequest(ModelState);
            }
            
                var country = await _unityOfWork.Countries.Get(q => q.Id == id);
                if (country == null)
                {
                    _logger.LogError($"Invalid POST attempt in {nameof(UpdateCountry)}"); 
                    return BadRequest("Submitted data is invalid");
                }
                _mapper.Map(countryDTO, country);
                _unityOfWork.Countries.Update(country);
                await _unityOfWork.Save();

                return NoContent();            
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(DeleteCountry)}");
                return BadRequest(ModelState);
            }
            
                var country = await _unityOfWork.Countries.Get(q => q.Id == id);
                if (country == null)
                {
                    _logger.LogError($"Invalid POST attempt in {nameof(DeleteCountry)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unityOfWork.Countries.Delete(id);
                await _unityOfWork.Save();

                return NoContent();            
        }
    }
}
