namespace TestTaskApp.Logic.AuxiliaryСlasses
{
    public class PaginationRequest
    {
        public string UserNameQuery { get; set; }
        public string UserEmailQuery { get; set; }
        public byte? UserAgeQuery { get; set; }
        public string RoleTitleQuery { get; set; }
        public string SortBy { get; set; }
        public int? Skip { get; set; } = 0;
        public int? Take { get; set; } = 10;
        public bool Ascending { get; set; } = true;
    }
}
