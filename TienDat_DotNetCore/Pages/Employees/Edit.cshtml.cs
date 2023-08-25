using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TienDat_DotNetCore.Data;
using TienDat_DotNetCore.Models.ViewModels;

namespace TienDat_DotNetCore.Pages.Employees
{
    [Authorize(Policy = "AdminOnly")]
    public class EditModel : PageModel
    {
        private readonly RazorPagesDB dBcontext;
        [BindProperty]
        public EditEmployeeViewModel EditEmployeeViewModel { get; set; }
        public EditModel(RazorPagesDB DBcontext)
        {
            this.dBcontext = DBcontext;
        }
        public void OnGet(Guid id)
        {
            var employee = dBcontext.Employees.Find(id);
            if (employee != null)
            {
                //chuyển domain model sang view model
                EditEmployeeViewModel = new EditEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Email = employee.Email,
                    Department = employee.Department,
                };
            }
        }
        public void OnPostUpdate()
        {
            if (EditEmployeeViewModel != null)
            {
                var existingEmployee = dBcontext.Employees.Find(EditEmployeeViewModel.Id);
                if (existingEmployee != null)
                {
                    // chuyển view model sang domain model
                    existingEmployee.Id = EditEmployeeViewModel.Id;
                    existingEmployee.Name = EditEmployeeViewModel.Name;
                    existingEmployee.Salary = EditEmployeeViewModel.Salary;
                    existingEmployee.Email = EditEmployeeViewModel.Email;
                    existingEmployee.Department = EditEmployeeViewModel.Department;
                    dBcontext.SaveChanges();
                    ViewData["Message"] = "Sửa thông tin thành công!";
                }
            }

        }
        public IActionResult OnPostDelete()
        {
            var existingEmployee = dBcontext.Employees.Find(EditEmployeeViewModel.Id);
            if (existingEmployee != null)
            {
                dBcontext.Employees.Remove(existingEmployee);
                dBcontext.SaveChanges();
                return RedirectToPage("/Employees/List");
            }
            return Page();
        }
    }
}
