using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBack.DTOs
{
   public class ToDosAddDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool Silindi { get; set; }
        [Required,MaxLength(30)]
        public string Title { get; set; }
       
        [Required]
        private DateTime end;

        public DateTime End
        {
            get { return end; }
            set { end = value.ToLocalTime(); }
        }


        private DateTime start;
        [Required]
        public DateTime Start
        {
            get { return start; }
            set { start = value.ToLocalTime(); }
        }

    }

    public class ToDosGetDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
