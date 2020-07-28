﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePractice03.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool Fired { get; set; }
    }
    public enum Gender
    {
        female = 0,
        male = 1
    }
}
