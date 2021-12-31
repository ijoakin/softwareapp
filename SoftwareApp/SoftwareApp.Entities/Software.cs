using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareApp.Entities
{
	public class Software : BaseEntity
	{
		public int typeid { get; set; }
		public int locationid { get; set; }
		public int platformid { get; set; }
		public string unc { get; set; }
		public string softwareDescription { get; set; }
		public string softwareName { get; set; }
	}
}
