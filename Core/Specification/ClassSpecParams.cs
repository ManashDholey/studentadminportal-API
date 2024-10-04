
namespace Core.Specification
{
    public class ClassSpecParams
    {
        private const int MaxPageSize = 100;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 5;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string? Active { get; set; } = "";
        public string? Direction { get; set; } = "";
        private string? _search;
        public string? Search
        {
            get => _search;
            set => _search = value?.ToLower();
        }
    }
}
