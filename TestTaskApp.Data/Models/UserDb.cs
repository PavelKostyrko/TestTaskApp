namespace TestTaskApp.Data.Models
{
    public class UserDb
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public byte? Age { get; set; }
        public string Email { get; set; }
        public ICollection<RoleDb> Roles { get; set; } = new List<RoleDb>();
    }
}
