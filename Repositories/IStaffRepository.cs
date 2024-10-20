using Blazor.Models;
namespace Blazor.Repositories;

public interface IStaffRepository
{
    //Task is async when working with databse and web service
    //IEnumerable is collection (in Examole. this is a collection of Employee)
    Task<IEnumerable<Employee>> GetAllStaff();
    Task<Employee> GetStaff(int id);
    Task EditStaff(int id, string firstname, string lastname, string email);
    Task DeleteStaff(int id);
}