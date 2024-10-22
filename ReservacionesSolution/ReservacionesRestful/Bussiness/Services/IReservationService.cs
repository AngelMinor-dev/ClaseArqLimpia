using ReservacionesRestful.Bussiness.Entities;
using ReservacionesRestful.Data.DTOs;

namespace ReservacionesRestful.Bussiness.Services
{
    public interface IReservationService
    {
        List<Reservation> GetAll();

        int Insert(ReservationDTO dto);

        List<Room> GetAvailableRooms();
    }
}
