using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace disk.web
{
	public class MenuItem
	{
	    public MenuItem()
	    {
            children = new List<MenuItem>();
	    }

	    public int id { get; set; }
	    public int pId { get; set; }
	    public bool open { get; set; }
	    public string text { get; set; }
	    public string file { get; set; }
	    public string iconCls { get; set; }
	    public IList<MenuItem> children { get; set; }
	}
}