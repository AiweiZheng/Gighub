namespace GigHub.Core.Models
{
    public class UserDescription
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Description Description { get; set; }
        public string UserId { get; set; }
        public int DescriptionId { get; set; }
    }
}