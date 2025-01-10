namespace ImageUpload.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? PhotoData { get; set; }
    }
}
