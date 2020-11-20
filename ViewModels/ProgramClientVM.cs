using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class ProgramClientVM
    {
        public Programs Program { get; set; }
        public IEnumerable<int> SelectedClients { get; set; }
        public IEnumerable<SelectListItem> ClientsList { get; set; }
    }
}

