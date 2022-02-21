﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.UserAddress
{
    public class AddressPostModel
    {
        
        [Required]
        public string Type { get; set; }

        [Required]
        
        public string Address { get; set; }
        [Required]
        
        public string City { get; set; }
        [Required]
      
        public string State { get; set; }
    }
}
