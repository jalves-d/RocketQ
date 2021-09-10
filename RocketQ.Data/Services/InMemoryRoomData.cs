using RocketQ.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketQ.Data.Services
{
    public class InMemoryRoomData : IDataAccess<Room>
    {
        List<Room> rooms;
        public InMemoryRoomData()
        {
            rooms = new List<Room>()
            {
                new Room{ Id = 1, Password = "NADA"}
            };
        }
        public Room Get(int id)
        {
            return rooms.FirstOrDefault(r => r.Id == id);
        }
        public void Add(Room room)
        {
            room.Id = rooms.Max(r => r.Id) + 1;
            rooms.Add(room);
        }
        public int ConfirmRoom(Room room, string password)
        {
            var existing = rooms.Where(r => r.Id == room.Id).Where(r => r.Password == password);
            if (existing != null)
                return (1);
            return (0);
        }
        public List<Room> GetAll()
        {
            return rooms;
        }
    }
}
