using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace disk.web.Models.Common
{
    public class PageJsonModel<T> 
    {
        public PageJsonModel()
        {
            rows = new List<T>();
        }

        public int total { get; set; }
        public IList<T> rows { get; set; }

    }
}