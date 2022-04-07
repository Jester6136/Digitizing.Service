using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class ReportModel
	{
        public Guid report_id { get; set; }
		public string student_rcd { get; set; }
		public Guid student_project_register_id { get; set; }
        public string report_url { get; set; }
		public int active_flag { get; set; }
        public Guid created_by_user_id { get; set; }
		public DateTime created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
	}
}