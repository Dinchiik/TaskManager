﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class TaskItem
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Title {  get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId {  get; set; }

    }
}
