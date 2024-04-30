using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasksprintbe.Models
{
    public class CommentModel
    {
        public int ID { get; set; }

        public string? Username { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? Date { get; set; }

        public string? Time { get; set; }

        public bool IsDeleted { get; set; }

        public CommentModel()
        {

        }

    }
}