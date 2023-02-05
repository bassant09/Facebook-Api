using Facebook_Api.Controllers;
using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.DTOS.CommentDtos;
using Facebook_Api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facebook_Api.DTOS.CommentReactionDto
{
    public class GetCommentReactionsDto
    {
     public Reaction Reaction { get; set; } = Reaction.Angry;
        public UserGetDto User { get; set; }
        public GetCommentsDto Comment { get; set; }
    }
}
