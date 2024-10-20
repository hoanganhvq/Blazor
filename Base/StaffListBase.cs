using Microsoft.AspNetCore.Components;
using Blazor.Repositories;
using Blazor.Models;

namespace Blazor.Base;

public class StaffListBase : ComponentBase
{
    [Inject]
    public IStaffRepository staffRepository { get; set; }

    public IEnumerable<Employee> staffs { get; set; }

    protected override async Task OnInitializedAsync()
    {
        staffs = await staffRepository.GetAllStaff();
    }
    protected async Task DeleteStaff(int Id)
    {
        await staffRepository.DeleteStaff(Id);
        await InvokeAsync(StateHasChanged);


        //staffs = await staffRepository.GetAllStaff();

    }
}
