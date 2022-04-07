using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class ProjectRegisterModel
	{
        public Guid student_project_register_id { get; set; }
		public string student_rcd { get; set; }
		public string teacher_rcd { get; set; }
        public Guid student_project_id { get; set; }
		public int project_register_status { get; set; }
        public ProjectModel project { get; set; }
		public ReportModel report { get; set; }
		public TeacherModel teacher_information { get; set; }
		public StudentModel student_information { get; set; }
		public int active_flag { get; set; }
        public Guid created_by_user_id { get; set; }
		public DateTime created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
	}
}