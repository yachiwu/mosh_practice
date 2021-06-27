﻿using mosh_practice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mosh_practice.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public DateTime Birthdate { get; set; } //這邊應該要寫datatime? 把它設為可以選填的欄位
    }
}