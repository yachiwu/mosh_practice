﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mosh_practice.Models
{
    public class Customer
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage ="Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsLetter { get; set; }
        
        
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
       
        [Display(Name ="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime Birthdate { get; set; } //這邊應該要寫datatime? 把它設為可以選填的欄位
    }
}