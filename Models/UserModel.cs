using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasksprintbe.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public int JoinedDate { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Colors { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }

        public UserModel()
        {

        }

    }
}