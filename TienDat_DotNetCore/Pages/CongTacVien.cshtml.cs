using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TienDat_DotNetCore.Pages
{
    [Authorize (Policy = "CongTacVien")]
    public class CongTacVienModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
