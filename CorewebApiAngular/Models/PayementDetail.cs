﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorewebApiAngular.Models
{
    public class PayementDetail
    {
        [Key]
        public int PMId { get; set; }
        [Required]
        public string CardOwnerName { get; set; }
        [Required]
        public  string CardNumber { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        public string CVV { get; set; }
    }
}
