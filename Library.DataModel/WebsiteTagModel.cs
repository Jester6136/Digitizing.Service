using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class WebsiteTagModel
	{
		public Guid tag_id { get; set; }
		public string tag_name_l { get; set; }
		public string tag_name { get; set; }
		public string tag_name_e { get; set; }
		public string tag_description_l { get; set; }
		public string tag_description { get; set; }
		public string tag_description_e { get; set; }
		public int? sort_order { get; set; }
		public Guid created_by_user_id { get; set; }
		public DateTime created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
		public int active_flag { get; set; }
	}
}