using System.Security.Claims;

namespace WebMVC.Extensions
{
	public static class ClaimExtencion
	{
		public static string GetUserName(this IEnumerable<Claim> claims)
		{
			var claim = claims.FirstOrDefault(claim=>claim.Type==ClaimTypes.Name)!.Value;

			return claim ?? string.Empty;
		}
		public static string GetUserID(this IEnumerable<Claim> claims)
		{
			var claim = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)!.Value;
			return claim ?? string.Empty;
		}
        public static string GetSpecificClaim(this ClaimsIdentity claimsIdentity, string claimType)
        {
            var claim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == claimType);

            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
