using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.DTOS.PostDtos;

namespace Facebook_Api.DTOS.FilterDto
{
    public class FilterGetDto
    {
        public List<UserGetDto> Users { get; set; }
        public List<GetPostDto> Posts { get; set; }
    }
}
