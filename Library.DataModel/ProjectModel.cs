using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class ProjectModel
	{
        public Guid student_project_id { get; set; }
		public string teacher_rcd { get; set; }
		public string student_class_rcd { get; set; }
        public string student_subject_rcd { get; set; }
		public string student_project_title { get; set; }
        public string student_project_detail { get; set; }
        public int student_project_size { get; set; }
        public int student_project_type { get; set; }
        public SubjectModel subject_info { get; set; }
        public int active_flag { get; set; }
        public Guid created_by_user_id { get; set; }
		public DateTime created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
	}
}