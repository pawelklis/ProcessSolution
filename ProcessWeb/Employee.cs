using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

    public class Employee 
    {
        public int EmployeeId { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public string Gender { get; set; }
        [Required] 
        public string Department { get; set; }
        [Required]
        public string City { get; set; }

    public Address Address { get; set; }

        public List<EmployeeDetails> Details { get; set; }
        
    public Employee()
    {
        Details = new List<EmployeeDetails>();
    }

        
    }
