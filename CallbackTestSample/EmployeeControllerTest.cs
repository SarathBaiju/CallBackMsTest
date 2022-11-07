using CallBackMsTest.Controllers;
using CallBackMsTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CallbackTestSample
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private Mock<IEmployeeService> _mockEmployeeService;
        private EmployeeController _employeeController;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockEmployeeService = new Mock<IEmployeeService>();
            _employeeController = new EmployeeController(_mockEmployeeService.Object);
        }

        [TestMethod]
        public async Task Get()
        {
            _mockEmployeeService.Setup(m => m.GetEmployeeById(It.IsAny<int>())).ReturnsAsync(new EmployeeDto()).Callback<int>(data =>
            {
                Assert.AreEqual(data, 20);
            });

            var result = await _employeeController.Get(20);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Post()
        {
            _mockEmployeeService.Setup(m => m.InsertEmployee(It.IsAny<EmployeeDto>())).ReturnsAsync(true).Callback<EmployeeDto>(data =>
            {
                Assert.AreEqual(data.Id, 1);
                Assert.AreEqual(data.Name, "sarath");
            });

            var result = await _employeeController.Post(new EmployeeDto
            {
                Id = 1,
                Name = "sarath"
            });

            Assert.IsNotNull(result);
        }
    }
}
