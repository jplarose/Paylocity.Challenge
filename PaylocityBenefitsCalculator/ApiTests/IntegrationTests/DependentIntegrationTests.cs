using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Dtos.Dependent;
using Api.Models;
using Xunit;
using System.Net.Http.Json;

namespace ApiTests.IntegrationTests;

public class DependentIntegrationTests : IntegrationTest
{
    [Fact]
    //task: make test pass
    public async Task WhenAskedForAllDependents_ShouldReturnAllDependents()
    {
        var response = await HttpClient.GetAsync("/api/v1/dependents");
        var dependents = new List<GetDependentDto>
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
            },
            new()
            {
                DependentId = 4,
                FirstName = "DP",
                LastName = "Jordan",
                Relationship = Relationship.DomesticPartner,
                DateOfBirth = new DateTime(1974, 1, 2)
            }
        };
        await response.ShouldReturn(HttpStatusCode.OK, dependents);
    }

    [Fact]
    //task: make test pass
    public async Task WhenAskedForADependent_ShouldReturnCorrectDependent()
    {
        var response = await HttpClient.GetAsync("/api/v1/dependents/1");
        var dependent = new GetDependentDto
        {
            DependentId = 1,
            FirstName = "Spouse",
            LastName = "Morant",
            Relationship = Relationship.Spouse,
            DateOfBirth = new DateTime(1998, 3, 3)
        };
        await response.ShouldReturn(HttpStatusCode.OK, dependent);
    }

    [Fact]
    //task: make test pass
    public async Task WhenAskedForANonexistentDependent_ShouldReturn404()
    {
        var response = await HttpClient.GetAsync($"/api/v1/dependents/{int.MinValue}");
        await response.ShouldReturn(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task WhenAddingADependent_ShouldReturn201()
    {
        var dependent = new AddDependentDto
        {
            DependentId = 5,
            FirstName = "Spouse",
            LastName = "Morant",
            Relationship = Relationship.Child,
            DateOfBirth = new DateTime(1998, 3, 3),
            EmployeeId = 2
        };

        JsonContent content = JsonContent.Create(dependent);

        var response = await HttpClient.PostAsync($"/api/v1/dependents", content);

        await response.ShouldReturn(HttpStatusCode.Created);
    }

    [Fact]
    public async Task WhenAddingSecondSpouseOrDomesticPartner_ShouldReturn400()
    {
        var dependent = new AddDependentDto
        {
            DependentId = 1,
            FirstName = "Spouse",
            LastName = "Morant",
            Relationship = Relationship.Spouse,
            DateOfBirth = new DateTime(1998, 3, 3),
            EmployeeId = 2
        };

        JsonContent content = JsonContent.Create(dependent);

        var response = await HttpClient.PostAsync($"/api/v1/dependents", content);

        await response.ShouldReturn(HttpStatusCode.BadRequest);
    }
}

