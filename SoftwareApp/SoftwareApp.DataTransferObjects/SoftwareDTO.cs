using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareApp.DataTransferObjects
{
    public class SoftwareDTO
    {
		public int id { get; set; }
		public int typeid { get; set; }
		public int locationid { get; set; }
		public int platformid { get; set; }
		public string unc { get; set; }
		public string softwareDescription { get; set; }
		public string softwareName { get; set; }

		public string platformDescription { get; set; }
		public string locationDescription { get; set; }
		public string typeDescription { get; set; }

	}
}
