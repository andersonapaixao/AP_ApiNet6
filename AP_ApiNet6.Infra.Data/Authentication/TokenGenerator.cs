using AP_ApiNet6.Domain.Authentication;
using AP_ApiNet6.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Infra.Data.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public dynamic Generator(User user)
        {
            var permission = string.Join(",", user.UserPermissions.Select(x => x.Permission?.PermissionName));

            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("ID", user.Id.ToString()),
                new Claim("Permissoes", permission)
            };

            var expires = DateTime.Now.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("projetoDotNetCore6"));
            var tokenDat = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDat);
            return new
            {
                acess_token = token,
                expirations = expires
            };
        }
    }
}
