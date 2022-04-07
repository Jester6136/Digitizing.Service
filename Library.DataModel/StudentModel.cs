using System;
using System.Collections.Generic;
namespace Library.DataModel 
{
	public partial class StudentModel
	{
		public string student_rcd { get; set; }
		public string student_name { get; set; }
		public string student_nationality { get; set; }
		public string student_nation { get; set; }
		public string student_religion { get; set; }
		public string student_countryside { get; set; }
		public int student_apartment_number { get; set; }
		public string student_health_insurance_code { get; set; }
		public string student_citizen_identity_card { get; set; }
		public string student_phone { get; set; }
		public string student_province_of_residence { get; set; }
		public string student_resident_district { get; set; }
		public string student_resident_ward { get; set; }
		public string student_address { get; set; }
		public string student_province_born { get; set; }
		public string student_district_born { get; set; }
		public string student_ward_born { get; set; }
		public string student_address_receive { get; set; }
		public string student_facebook_url { get; set; }
		public string student_card_photo { get; set; }
		public string citizen_identification_photo { get; set; }
		public string spouses_name { get; set; }
		public string spouses_nationality { get; set; }
		public string spouses_nation { get; set; }
		public string spouses_religion { get; set; }
		public string spouses_address { get; set; }
		public string spouses_work { get; set; }
		public string spouses_phone_number { get; set; }
        public StudentFamilyModel student_family { get; set; }
		public MajorRegisterModel major_register { get; set; }
		public int active_flag { get; set; }
		public Guid? created_by_user_id { get; set; }
		public DateTime? created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }

	}
}