using AATM.Contracts.Dtos;

namespace AATM.DataAccess
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeLookupDto>> GetEmployeesLookupAsync();
        // Add other signatures as needed, e.g.:
        // Task<EmployeeDto> GetEmployeeByIdAsync(int idNo);
        // Task<List<EmployeeDto>> GetAllEmployeesAsync();
        // etc.
    }
}   