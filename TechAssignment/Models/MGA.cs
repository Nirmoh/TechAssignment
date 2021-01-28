using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechAssignment.Models
{
    public class MGA
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string BussinessName { get; set; }

        [Display(Name = "Address")]
        public string BussinessAddress { get; set; }

        [Display(Name = "Phone Number")]
        public string BussinessPhoneNumber { get; set; }

        public MGA()
        {
            this.Carriers = new List<Carrier>();
            this.Advisors = new List<Advisor>();
        }

        public virtual ICollection<Carrier> Carriers { get; set; }
        public virtual ICollection<Advisor> Advisors { get; set; }
    }
}
