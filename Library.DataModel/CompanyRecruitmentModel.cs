using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModel
{
    public class CompanyRecruitmentModel
    {
        public Guid recruitment_id { get; set; }
        public string course_year { get; set; }
        public string company_rcd { get; set; }
        public string recruitment_title { get; set; }
        public string recruitment_job { get; set; }
        public int recruitment_quantity { get; set; }
        public string recruitment_description { get; set; }
        public string recruitment_skill_requirement { get; set; }
        public string recruitment_job_requirement { get; set; }
        public string recruitment_cv_requirement { get; set; }
        public string recruitment_benefit { get; set; }
        public DateTime recruitment_expiry_date { get; set; }
        public string recruitment_contact { get; set; }
        public Guid created_by_user_id { get; set; }
        public DateTime created_date_time { get; set; }
        public DateTime lu_updated { get; set; }
        public Guid lu_user_id { get; set; }
        public int active_flag { get; set; }
    }

}
