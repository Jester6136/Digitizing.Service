using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class TeacherModel
	{
        public string teacher_rcd { get; set; }
		public string teacher_name { get; set; }
		public string manager_role_id1 { get; set; }
        public string manager_role_id2 { get; set; }
		public string department_id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
		public string additional_information { get; set; }
		public int active_flag { get; set; }
        public Guid created_by_user_id { get; set; }
		public DateTime created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
	}
}