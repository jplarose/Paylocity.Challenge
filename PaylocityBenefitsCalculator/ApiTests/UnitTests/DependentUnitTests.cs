using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using System.Threading.Tasks;
using Xunit;
using Api.DataAccess;
using Api.Services;
using Api.Models;

using static ApiTests.TestValues.TestValues;

namespace ApiTests.UnitTests
{
    public class DependentUnitTests
    {
        IDependentService dependentService;

        public DependentUnitTests()
        {
            var dependentRepo = new Mock<IDependentRepository>();

            // If it passes business logic mock a successful response
            dependentRepo.Setup(x => x.AddDependent(It.IsAny<Dependent>())).ReturnsAsync(true);

            // Does not contain an existing Spouse or Domestic Partner
            dependentRepo.Setup(x => x.GetDependents(1)).ReturnsAsync(new List<Dependent>());

            // Return a populated Dependent
            dependentRepo.Setup(x => x.GetDependents(2)).ReturnsAsync(PopulatedDependent);

            dependentService = new DependentService(dependentRepo.Object);
        }

        [Fact]
        public async Task AddANewChildOrSpouseOrDomesticPartner_ReturnsSuccess()
        {
            // Arrange
            var dependent = new Dependent
            {
                // Employee 1 does not have an existing spouse
                EmployeeId = 1,
                DependentId = 1,
                Relationship = Relationship.Spouse
            };

            var childDependent = new Dependent
            {
                // Employee 2 has a spouse, but can add children
                EmployeeId = 2,
                DependentId = 2,
                Relationship = Relationship.Child
            };

            // Act
            var spouseResponse = await dependentService.AddDependent(dependent);
            var childResponse = await dependentService.AddDependent(childDependent);

            // Assert
            Assert.True(spouseResponse);
            Assert.True(childResponse);
        }

        [Fact]
        public async Task AddNewSpouseOrDomesticPartner_AlreadyExists()
        {
            // Arrange
            var spouseDependent = new Dependent
            {
                EmployeeId = 2,
                DependentId = 2,
                Relationship = Relationship.Spouse
            };

            var domesticPartnerDependent = new Dependent
            {
                EmployeeId = 2,
                DependentId = 2,
                Relationship = Relationship.DomesticPartner
            };

            // Act
            var spouseResponse = await dependentService.AddDependent(spouseDependent);
            var domesticPartnerResponse = await dependentService.AddDependent(domesticPartnerDependent);

            // Assert
            Assert.False(spouseResponse);
            Assert.False(domesticPartnerResponse);



        }
    }
}
