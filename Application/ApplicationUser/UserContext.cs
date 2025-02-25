using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.CarWorkshop;
using Microsoft.AspNetCore.Http;

namespace Application.ApplicationUser
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public CurrentUser? GetCurrentUser()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("User is not present");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var id = user.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(u => u.Type == ClaimTypes.Email)!.Value;

            var currentUser = new CurrentUser(id, email);
            return currentUser;

        }
    }
}
