using ReservacionesRestful.Bussiness.Entities;
using ReservacionesRestful.Data.DTOs;
using ReservacionesRestful.Data.Repositories;

namespace ReservacionesRestful.Bussiness.Services
{
    public class ReservationServiceImp : IReservationService
    {
        private readonly UserRepository _userRepository;
        private readonly ReservationRepository _reservationRepository;
        private readonly RoomRepository _roomRepository;

        public ReservationServiceImp(UserRepository userRepository,ReservationRepository reservationRepository, RoomRepository  roomRepository)
        {
            _userRepository = userRepository;  
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;   
        }

        public List<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }

        public List<Room> GetAvailableRooms()
        {
            return _roomRepository.GetAvailable();
        }

        public int Insert(ReservationDTO dto)
        {
            //busqueda usuario
            var user = new User();  
            try
            {
                user = _userRepository.FindById(dto.UserId);
            }
            catch (Exception ex) { Console.WriteLine($"No existe el usuario {ex.Message}"); throw;  }

            //busqueda de cuarto
            var room = new Room();
            try {
                room = _roomRepository.FinById(dto.RoomId);
            } 
            catch (Exception ex) { Console.WriteLine(ex.Message); throw; }

            if (room.Available) {
                Reservation reservation = new Reservation()
                {
                    UserId = dto.UserId,
                    RoomId = dto.RoomId,
                    Begin = dto.Begin,
                    End = dto.End
                };
                int result = _reservationRepository.Insert(reservation);
                room.Available = false;
                _roomRepository.Update(room);
                return result;
            }

            throw new Exception($"Habitación no dispobible {room.Id}");
        }
    }
}
