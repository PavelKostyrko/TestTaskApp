using TestTaskApp.Data.Models;
using TestTaskApp.Logic.Models;

namespace TestTaskApp.Logic.Builders
{
    public class RoleBuilder
    {
        public static RoleDb Build(RoleDto obj)
        {
            return obj != null
                ? new RoleDb()
                {
                    Id = obj.Id,
                    Title = obj.Title,
                }
                : null;
        }

        public static ICollection<RoleDb> Build(ICollection<RoleDto> col)
        {
            return col?.Select(o => Build(o))?.ToList();
        }

        public static RoleDto Build(RoleDb obj)
        {
            return obj != null
                ? new RoleDto()
                {
                    Id = obj.Id,
                    Title = obj.Title, 
                }
                : null;
        }

        public static ICollection<RoleDto> Build(ICollection<RoleDb> col)
        {
            return col?.Select(o => Build(o))?.ToList();
        }
    }
}
