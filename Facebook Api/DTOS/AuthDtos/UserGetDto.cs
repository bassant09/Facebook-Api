namespace Facebook_Api.DTOS.AuthDtos
{
    public class UserGetDto
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
    }
}
