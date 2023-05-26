using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Entities
{
    public class Todo : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompletedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
