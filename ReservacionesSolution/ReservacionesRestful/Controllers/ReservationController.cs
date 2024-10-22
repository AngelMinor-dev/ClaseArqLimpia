using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservacionesRestful.Bussiness.Services;
using ReservacionesRestful.Data.DTOs;

namespace ReservacionesRestful.Controllers
{
    [Route("api/[controller]")] //http://api.port/api/Reservation
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;  
        }

        [HttpPost]
        public IActionResult Create(ReservationDTO  reservationDTO)
        {
            try { 
                var result = _reservationService.Insert(reservationDTO);

                return result >0 ? Created() :BadRequest();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        
        }


        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_reservationService.GetAll());
        }


        [HttpGet("rooms")]
        public IActionResult GetAvailableRooms()
        {
            return Ok(_reservationService.GetAvailableRooms());
        }
    }
}
