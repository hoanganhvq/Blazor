using Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly StaffsContext staffsContext;

        public StaffRepository(StaffsContext staffsContext)
        {
            this.staffsContext = staffsContext;
        }

        public Task<Employee> GetStaff(int id)
        {
            return staffsContext.Employees.FirstOrDefaultAsync(staff => staff.EmployeeId == id);
        }

        public async Task<IEnumerable<Employee>> GetAllStaff()
        {
            return await staffsContext.Employees.ToListAsync(); // Ensure you convert to a list
        }

        public async Task EditStaff(int id, string firstname, string lastname, string email)
        {
            try
            {
                var updatedStaff = await staffsContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
                if (updatedStaff == null)
                {
                    Console.WriteLine("No data found");
                    return;
                }

                updatedStaff.FirstName = firstname;
                updatedStaff.LastName = lastname;
                updatedStaff.Email = email;

                // Optional: Force the entity state to modified
                staffsContext.Entry(updatedStaff).State = EntityState.Modified;

                await staffsContext.SaveChangesAsync(); // Ensure changes are saved
                Console.WriteLine("Everything is updated");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error updating database: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        public async Task DeleteStaff(int id)
        {
            var staff = await GetStaff(id);
            staffsContext.Employees.Remove(staff);
            staffsContext.SaveChangesAsync();
            Console.WriteLine("Delete successfully");
        }

    }
}
