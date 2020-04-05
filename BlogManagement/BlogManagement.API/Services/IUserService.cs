using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.API.Models.ResultModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BlogManagement.API.Services
{
    public interface IUserService
    {
        Task<LoginResultModel> Authenticate(string UserName, string Pass);
    }

    public class UserService : IUserService
    {
        private readonly Data.Repositories.RepoWrappers.IRepoWrapper _repoWrapper;
        private readonly Models.AppSettings _appSettings;
        public UserService(Data.Repositories.RepoWrappers.IRepoWrapper repoWrapper, IOptions<Models.AppSettings> appSettings)
        {
            _repoWrapper = repoWrapper;
            _appSettings = appSettings.Value;
            
        }

        public async Task<LoginResultModel> Authenticate(string UserName, string Pass)
        {
            var userInfo = await _repoWrapper.Author.GetByCredentials(UserName, Pass);

            if (userInfo == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);


            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, userInfo.Id.ToString()),
                    new Claim("authorname",userInfo.AuthorName),
                    new Claim("authorid", userInfo.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDecriptor);

            userInfo.Password = null;

            var loginResult= new LoginResultModel {
                 Author = userInfo,
                  Token = tokenHandler.WriteToken(token)
            };
            return loginResult;
        }
    }
}
