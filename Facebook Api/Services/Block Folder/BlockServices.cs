using AutoMapper;
using Facebook_Api.Data;
using Facebook_Api.DTOS.BlockDto;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Facebook_Api.Services.Block_Folder
{
    public class BlockServices : IBlockServices
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        IHttpContextAccessor _httpContextAccessor;
        public BlockServices(DataContext db,IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        private int GetUserId()
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.
                FindFirstValue(ClaimTypes.NameIdentifier));
            return userId;
        }
        public async Task<ServicesRespone< List< GetBlockDto>>> AddBlock(int UserId)
        {
            var respone = new ServicesRespone< List< GetBlockDto>>();
            var block = new Block();
            var user2 = _db.Users.FirstOrDefault(e => e.Id == UserId); 
            var user1=_db.Users.FirstOrDefault(e => e.Id ==GetUserId());
            if (user2 == null)
            {
                respone.Success = false;
                respone.Message = "User Not Found";
                return respone;
            }
            block.User1 = user1;
            block.User2 = user2; 
            _db.Blocks.Add(block);
            _db.Friends.Remove( _mapper.Map<Friend>(block)); 
           await  _db.SaveChangesAsync();
            var Block =  _db.Blocks.Where(e => e.UserId1 == GetUserId());
            respone.Data = Block.Select(c => _mapper.Map<GetBlockDto>(c)).ToList();
            return respone;

        }

        public async Task<ServicesRespone<List<GetBlockDto>>> ShowBlockList()
        {
            var respone = new ServicesRespone<List<GetBlockDto>>();
            var Block = _db.Blocks.Include(e=>e.User2).Where(e => e.UserId1 == GetUserId());
            respone.Data = Block.Select(c => _mapper.Map<GetBlockDto>(c)).ToList();
            return respone; 
        }

        public async Task<ServicesRespone<string>> UnBlock(int UserId)
        {
            var respone = new ServicesRespone<string>();
            var block = new Block();
            var user2 = _db.Users.FirstOrDefault(e => e.Id == UserId);
            var user1 = _db.Users.FirstOrDefault(e => e.Id == GetUserId());
            if (user2 == null)
            {
                respone.Success = false;
                respone.Message = "User Not Found";
                return respone;
            }
            block.User1 = user1; 
            block.User2 = user2;
            _db.Blocks.Remove(block);
           await _db.SaveChangesAsync();
            respone.Data = "Block Removed Successfully";
            return respone; 
        }
    }
}
