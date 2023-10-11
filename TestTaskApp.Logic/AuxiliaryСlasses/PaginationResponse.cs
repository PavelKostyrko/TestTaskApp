namespace TestTaskApp.Logic.AuxiliaryСlasses
{
    public class PaginationResponse<T>
    {
        public int? Total { get; set; }
        public ICollection<T> Values { get; set; }
    }
}
