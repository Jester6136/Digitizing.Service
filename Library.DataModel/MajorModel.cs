using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class MajorModel
	{
        public Guid majors_id { get; set; }
        public string majors_name { get; set; }
        public int active_flag { get; set; }
        public Guid created_by_user_id { get; set; }
		public DateTime created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
	}
}