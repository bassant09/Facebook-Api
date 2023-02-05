using Facebook_Api.DTOS.FilterDto;
using Facebook_Api.Models;

namespace Facebook_Api.Services.Filer_Folder
{
    public interface IFilterServices
    {
        Task<ServicesRespone<FilterGetDto>>Search(String Name ); 
    }
}
