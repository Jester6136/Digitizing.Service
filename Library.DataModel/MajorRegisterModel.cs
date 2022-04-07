using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class MajorRegisterModel
	{
        public Guid major_register_id { get; set; }
        public string student_rcd { get; set; }
		public Guid major_id { get; set; }
		public int major_register_wish { get; set; }
		public string major_register_note { get; set; }
		public string major_school_year { get; set; }
        public MajorModel major_info { get; set; }
        public int active_flag { get; set; }
        public Guid created_by_user_id { get; set; }
		public DateTime created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
	}
}