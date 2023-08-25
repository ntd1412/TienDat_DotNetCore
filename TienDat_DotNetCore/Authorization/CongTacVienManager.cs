using Microsoft.AspNetCore.Authorization;

namespace TienDat_DotNetCore.Authorization
{
    public class CongTacVienManager : IAuthorizationRequirement
    {
        public CongTacVienManager(int thoigianthamgia)
        {
            Thoigianthamgia = thoigianthamgia;
        }

        public int Thoigianthamgia { get; }
    }
    public class CongTacVienManagerHandler : AuthorizationHandler<CongTacVienManager>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CongTacVienManager requirement)
        {
            if (!context.User.HasClaim(x => x.Type == "NgayThamGia"))
                return Task.CompletedTask;

            var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "NgayThamGia").Value);
            var period = DateTime.Now - empDate;
            if (period.Days > 30 * requirement.Thoigianthamgia)
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
