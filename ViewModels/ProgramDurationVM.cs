using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;

namespace Project.ViewModels
{
    public class ProgramDurationVM
    {
        public IList<Programs> Programs { get; set; }
        public SelectList Durations { get; set; }
        public string ProgramDuration { get; set; }
        public string SearchString { get; set; }
    }
}
