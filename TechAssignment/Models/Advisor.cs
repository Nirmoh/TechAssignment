using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechAssignment.Models
{
    public class Advisor
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Health Status")]
        public HealthStatus HealthStatus { get; set; }

        public Advisor()
        {
            this.MGAs = new List<MGA>();
        }

        public virtual ICollection<MGA> MGAs { get; set; }
    }

    public enum HealthStatus
    {
        Green,
        Red
    }
}
