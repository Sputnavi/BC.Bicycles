namespace BC.Bicycles.Boundary.Features
{
    public class RequestParameters
    {
        const int maxPageSize = 50;

        /// <summary>
        /// Page Number
        /// </summary>
        /// <example>1</example>
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        /// <summary>
        /// Page size
        /// </summary>
        /// <example>10</example>
        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        /// <summary>
        /// Rule how to order records
        /// </summary>
        /// <example>name</example>
        public string OrderBy { get; set; }
    }
}
