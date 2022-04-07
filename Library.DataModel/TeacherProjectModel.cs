using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class TeacherProjectModel
	{
        public string teacher_pro_id_rcd { get; set; }
		public string academic_year { get; set; }
		public string semester { get; set; }
        public string teacher_rcd { get; set; }
		public string course_id_rcd { get; set; }
        public string class_id_rcd { get; set; }
        public int quantity { get; set; }
        public TeacherModel teacher_information { get; set; }
        public int active_flag { get; set; }
		public Guid created_by_user_id { get; set; }
		public DateTime created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
	}
}