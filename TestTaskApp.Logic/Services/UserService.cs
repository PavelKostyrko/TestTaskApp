using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.ComponentModel.DataAnnotations;
using TestTaskApp.Data;
using TestTaskApp.Logic.AuxiliaryСlasses;
using TestTaskApp.Logic.AuxiliaryСlasses.Interfaces;
using TestTaskApp.Logic.Builders;
using TestTaskApp.Logic.Models;
using TestTaskApp.Logic.Services.Interfaces;

namespace TestTaskApp.Logic.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IValidator<UserDto> _validator;
        public UserService(Context context, IValidator<UserDto> validator) : base(context)
        {
            _validator = validator;
        }

        /// <summary> Outputs paginated users from the database depending on the selected conditions. </summary>
        /// <param name="request"></param>
        /// <returns> Returns a pagination response object containing a sorted collection of users. </returns>
        public async Task<PaginationResponse<UserDto>> GetAllWithPaginationAsync(PaginationRequest request)
        {
            var userQuery = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(request.UserNameQuery))
            {
                userQuery = userQuery.Where(o => o.Name.Contains(request.UserNameQuery)); 
            }
            if (!string.IsNullOrEmpty(request.UserEmailQuery))
            {
                userQuery = userQuery.Where(o => o.Email.ToLower().Contains(request.UserEmailQuery.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.UserAgeQuery.ToString()))
            {
                userQuery = userQuery.Where(o => o.Age.ToString().Contains(request.UserAgeQuery.ToString()));
            }
            if (!string.IsNullOrEmpty(request.RoleTitleQuery))
            {
                userQuery = userQuery.Include(o => o.Roles).Where(o => o.Roles.Any(ob => ob.Title.Contains(request.RoleTitleQuery)));
            }

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                switch (request.SortBy)
                {
                    case "Name": userQuery = request.Ascending ? userQuery.OrderBy(o => o.Name) : userQuery.OrderByDescending(o => o.Name); break;
                    case "Email": userQuery = request.Ascending ? userQuery.OrderBy(o => o.Email) : userQuery.OrderByDescending(o => o.Email); break;
                    case "Age": userQuery = request.Ascending ? userQuery.OrderBy(o => o.Age) : userQuery.OrderByDescending(o => o.Age); break;
                }
            }

            var userDbs = await userQuery.ToListAsync().ConfigureAwait(false);

            var total = userDbs.Count;
            var userDtos = UserBuilder.Build(userDbs.Skip(request.Skip ?? 0).Take(request.Take ?? 10)?.ToList());

            return new PaginationResponse<UserDto>
            {
                Total = total,
                Values = userDtos
            };
        }

        /// <summary> Gets the user by Id from the database. </summary>
        /// <param name="userId"></param>
        /// <returns> Returns an user object with id: <paramref name="userId"/>. </returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<UserDto> GetByIdAsync(int? userId)
        {
            if (userId == null)
                throw new ValidationException("This user don`t exist.");

            var userDb = await _context.Users.SingleOrDefaultAsync(o => o.Id == userId).ConfigureAwait(false);
            
            if (userDb != null)
            {
                _context.Entry(userDb).Collection(o => o.Roles).Load();
                return UserBuilder.Build(userDb);
            }
            else throw new ValidationException("User with this Id don`t exist");
        }

        /// <summary> Gets a list of user roles by Id from the database. </summary>
        /// <param name="userId" example="12"> The user Id. </param>
        /// <returns> Returns a list of user roles by user Id: <paramref name="userId"/>. </returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<List<string>> GetAllRolesByIdAsync(int? userId)
        {
            if (userId == null)
                throw new ValidationException("This user don`t exist.");

            var rolesTitles = new List<string>();

            var userDb = await _context.Users.SingleOrDefaultAsync(o => o.Id == userId).ConfigureAwait(false);

            if (userDb != null)
            {
                _context.Entry(userDb).Collection(o => o.Roles).Load();

                var roles = userDb.Roles;
                foreach (var role in roles)
                {
                    rolesTitles.Add(role.Title);
                }
            }
            else
                throw new ValidationException("User with this Id don`t exist");

            return rolesTitles;
        }

        /// <summary> Gets a list of user roles by Id from the database. </summary>
        /// <param name="userId" example="12"> The user Id. </param>
        /// <param name="roleTitle" example="Admin"> The role title. </param>
        /// <returns> Returns a list of user roles by user Id: <paramref name="userId"/>. </returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task AddNewRoleAsync(int? userId, string roleTitle)
        {
            if (userId == null)
                throw new ValidationException("This user don`t exist.");
            if (roleTitle == null)
                throw new ValidationException("This role don`t exist.");

            var roleDb = await _context.Roles.SingleOrDefaultAsync(o => o.Title == roleTitle).ConfigureAwait(false);
            var userDb = await _context.Users.SingleOrDefaultAsync(o => o.Id == userId).ConfigureAwait(false);

            if (userDb != null && roleDb != null)
            {
                userDb.Roles?.Add(roleDb);

                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch
                {
                    throw new Exception("Role has not been added.");
                }
            }
            else
                throw new ValidationException("User or role, that you are trying to add, don`t exist.");
        }

        /// <summary> Creates a new user. </summary>
        /// <param name="userDto"></param>
        /// <returns> Returns the operation status code. </returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task CreateAsync(UserDto userDto)
        {
            if (_validator.ValidateForCreate(userDto))
            {
                try
                {
                    await _context.Users.AddAsync(UserBuilder.Build(userDto)).ConfigureAwait(false);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch
                {
                    throw new Exception("Object has not been created.");
                }
            }
            else
                throw new ValidationException("Invalid data for creating.");
        }

        /// <summary> Updates user information in database. </summary>
        /// <param name="userDto"></param>
        /// <returns> Returns the operation status code. </returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(UserDto userDto)
        {
            if (_validator.ValidateForUpdate(userDto))
            {
                var userDb = await _context.Users.SingleOrDefaultAsync(_ => _.Id == userDto.Id).ConfigureAwait(false);

                if (userDb != null)
                {
                    userDb.Name = userDto.Name;
                    userDb.Age = userDto.Age;
                    userDb.Email = userDto.Email;

                    try
                    {
                        await _context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    catch
                    {
                        throw new Exception("Object has not been updated.");
                    }
                }
                else
                    throw new ValidationException("There is not user, that you are trying to update.");
            }
            else
                throw new ValidationException("Invalid data for updating.");
        }

        /// <summary> Deletes the user from the database by Id. </summary>
        /// <param name="userId" example="12"> The user Id. </param>
        /// <returns> Returns the operation status code. </returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(int? userId)
        {
            if (userId == null)
                throw new ValidationException("Id can`t be null.");

            var userDb = await _context.Users.SingleOrDefaultAsync(_ => _.Id == userId).ConfigureAwait(false);

            if (userDb != null)
            {
                _context.Users.Remove(userDb);

                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch
                {
                    throw new Exception("Object has not been deleted.");
                }
            }
            else
                throw new ValidationException("There is not user, that you are trying to delete.");
        }
    }
}
