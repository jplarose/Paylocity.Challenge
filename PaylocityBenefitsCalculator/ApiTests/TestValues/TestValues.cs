using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using System;
using System.Collections.Generic;

namespace ApiTests.TestValues
{
    /// <summary>
    /// Move test values to a static class to make them available across multiple tests
    /// </summary>
    internal static class TestValues
    {
        /// <summary>
        /// List of employees to be synced with expected response from in-memory repository
        /// </summary>
        internal static List<GetEmployeeDto> EmployeeList => new List<GetEmployeeDto>
        {
            new()
            {
                EmployeeId = 1,
                FirstName = "LeBron",
                LastName = "James",
                Salary = 75420.99m,
                DateOfBirth = new DateTime(1984, 12, 30)
            },
            new()
            {
                EmployeeId = 2,
                FirstName = "Ja",
                LastName = "Morant",
                Salary = 92365.22m,
                DateOfBirth = new DateTime(1999, 8, 10),
                Dependents = new List<GetDependentDto>
                {
                    new()
                    {
                        DependentId = 1,
                        FirstName = "Spouse",
                        LastName = "Morant",
                        Relationship = Relationship.Spouse,
                        DateOfBirth = new DateTime(1998, 3, 3)
                    },
                    new()
                    {
                        DependentId = 2,
                        FirstName = "Child1",
                        LastName = "Morant",
                        Relationship = Relationship.Child,
                        DateOfBirth = new DateTime(2020, 6, 23)
                    },
                    new()
                    {
                        DependentId = 3,
                        FirstName = "Child2",
                        LastName = "Morant",
                        Relationship = Relationship.Child,
                        DateOfBirth = new DateTime(2021, 5, 18)
                    }
                }
            },
            new()
            {
                EmployeeId = 3,
                FirstName = "Michael",
                LastName = "Jordan",
                Salary = 143211.12m,
                DateOfBirth = new DateTime(1963, 2, 17),
                Dependents = new List<GetDependentDto>
                {
                    new()
                    {
                        DependentId = 4,
                        FirstName = "DP",
                        LastName = "Jordan",
                        Relationship = Relationship.DomesticPartner,
                        DateOfBirth = new DateTime(1974, 1, 2)
                    }
                }
            }
        };

        /// <summary>
        /// Employee with no dependents and a salary below $80k
        /// </summary>
        internal static Employee Employee1 => new Employee
        {
            EmployeeId = 1,
            FirstName = "Guy",
            LastName = "Mann",
            Salary = 70000m,
            DateOfBirth = new DateTime(1980, 5, 5)
        };

        /// <summary>
        /// Employee with no dependents and a salary above $80k
        /// </summary>
        internal static Employee Employee2 => new Employee
        {
            EmployeeId = 2,
            FirstName = "Guy",
            LastName = "Mann",
            Salary = 90000m,
            DateOfBirth = new DateTime(1980, 5, 5)
        };

        /// <summary>
        /// Employee with 2 dependents and a salary below $80k
        /// </summary>
        internal static Employee Employee3 => new Employee
        {
            EmployeeId = 3,
            FirstName = "Guy",
            LastName = "Mann",
            Salary = 70000m,
            DateOfBirth = new DateTime(1980, 5, 5),
            Dependents = new List<Dependent>
            {
                new()
                {
                    DependentId = 1,
                    DateOfBirth = new DateTime(1995, 7, 9)
                },
                new()
                {
                    DependentId = 2,
                    DateOfBirth = new DateTime(1995, 7, 9)
                }
            }
        };

        /// <summary>
        /// Employee with 2 dependents and a salary above $80k
        /// </summary>
        internal static Employee Employee4 => new Employee
        {
            EmployeeId = 4,
            FirstName = "Guy",
            LastName = "Mann",
            Salary = 90000m,
            DateOfBirth = new DateTime(1980, 5, 5),
            Dependents = new List<Dependent>
            {
                new()
                {
                    DependentId = 1,
                    DateOfBirth = new DateTime(1995, 7, 9)
                },
                new()
                {
                    DependentId = 2,
                    DateOfBirth = new DateTime(1995, 7, 9)
                }
            }
        };

        /// <summary>
        /// Employee with 2 dependents over 50 and a salary above $80k
        /// </summary>
        internal static Employee Employee5 => new Employee
        {
            EmployeeId = 5,
            FirstName = "Guy",
            LastName = "Mann",
            Salary = 90000m,
            DateOfBirth = new DateTime(1980, 5, 5),
            Dependents = new List<Dependent>
            {
                new()
                {
                    DependentId = 1,
                    DateOfBirth = new DateTime(1965, 7, 9)
                },
                new()
                {
                    DependentId = 2,
                    DateOfBirth = new DateTime(1965, 7, 9)
                }
            }
        };

        internal static Paycheck? Employee1Paycheck => new Paycheck
        {
            EmployeeId = 1,
            NumberOfDependents = 0,
            GrossAmount = 2692.31m,
            NetAmount = 2230.77m,
            Deductions = 461.54m
        };

        internal static Paycheck? Employee2Paycheck => new Paycheck
        {
            EmployeeId = 2,
            NumberOfDependents = 0,
            GrossAmount = 3461.54m,
            NetAmount = 2930.77m,
            Deductions = 530.77m
        };

        internal static Paycheck? Employee3Paycheck => new Paycheck
        {
            EmployeeId = 3,
            NumberOfDependents = 2,
            GrossAmount = 2692.31m,
            NetAmount = 1676.93m,
            Deductions = 1015.38m
        };

        internal static Paycheck? Employee4Paycheck => new Paycheck
        {
            EmployeeId = 4,
            NumberOfDependents = 2,
            GrossAmount = 3461.54m,
            NetAmount = 2376.92m,
            Deductions = 1084.62m
        };

        internal static Paycheck? Employee5Paycheck => new Paycheck
        {
            EmployeeId = 5,
            NumberOfDependents = 2,
            GrossAmount = 3461.54m,
            NetAmount = 2192.31m,
            Deductions = 1269.23m
        };

        /// <summary>
        /// Populated dependent list that includes a spouse
        /// </summary>
        internal static List<Dependent> PopulatedDependent => new List<Dependent>
        {
            new Dependent
            {
                DependentId = 1,
                EmployeeId = 1,
                Relationship = Relationship.Spouse
            }
        };
    }
}
