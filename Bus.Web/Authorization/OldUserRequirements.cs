using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace Bus.Web.Authorization
{
    public class OldUserRequirements:IAuthorizationRequirement
    {
        public int _totalUserJoinedInMonth { get; }
        public OldUserRequirements(int totalUserJoinedInMonth)
        {
            _totalUserJoinedInMonth = totalUserJoinedInMonth;

        }
    }
    public class OldUserRequirementsHandler : AuthorizationHandler<OldUserRequirements>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OldUserRequirements requirement)
        {
            if (!context.User.HasClaim(x => x.Type == "EmployeeDate"))
            {
                return Task.CompletedTask;
            }
            var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmployeeDate").Value);
            var period = DateTime.Now - empDate;
            if (period.Days > 30 * requirement._totalUserJoinedInMonth)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
