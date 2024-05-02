using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasksprintbe.Models
{
    public class TaskModel
    {
        public int ID { get; set; }

        public string? Username { get; set; }

        public string? Description { get; set; }

        public string? Title { get; set; }

        public string? DateCreated { get; set; }

        public string? AssignedTo { get; set; }

        public string? Status { get; set; }

        public string? Priority { get; set; }

        public bool IsDeleted { get; set; }

        public TaskModel()
        {

        }

    }
}