using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasksprintbe.Models
{
    public class MemberModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int BoardID { get; set; }

        internal bool Any()
        {
            throw new NotImplementedException();
        }
    }
}