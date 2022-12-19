namespace Facebook_Api.DTOS.PostDtos
{
    public class EditPostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; } = String.Empty;
    }
}
