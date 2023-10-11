namespace TestTaskApp.Logic.AuxiliaryСlasses.Interfaces
{
    public interface IValidator<T>
    {
        bool ValidateForCreate(T obj);
        bool ValidateForUpdate(T obj);
    }
}
