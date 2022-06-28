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
		public string student_citizen_identity_card_date { get; set; }
		public string student_citizen_identity_card_place { get; set; }
		public string student_phone_home { get; set; }
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
		public string spouses_name { get; set; }
		public string spouses_nationality { get; set; }
		public string spouses_nation { get; set; }
		public string spouses_religion { get; set; }
		public string spouses_address { get; set; }
		public string spouses_work { get; set; }
		public string spouses_phone_number { get; set; }
		public string gender { get; set; }
		public string student_email { get; set; }
		public string class_id { get; set; }
		public string student_role { get; set; }
		public string student_status { get; set; }
		public DateTime? date_of_birth { get; set; }
		public string school_year { get; set; }
		public string degree_name { get; set; }
		public string specialization_name_VN { get; set; }
		public string major_name_VN { get; set; }
		public int priority_flag { get; set; }
		public string cv_path { get; set; }
		public string password { get; set; }
		public int active_flag { get; set; }
		public Guid? created_by_user_id { get; set; }
		public DateTime? created_date_time { get; set; }
		public DateTime? lu_updated { get; set; }
		public Guid? lu_user_id { get; set; }

	}
}