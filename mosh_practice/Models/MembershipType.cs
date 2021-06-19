using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mosh_practice.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public int MyProperty { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
        [Required]
        public string Name { get; set; }

    }
}