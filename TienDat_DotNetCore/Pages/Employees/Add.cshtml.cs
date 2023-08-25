using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TienDat_DotNetCore.Data;
using TienDat_DotNetCore.Models.ViewModels;
using TienDat_DotNetCore.Models.Domain;
using Microsoft.AspNetCore.Authorization;

namespace TienDat_DotNetCore.Pages.Employees
{
    [Authorize(Policy = "AdminOnly")]
    public class AddModel : PageModel
    {
        private readonly RazorPagesDB dBcontext;

        public AddModel(RazorPagesDB DBcontext)
        {
            this.dBcontext = DBcontext;
        }
        [BindProperty]
        public AddEmployeeViewModel AddEmployeeRequest { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            //chuyển viewmodel sang domainmodel
            var employeeDomainModel = new Employee
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary = AddEmployeeRequest.Salary,
                DateOfBirth = AddEmployeeRequest.DateOfBirth,
                Department = AddEmployeeRequest.Department,
            };
            dBcontext.Employees.Add(employeeDomainModel);
            dBcontext.SaveChanges();
            ViewData["Message"] = "Thêm nhân viên thành công!";
        }
    }
}
