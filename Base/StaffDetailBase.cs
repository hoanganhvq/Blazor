using Blazor.Repositories;
using Blazor.Models;
using Microsoft.AspNetCore.Components;


public class StaffDetailBase : ComponentBase
{
    public Employee staff { get; set; } = new Employee();

    [Inject]
    public IStaffRepository staffRepository { get; set; }

    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Id = Id ?? "1";
        staff = await staffRepository.GetStaff(int.Parse(Id));
    }

    protected async Task UpdateStaff()
    {

        // Call the EditStaff method from the repository
        await staffRepository.EditStaff(staff.EmployeeId, staff.FirstName, staff.LastName, staff.Email);
    }

    protected async Task DeleteStaff()
    {
        await staffRepository.DeleteStaff(int.Parse(Id)); 
    }
}
