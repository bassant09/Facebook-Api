using AutoMapper;
using Facebook_Api.Data;
using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.DTOS.FilterDto;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;

namespace Facebook_Api.Services.Filer_Folder
{
    public class FilterServices : IFilterServices
    {
        private readonly DataContext _db; 
        private readonly IMapper _mapper;
        public FilterServices(DataContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public  async Task<ServicesRespone<FilterGetDto>> Search(String Name )
        {
            var respone = new  ServicesRespone<FilterGetDto>();
         
            if(Name == null)
            {
                respone.Success = false;
                respone.Message = "Empty Search Please Enter String ";
                return respone; 
            }
            var PeopleList = _db.Users.Where(e => e.UserName.Contains(Name)).ToList(); 
           var PostList = _db.Posts.Where(e=>e.Content.Contains(Name));
           var filter = new FilterGetDto();
            filter.Users = _mapper.Map<List<UserGetDto>>(PeopleList);
            filter.Posts = _mapper.Map<List<GetPostDto>>(PostList);
            respone.Data = filter;
            return respone; 
        }
    }
}
