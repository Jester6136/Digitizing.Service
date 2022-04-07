using System;
using System.Collections.Generic;

namespace Library.DataModel
{
    public class PreCompanyRecruitmentModel
    {
        public Guid recruitment_id { get; set; }
        public string course_year { get; set; }
        public string company_rcd { get; set; }
        public string recruitment_title { get; set; }
        public string recruitment_job { get; set; }
        public string company_website_address { get; set; }
        public string student_wish_rcd { get; set; }
        public int active_flag { get; set; }
        public Guid created_by_user_id { get; set; }
        public DateTime created_date_time { get; set; }
        public DateTime? lu_updated { get; set; }
        public Guid? lu_user_id { get; set; }
    }
}
