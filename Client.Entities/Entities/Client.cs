using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entities.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string IdentificationCard  { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
