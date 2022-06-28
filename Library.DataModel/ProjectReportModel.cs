using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModel
{
    public class ProjectReportModel
    {
        public string student_rcd { get; set; }
        public Guid student_project_report_id { get; set; }
        public Guid student_project_register_id { get; set; }
        public int project_type { get; set; }
        public int report_week { get; set; }
        public string report_url { get; set; }
        public string report_final_file { get; set; }
        public int active_flag { get; set; }
        public Guid created_by_user_id { get; set; }
        public DateTime created_date_time { get; set; }
        public DateTime lu_updated { get; set; }
        public Guid lu_user_id { get; set; }
    }

}
