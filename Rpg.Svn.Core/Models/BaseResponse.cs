using System.Collections.Generic;

namespace Rpg.Svn.Core.Models
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Message = string.Empty;
            Success = true;
        }

        public T Content { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public class Collection
        {
            public List<T> List { get; set; }
            public string Message { get; set; }
            public bool Success { get; set; }
            public int? Total { get; set; }

            public Collection()
            {
                Message = string.Empty;
                Success = true;
                List = new List<T>();
            }
        }
    }
}
