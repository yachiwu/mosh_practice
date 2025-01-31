﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mosh_practice.Models.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //iterate all the membership type
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                {
                    return "Edit Customer";
                }
                else
                {
                    return "New Customer";
                }
            }
        }

    }
}