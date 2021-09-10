using RocketQ.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketQ.Data.Services
{
    public class InMemoryQuestionData : IDataAccess<Questions>
    {
        public List<Questions> questions;
        public InMemoryQuestionData()
        {
            questions = new List<Questions>()
            {
                new Questions{ Id = 1, Text = "TestandoApenas", Readed = false, RoomId = 1},
                new Questions{ Id = 2, Text = "Eu sou lindo", Readed = true, RoomId = 1},
                new Questions{ Id = 3, Text = "Funciona mesmo", Readed = false, RoomId = 1}
            };
        }
        public InMemoryQuestionData(List<Questions> questions)
        {
            this.questions = questions;
        }
        public void Add(Questions question)
        {
            question.Id = questions.Max(r => r.Id) + 1;
            questions.Add(question);
        }

        public Questions Get(int id)
        {
            return questions.FirstOrDefault(r => r.Id == id);
        }
        public IEnumerable<Questions> GetAll(int roomId)
        {
            return questions.Where(r => r.RoomId == roomId).OrderBy(r => r.Id);
        }
        public void Delete(int questionid)
        {
            var existing = Get(questionid);
            if (existing != null)
                questions.Remove(Get(questionid));
        }
        public void Update(int questionid)
        {
            var existing = Get(questionid);
            if (existing != null)
            {
                existing.Readed = true;
            }
        }
    }
}
