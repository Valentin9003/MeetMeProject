namespace MeetMe.Services.Models.Search
{
    public class SearchServiceModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] PrifilePicture = new byte[10 * 1024 * 1024];
    }
}
