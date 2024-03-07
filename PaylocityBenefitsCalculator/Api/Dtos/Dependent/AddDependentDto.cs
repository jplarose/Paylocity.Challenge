﻿using Api.Models;

namespace Api.Dtos.Dependent
{
    public class AddDependentDto
    {
        public int DependentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Relationship Relationship { get; set; }
        public int EmployeeId { get; set; }
    }
}
