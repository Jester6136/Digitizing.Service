using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class EnterpriseModel
	{
        public Guid enterprise_id { get; set; }
		public string enterprise_name { get; set; }
		public string enterprise_address { get; set; }
		public string enterprise_url { get; set; }
		public string enterprise_logo { get; set; }
		public int enterprise_size { get; set; }
        public int active_flag { get; set; }
		public Guid created_by_user_id { get; set; }
		public DateTime created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
	}
}