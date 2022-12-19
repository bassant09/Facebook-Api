namespace Facebook_Api.DTOS.AuthDtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public String Password { get; set; }
        public DateTime BithDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string ProfilePicturePath { get; set; } = string.Empty;
    }
}
