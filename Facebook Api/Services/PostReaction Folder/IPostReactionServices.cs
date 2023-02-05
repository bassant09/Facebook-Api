using Facebook_Api.DTOS.CommentReactionDto;
using Facebook_Api.DTOS.PostReactions_Dtos;
using Facebook_Api.Models;

namespace Facebook_Api.Services.PostReaction_Folder
{
    public interface IPostReactionServices
    {
        Task<ServicesRespone<GetPostReactionDto>> AddPostReact(int PostId, Reaction react);
        Task<ServicesRespone<String>> DeletePostReact(int PostId);
        Task<ServicesRespone<List<GetPostReactionDto>>> ShowAllPostReaction(int PostId);
    }
}
