using AutoMapper;
using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.DTOS.BlockDto;
using Facebook_Api.DTOS.CommentDtos;
using Facebook_Api.DTOS.CommentReactionDto;
using Facebook_Api.DTOS.FriendDtos;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.DTOS.PostReactions_Dtos;
using Facebook_Api.Models;

namespace Facebook_Api
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, GetPostDto>().ReverseMap();
            CreateMap<User, UserGetDto>().ReverseMap();
            CreateMap<Post, AddPostDto>().ReverseMap();
            CreateMap<Post, EditPostDto>().ReverseMap();
            CreateMap<Comment, GetCommentsDto>().ReverseMap();
            CreateMap<Comment, AddCommentDto>().ReverseMap();
            CreateMap<Comment, EditCommentDto>().ReverseMap();
            CreateMap<GetPostDto, EditCommentDto>().ReverseMap();
            CreateMap<Post, PostCommentDto>().ReverseMap();
            CreateMap<Friend, GetFriendDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<Block, GetBlockDto>().ReverseMap();
            CreateMap<Block, Friend>().ReverseMap();
            CreateMap<CommentReaction, GetCommentReactionsDto>().ReverseMap();
            CreateMap<PostReaction,GetPostReactionDto>().ReverseMap();


        }
    }
}
