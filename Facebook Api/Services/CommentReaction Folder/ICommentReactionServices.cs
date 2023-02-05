using Facebook_Api.DTOS.CommentDtos;
using Facebook_Api.DTOS.CommentReactionDto;
using Facebook_Api.Models;

namespace Facebook_Api.Services.CommentReaction_Folder
{
    public interface ICommentReactionServices
    {
      Task<ServicesRespone<GetCommentReactionsDto>>AddCommentReact( int PostId,int CommentId, Reaction react );
      Task<ServicesRespone<String>> DeleteCommentReact(int PostId, int CommentId);
        Task<ServicesRespone< List<GetCommentReactionsDto>>> ShowAllCommentReaction(int CommentId);



    }
}
