using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class SubjectModel
	{
        public string course_id_rcd { get; set; }
		public string course_name { get; set; }
		public string course_type { get; set; }
		public int numcredits_creadits1 { get; set; }
		public int numcredits_creadits2 { get; set; }
		public string comment { get; set; }
        public int active_flag { get; set; }
		public Guid created_by_user_id { get; set; }
		public DateTime created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }	
		public Guid? lu_user_id { get; set; }
	}
}