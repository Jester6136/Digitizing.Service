using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModel
{
    public class StudentRecruitmentReportWeeklyModel
    {
        public string student_rcd { get; set; }
        public string recruitment_id { get; set; }
        public int reptort_week_rcd { get; set; }
        public string week_name { get; set; }
        public int report_day_rcd { get; set; }
        public string job_assignment { get; set; }
        public string result_in_day { get; set; }
        public string description { get; set; }
        public Guid created_by_user_id { get; set; }
        public DateTime created_date_time { get; set; }
        public DateTime lu_updated { get; set; }
        public Guid lu_user_id { get; set; }
        public int active_flag { get; set; }
    }

}
