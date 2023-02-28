using Lubes.DBContext;
using Microsoft.IdentityModel.Tokens;
using SHOP.Models;
using SHOP_DECOMPILED.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_DECOMPILED
{
   
        public class TokenProvider_admin
        {
            ApplicationDBContext _context;

            public TokenProvider_admin(ApplicationDBContext context)
            {
                _context = context;
            }
            public string LoginUser(int id, string password)
            {
                string pass = password;
                var user_1 = _context.System_users.SingleOrDefault(x => x.National_id == id && x.Password == password);

                //Authenticate User, Check if its a registered user in DB  - JRozario
                if (user_1 == null)
                    return null;

                var key = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");
                var JWToken = new JwtSecurityToken(
              issuer: "",
              audience: "",
              claims: GetUserClaims(user_1),
              notBefore: new DateTimeOffset(DateTime.Now).DateTime,
              expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                //var strusername = user.Email;
                return token;

            }
            private IEnumerable<Claim> GetUserClaims(System_users user)
            {
                List<Claim> claims = new List<Claim>();
                Claim _claim;
             
                _claim = new Claim(ClaimTypes.Role, user.Roles.ToString());
                claims.Add(_claim); 
                _claim = new Claim(ClaimTypes.Name, user.Roles.ToString());
                claims.Add(_claim);
                //_claim = new Claim("User_id", user.User_ID.ToString());
                claims.Add(_claim);
                return claims.AsEnumerable<Claim>();
            }
        }
    }


