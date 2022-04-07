using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModel
{
    public partial class StudentFamilyModel
    {
        public Guid family_id { get; set; }
        public string student_rcd { get; set; }
		public string father_name { get; set; }
		public DateTime? father_year_of_birth { get; set; }
		public string father_nationality { get; set; }
		public string father_nation { get; set; }
		public string father_religion { get; set; }
		public string father_permanent_residence { get; set; }
		public string father_work { get; set; }
		public string father_phone_number { get; set; }
		public string mother_name { get; set; }
		public DateTime? mother_year_of_birth { get; set; }
		public string mother_nationality { get; set; }
		public string mother_nation { get; set; }
		public string mother_religion { get; set; }
		public string mother_permanent_residence { get; set; }
		public string mother_work { get; set; }
		public string mother_phone_number { get; set; }
		//public int family_number_of_siblings { get; set; }
		public int active_flag { get; set; }
		public Guid? created_by_user_id { get; set; }
		public DateTime? created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }
	}
}
