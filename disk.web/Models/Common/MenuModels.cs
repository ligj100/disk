using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace disk.web.Models.Common
{
    public class MenuModels
    {
        public MenuModels()
	    {
            children = new List<MenuModels>();
	    }

	    public int id { get; set; }
	    public int pId { get; set; }
	    public bool open { get; set; }
	    public string text { get; set; }
	    public string file { get; set; }
	    public string iconCls { get; set; }
        public IList<MenuModels> children { get; set; }
    }
}