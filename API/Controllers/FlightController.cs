using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Entities.Data;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/xml", "application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FlightDbContext _db;
        public FlightController(FlightDbContext db)
        {
            _db = db;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Flight> GetAll()
        {
            return _db.Flights;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flight = _db.Flights.Where(x => x.FlightId == id);

            return Ok(flight);
        }

        // POST api/values
        [HttpGet("{fromLocation}/{toLocation}")]
        public async Task<IActionResult> GetByLocation(string fromLocation, string toLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flight = _db.Flights.Where(x => x.FromLocation == fromLocation && x.ToLocation == toLocation);

            return Ok(flight);
        }

        // PUT api/values/5
        [HttpPost]
        public async Task<IActionResult> CreateNewFlight([FromBody]Flight flight)
        {

            await _db.Flights.AddAsync(flight);
            _db.SaveChanges();

            return Ok();
        }

        // DELETE api/values/5
        [HttpPatch]
        public IActionResult ChangeFlight([FromBody] FlightDTO flightDTO)
        {
            var flight = _db.Flights.FirstOrDefault(c => c.FlightId == flightDTO.FlightId);
            if (flight == null)
                return NotFound();
            else
            {
                flight.FlightId = flightDTO.FlightId;
                flight.AitcraftType = flightDTO.AitcraftType;
                flight.ArrivalTime = flightDTO.ArrivalTime;
                flight.DepartureTime = flightDTO.DepartureTime;
                flight.FromLocation = flightDTO.FromLocation;
                flight.ToLocation = flightDTO.ToLocation;
                _db.SaveChanges();
            }
            return Ok();
        }
    }
}
