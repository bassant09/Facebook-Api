using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.Models;

namespace Facebook_Api.DTOS.PostDtos
{
    public class AddPostDto
    {
        public string Content { get; set; }
        public string ImagePath { get; set; } = String.Empty;
    }
}
