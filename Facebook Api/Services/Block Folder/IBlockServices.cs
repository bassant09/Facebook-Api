using Facebook_Api.DTOS.BlockDto;
using Facebook_Api.DTOS.FriendDtos;
using Facebook_Api.Models;

namespace Facebook_Api.Services.Block_Folder
{
    public interface IBlockServices
    {
        Task<ServicesRespone< List< GetBlockDto>>> AddBlock(int UserId);
        Task<ServicesRespone<List<GetBlockDto>>> ShowBlockList();
        Task<ServicesRespone<String>> UnBlock(int UserId);

    }
}
