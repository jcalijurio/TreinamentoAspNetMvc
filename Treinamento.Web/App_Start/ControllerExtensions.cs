using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace Treinamento.Web
{
    public static class ControllerExtensions
    {
        public static TViewModel ToViewModel<TViewModel>(this object dto)
        {
            var vm = Activator.CreateInstance<TViewModel>();
            foreach (var prop in dto.GetType().GetProperties())
            {
                typeof(TViewModel).GetProperty(prop.Name).SetValue(vm, prop.GetValue(dto));
            }
            return vm;
        }
    }

    public static class ViewExtensions
    {
        public static bool VerificarAcesso(this HtmlHelper helper, string claim)
        {
            var claims = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;

            return claims.Claims.Any(c => c.Type == claim);
        }
    }
}