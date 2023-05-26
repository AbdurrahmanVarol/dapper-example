using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Business.Dtos.Requests
{
    public class ToggleCompleteTodoRequest
    {
        public int TodoId { get; set; }
    }
}
