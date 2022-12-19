using AutoMapper;
using Facebook_Api.Data;
using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Facebook_Api.Services.Authantication_Folder
{
    public class AuthanticationRepository : IAuthanticationRepository
    {
        private readonly DataContext _db;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthanticationRepository( DataContext dataContext, IConfiguration configuration,IMapper mapper)
        {
            _db = dataContext;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<ServicesRespone<string>> Login(string Email, string Password)
        {
            var respone = new ServicesRespone<string>();
            var user = await _db.Users.FirstOrDefaultAsync(e => e.Email==Email);
            if (user == null )
            {
                respone.Success = false;
                respone.Message = "Email  not found ."; 
            }
            else if (!VerifyPassword(Password, user.PasswordHash, user.PasswordSalt))
            {
                respone.Success=false;
                respone.Message = "Incorrect Password .";
            }
            else
            {
                respone.Success=true;
                respone.Data = CreateToken(user);

            }
            return respone; 
        }

        public async Task<ServicesRespone<int>> Register(User user, string Password)
        {
            var respone = new ServicesRespone<int>();
            if (await UserExist(user.UserName))
            {
                respone.Success = false;
                respone.Message = "User is already exists.";
                return respone;


            }
            CreatePasswordHash(Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt=passwordSalt;
            _db.Users.Add(user); 
          await  _db.SaveChangesAsync();
            respone.Data = user.Id;
            return respone; 

        }

        public async Task<bool> UserExist(string Username)
        {
            if (await _db.Users.AnyAsync(e => e.UserName == Username))
            {
                return true;
            }
            return false;
        }
         private void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                 new Claim(ClaimTypes.NameIdentifier, user.Email)

        };
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                GetBytes(_configuration.GetSection("AppSetting:Token").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds

            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public  async Task<ServicesRespone<UserGetDto>> UpdateProfile(UserUpdateDto user)
        {
            var respone=new ServicesRespone<UserGetDto>();
            var OldUserInfo =_db.Users.FirstOrDefault(e=>e.Id==user.Id);
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            OldUserInfo.PasswordHash = passwordHash;
            OldUserInfo.PasswordSalt = passwordSalt;
            OldUserInfo.Address = user.Address;
            _mapper.Map(user, OldUserInfo);
            
            _db.Users.Update(OldUserInfo);
            await _db.SaveChangesAsync();
            respone.Data = _mapper.Map<UserGetDto>(OldUserInfo);
            return respone;
            //respone.Data = _mapper.Map<GetPostDto>(OldPost);


        }
    }
}
