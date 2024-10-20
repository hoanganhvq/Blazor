using Blazor.Repositories;
using Blazor.Models;
using Microsoft.AspNetCore.Components;

public class EditBase : ComponentBase
{
    public Employee staff { get; set; } = new Employee();
    [Inject]
    public IStaffRepository staffRepository { get; set; }

    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        staff = await staffRepository.GetStaff(int.Parse(Id)); // Fetch the employee
    }

    // Method to handle the form submission
    protected async Task UpdateStaff()
    {

        // Call the EditStaff method from the repository
        await staffRepository.EditStaff(staff.EmployeeId,staff.FirstName, staff.LastName, staff.Email);
    }
}
