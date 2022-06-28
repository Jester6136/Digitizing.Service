using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class ProjectRegisterModel
	{
        public Guid student_project_register_id { get; set; }
		public string student_rcd { get; set; }
		public Guid teacher_pro_id { get; set; }
        public string student_project_name { get; set; }
		public string teacher_name { get; set; }
		public int project_type { get; set; }
		public int project_register_status { get; set; }
		public int active_flag { get; set; }
		public Guid? created_by_user_id { get; set; }
		public DateTime? created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
	}
}