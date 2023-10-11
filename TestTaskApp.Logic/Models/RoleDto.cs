namespace TestTaskApp.Logic.Models
{
    public class RoleDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public ICollection<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
