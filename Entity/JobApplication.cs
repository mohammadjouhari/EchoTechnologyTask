using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class JobApplication : BaseEntity
    {
        public string Name { get; set; }

        public DateTime DateOfBith { get; set; }

        public string ProfileImage { get; set; }

        public string Expereince { get; set; }
    }
}
