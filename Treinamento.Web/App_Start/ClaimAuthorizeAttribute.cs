using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Treinamento.Web
{
    public class ClaimAuthorizeAttribute : AuthorizeAttribute
    {
        private string _claim;

        public ClaimAuthorizeAttribute(string claim)
        {
            _claim = claim;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var claims = httpContext.User.Identity as ClaimsIdentity;

            return claims.Claims.Any(c => c.Type == _claim);
        }
    }
}