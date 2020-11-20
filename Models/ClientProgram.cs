using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ClientProgram
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Clients Client { get; set; }
        public int ProgramId { get; set; }
        public Programs Program { get; set; }
    }
}
