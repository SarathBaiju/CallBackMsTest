using System.Threading.Tasks;

namespace CallBackMsTest.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<bool> InsertEmployee(EmployeeDto employee);
    }

}
