using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class JobInfoModel
	{
        public Guid job_info_id { get; set; }
		public string job_info_title { get; set; }
		public Guid enterprise_id { get; set; }
        public DateTime from_date { get; set; }
		public DateTime to_date { get; set; }
        public string job_info_url { get; set; }
        public EnterpriseModel enterprise { get; set; }
        public int active_flag { get; set; }
		public Guid created_by_user_id { get; set; }
		public DateTime created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
	}
}