using TestTaskApp.Logic.AuxiliaryСlasses.Interfaces;
using TestTaskApp.Logic.Models;

namespace TestTaskApp.Logic.AuxiliaryСlasses
{
    public class Validator<T> : IValidator<T> where T : UserDto
    {
        public bool ValidateForCreate(T userDto)
        {
            if (userDto.Id == null
                && !string.IsNullOrEmpty(userDto.Email)
                && !string.IsNullOrEmpty(userDto.Name)
                && userDto.Name.All(char.IsLetter)
            && userDto.Age > 0 && userDto.Age != null)
            {
                return true;
            }
            return false;
        }

        public bool ValidateForUpdate(T userDto)
        {
            if (userDto.Id != null
                    && !string.IsNullOrEmpty(userDto.Email)
                    && !string.IsNullOrEmpty(userDto.Name)
                    && userDto.Name.All(char.IsLetter)
                    && userDto.Age > 0 && userDto.Age != null)
            {
                return true;
            }
            return false;
        }
    }
}
