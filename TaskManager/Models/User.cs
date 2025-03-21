﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public  class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
