using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketQ.Data.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Readed { get; set; }
        public int RoomId { get; set; }
    }
}
