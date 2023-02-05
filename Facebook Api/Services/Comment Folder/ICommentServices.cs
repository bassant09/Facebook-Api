using Facebook_Api.DTOS.CommentDtos;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;

namespace Facebook_Api.Services.Comment_Folder
{
    public interface ICommentServices
    {
        //Task<ServicesRespone<> AddComment();
        Task<ServicesRespone<List<GetCommentsDto>>> AddComment(AddCommentDto comment);
        Task<ServicesRespone<string>> DeleteComment(int Id,int PostId);
        Task<ServicesRespone<GetCommentsDto>> EditComment(EditCommentDto comment);


    }
}
