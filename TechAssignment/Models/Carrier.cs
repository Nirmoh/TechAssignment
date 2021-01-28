using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechAssignment.Models
{
    public class Carrier
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string BussinessName { get; set; }

        [Display(Name = "Address")]
        public string BussinessAddress { get; set; }

        [Display(Name = "Phone Number")]
        public string BussinessPhoneNumber { get; set; }

        public Carrier()
        {
            this.MGAs = new List<MGA>();
        }

        public virtual ICollection<MGA> MGAs { get; set; }
    }
}