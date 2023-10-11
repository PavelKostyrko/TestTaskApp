using TestTaskApp.Data.Models;
using TestTaskApp.Logic.Models;

namespace TestTaskApp.Logic.Builders
{
    public class UserBuilder
    {
        public static UserDb Build(UserDto obj)
        {
            return obj != null
                ? new UserDb()
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    Age = obj.Age,
                    Email = obj.Email,
                    Roles = RoleBuilder.Build(obj.Roles)
                }
                : null;
        }

        public static ICollection<UserDb> Build(ICollection<UserDto> col)
        {
            return col?.Select(o => Build(o))?.ToList();
        }

        public static UserDto Build(UserDb obj)
        {
            return obj != null
                ? new UserDto()
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    Age = obj.Age,
                    Email = obj.Email,
                    Roles = RoleBuilder.Build(obj.Roles)
                }
                : null;
        }

        public static ICollection<UserDto> Build(ICollection<UserDb> col)
        {
            return col?.Select(o => Build(o))?.ToList();
        }
    }
}
