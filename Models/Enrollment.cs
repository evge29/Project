using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Enrollment
    {
        [Key]
        public int Id
        {
            get;
            set;
        }
        [Display(Name = "Program")]
        public int ProgramId
        {
            get;
            set;
        }
        public Programs Program
        {
            get;
            set;
        }

        [Display(Name = "Client")]
        public int ClientId
        {
            get;
            set;
        }
        public Clients Client
        {
            get;
            set;
        }

        public int InitialWeight
        {
            get;
            set;
        }

        public int FinalWeight
        {
            get;
            set;
        }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Finish Date")]
        public DateTime FinishDate
        {
            get;
            set;
        }
    }
}
