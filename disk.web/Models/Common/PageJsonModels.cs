using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace disk.web.Models.Common
{
    public class PageJsonModels<T> 
    {
        public PageJsonModels()
        {
            rows = new List<T>();
        }

        public int total { get; set; }
        public IList<T> rows { get; set; }

    }
}