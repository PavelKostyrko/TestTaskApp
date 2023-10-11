using Microsoft.AspNetCore.Mvc;
using TestTaskApp.Logic.AuxiliaryСlasses;
using TestTaskApp.Logic.AuxiliaryСlasses.Interfaces;
using TestTaskApp.Logic.Models;
using TestTaskApp.Logic.Services.Interfaces;

namespace TestTaskApp.Web.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserDto> _validator;

        public UserController(IUserService userService, IValidator<UserDto> validator)
        {
            _userService = userService;
            _validator = validator;
        }

        /// <summary> Outputs paginated users from the database depending on the selected conditions. </summary>
        /// <param name="request"></param>
        /// <returns> Returns a pagination response object containing a sorted collection of users. </returns>
        /// <response code="200"> Success. </response>
        /// <response code="400"> The request of getting object collection is incorrect. </response>
        /// <response code="404"> Object collection was not found. </response>
        /// <response code="500"> Something is wrong on the server. </response>
        [HttpPost("pagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllWithPaginationAsync([FromBody] PaginationRequest request)
        {
            try
            {
                var response = await _userService.GetAllWithPaginationAsync(request);
                return response == null ? NotFound() : Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary> Gets the user by Id from the database. </summary>
        /// <param name="userId" example="12"> The user Id. </param>
        /// <returns> Returns an user object with id: <paramref name="userId"/>. </returns>
        /// <remarks> Id must only be a positive number </remarks>
        /// <response code="200"> Success. </response>
        /// <response code="400"> The request is incorrect. </response>
        /// <response code="404"> The object with this Id was not found. </response>
        /// <response code="500"> Something is wrong on the server. </response>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int? userId)
        {
            try
            {
                if (userId == null)
                    return BadRequest();

                var response = await _userService.GetByIdAsync(userId);
                return response == null ? NotFound() : Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary> Gets a list of user roles by Id from the database. </summary>
        /// <param name="userId" example="12"> The user Id. </param>
        /// <returns> Returns a list of user roles by user Id: <paramref name="userId"/>. </returns>
        /// <remarks> Id must only be a positive number </remarks>
        /// <response code="200"> Success. </response>
        /// <response code="400"> The request is incorrect. </response>
        /// <response code="404"> The object with this Id was not found. </response>
        /// <response code="500"> Something is wrong on the server. </response>
        [HttpGet("roles/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRolesByIdAsync(int? userId)
        {
            try
            {
                if (userId == null)
                    return BadRequest();

                var response = await _userService.GetAllRolesByIdAsync(userId);
                return response == null ? NotFound() : Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary> Adds the existing role to the user with the specified Id. </summary>
        /// <param name="userId" example="12"> The user Id. </param>
        /// <param name="roleTitle" example="Admin"> The role title. </param>
        /// <returns> Returns the operation status code </returns>
        /// <remarks> Id must only be a positive number. It is possible to add only existing role. </remarks>
        /// <response code="200"> Success. </response>
        /// <response code="400"> The request is incorrect. </response>
        /// <response code="500"> Something is wrong on the server. </response>
        [HttpPut("{userId}/{roleTitle}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddNewRoleAsync(int? userId, string roleTitle)
        {
            try
            {
                if (userId == null)
                    return BadRequest();
                if (roleTitle == null)
                    return BadRequest();

                await _userService.AddNewRoleAsync(userId, roleTitle);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary> Creates a new user. </summary>
        /// <param name="userDto"></param>
        /// <returns> Returns the operation status code. </returns>
        /// <remarks> Required fields: "Name" (must contain only letters); "Age"(must be positive number); "Email"(must be unique). </remarks>
        /// <response code="200"> Success. </response>
        /// <response code="400"> The request of creating an object is incorrect. </response>
        /// <response code="500"> Something is wrong on the server. </response>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] UserDto userDto)
        {
            try
            {
                if (_validator.ValidateForCreate(userDto))
                {
                    await _userService.CreateAsync(userDto);
                    return Ok();
                }
                else return BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary> Updates user information in database. </summary>
        /// <param name="userDto"></param>
        /// <returns> Returns the operation status code. </returns>
        /// <remarks> Id must only be a positive number. Required fields: "Name" (must contain only letters); 
        /// "Age"(must be positive number); "Email"(must be unique). </remarks>
        /// <response code="200"> Success. </response>
        /// <response code="400"> The request of updating an object is incorrect. </response>
        /// <response code="500"> Something is wrong on the server. </response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromBody] UserDto userDto)
        {
            try
            {
                if (_validator.ValidateForUpdate(userDto))
                {
                    await _userService.UpdateAsync(userDto);
                    return Ok();
                }
                else return BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary> Deletes the user from the database by Id. </summary>
        /// <param name="userId" example="12"> The user Id. </param>
        /// <returns> Returns the operation status code. </returns>
        /// <remarks> Id must only be a positive number. </remarks>
        /// <response code="200"> Success. </response>
        /// <response code="400"> The request of deleting an object is incorrect. </response>
        /// <response code="500"> Something is wrong on the server. </response>
        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int? userId)
        {
            try
            {
                if (userId == null)
                    return BadRequest();

                await _userService.DeleteAsync(userId);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }  
        }
    }
}
