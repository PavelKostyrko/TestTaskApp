namespace TestTaskApp.Data.Models
{
    public class RoleDb
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public ICollection<UserDb> Users { get; set; } = new List<UserDb>();
    }
}
