using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Programs
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        [Required]
        [StringLength(100)]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [StringLength(100)]
        public string Payment
        {
            get;
            set;
        }

        [Required]
        [StringLength(100)]
        public string Duration
        {
            get;
            set;
        }


        [Display(Name = "Coach")]
        public int? CoachId
        {
            get;
            set;
        }
        [Display(Name = "Coach")]
        public Coaches Coach
        {
            get;
            set;
        }

        public ICollection<Enrollment> Enrollments
        {
            get;
            set;
        }
    }
}
