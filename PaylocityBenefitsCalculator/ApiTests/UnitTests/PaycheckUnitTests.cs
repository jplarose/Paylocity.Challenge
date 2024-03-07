using Api.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

using static ApiTests.TestValues.TestValues;

namespace ApiTests.UnitTests
{
    public class PaycheckUnitTests
    {
        IPaycheckService paycheckService;

        public PaycheckUnitTests()
        {
            var employeeServiceMock = new Mock<IEmployeeService>();

            employeeServiceMock.Setup(x => x.GetEmployeeById(1)).ReturnsAsync(Employee1);
            employeeServiceMock.Setup(x => x.GetEmployeeById(2)).ReturnsAsync(Employee2);
            employeeServiceMock.Setup(x => x.GetEmployeeById(3)).ReturnsAsync(Employee3);
            employeeServiceMock.Setup(x => x.GetEmployeeById(4)).ReturnsAsync(Employee4);
            employeeServiceMock.Setup(x => x.GetEmployeeById(5)).ReturnsAsync(Employee5);

            // Return a not found employee
            employeeServiceMock.Setup(x => x.GetEmployeeById(6)).ReturnsAsync((Api.Models.Employee?)null);

            paycheckService = new PaycheckService(employeeServiceMock.Object);
        }

        [Fact]
        public async Task CalculatePaycheckSuccess()
        {
            // Act
            var paycheckResponse1 = await paycheckService.GetEmployeePaycheck(1);
            var paycheckResponse2 = await paycheckService.GetEmployeePaycheck(2);
            var paycheckResponse3 = await paycheckService.GetEmployeePaycheck(3);
            var paycheckResponse4 = await paycheckService.GetEmployeePaycheck(4);
            var paycheckResponse5 = await paycheckService.GetEmployeePaycheck(5);

            // Assert
            Assert.Equivalent(Employee1Paycheck, paycheckResponse1);
            Assert.Equivalent(Employee2Paycheck, paycheckResponse2);
            Assert.Equivalent(Employee3Paycheck, paycheckResponse3);
            Assert.Equivalent(Employee4Paycheck, paycheckResponse4);
            Assert.Equivalent(Employee5Paycheck, paycheckResponse5);
        }

        [Fact]
        public async Task CalculatePaycheck_EmployeeDoesNotExist()
        {
            // Act
            var paycheckResponse = await paycheckService.GetEmployeePaycheck(6);

            // Assert
            Assert.Null(paycheckResponse);
        }


    }
}
