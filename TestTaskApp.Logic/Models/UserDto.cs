namespace TestTaskApp.Logic.Models
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public byte? Age { get; set; }
        public string Email { get; set; }
        public ICollection<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
}
