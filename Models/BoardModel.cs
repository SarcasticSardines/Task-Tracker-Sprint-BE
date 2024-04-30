using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasksprintbe.Models
{
    public class BoardModel
    {
        public int ID { get; set; }

        public string? BoardName { get; set; }

        public string? InviteCode { get; set; }

        public string? MemberList { get; set; }

        public bool IsDeleted { get; set; }

        public BoardModel()
        {

        }

    }
}