using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using static ClinicaVet.GestaoVeterinaria.Extensions.CustomControllerAuthorization;

namespace ClinicaVet.GestaoVeterinaria.Extensions
{
    public class CustomControllerAuthorization
    {
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName);
        }

    }

    public class ClaimsControllerAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsControllerAuthorizeAttribute(string claimName) : base(typeof(RequiredClaimControllerFilter))
        {
            Arguments = new object[] { claimName };
        }
    }

    public class RequiredClaimControllerFilter : IAuthorizationFilter
    {
        private readonly string _claimName;

        public RequiredClaimControllerFilter(string claimName)
        {
            _claimName = claimName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "Identity", page = "/Account/Login", ReturnUrl = context.HttpContext.Request.Path.ToString() }));
                return;
            }

            if (!CustomControllerAuthorization.ValidarClaimsUsuario(context.HttpContext, _claimName))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
