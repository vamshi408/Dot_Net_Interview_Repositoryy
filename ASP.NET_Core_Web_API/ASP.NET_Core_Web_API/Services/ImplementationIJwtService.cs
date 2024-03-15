using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace ASP.NET_Core_Web_API.Services
{
    public class ImplementationIJwtService :IJwtService
    {
        private readonly string key;

        //Reading key at constructer level
        public ImplementationIJwtService(string key)
        {
            this.key = key;
        }

        //Instead of Database as of now we are using static credentials later we can switch to SQL/ORACLE/MONGO etc DB's 
        private readonly IDictionary<string, string> users = new Dictionary<string, string>()
        {
            {"user1","password1" },{ "user2","password2"}
        };

        //Authentcation implementation where we are generating encrypted token
        public string Authentication(string username, string password)
        {

            if (users.ContainsKey(username) && users[username] == password)
            {

                //Security Token Handler
                //SecurityTokenHandler designed for creating and validating Json Web Tokens
                var tokenHandler = new JwtSecurityTokenHandler();

                //Encoding key
                var tokenkey = Encoding.UTF8.GetBytes(key);

                //Security Token Descriptor
                //Contains some information which used to create a security token.
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //1. Claim
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, username),
                    }),


                    //2. Expires
                    //Gets & Sets the expire time of token
                    Expires = DateTime.UtcNow.AddHours(1),

                    //3. SigningCredentials --> sha 256 algorithm  
                    //Computes a sha256 hash over the Microsoft.IdentityModel.Tokens.SymmetricSecurityKey
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenkey),
                        SecurityAlgorithms.HmacSha256Signature
                        )
                };

                //Token generate
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            else
            {
                return null;
            }
        }
    }
}