using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;

namespace Facebook_Api.Services.Post_Folder
{
    public interface IPostServices
    {
        Task<ServicesRespone<List<GetPostDto>>> GetAllPosts();
        Task<ServicesRespone<GetPostDto>> AddPost(AddPostDto post );
        Task<ServicesRespone<List<GetPostDto>>> DeletePost(int? Id);
        Task<ServicesRespone<GetPostDto>> EditPost(EditPostDto post);
    }
}
