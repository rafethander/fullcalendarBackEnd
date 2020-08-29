using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBack.Database.Models
{
    public class ToDos
    {
        public Guid Id { get; set; }
        public DateTime Olusturuldu { get; set; }
        public bool Silindi { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
