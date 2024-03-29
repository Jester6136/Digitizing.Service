﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModel
{
    public class JobCandidateModel
    {
        public Guid candidate_id { get; set; }
        public string student_rcd { get; set; }
        public Guid recruitment_id { get; set; }
        public string student_wish_rcd { get; set; }
        public bool able_update_report { get; set; }
        public string report_src { get; set; }
        public string status_rcd { get; set; }
        public string cv_path { get; set; }
        public string course_year { get; set; }
        public Guid created_by_user_id { get; set; }
        public DateTime created_date_time { get; set; }
        public DateTime? lu_updated { get; set; }
        public Guid? lu_user_id { get; set; }
        public int active_flag { get; set; }
        public string teacher_name { get; set; }
        public string company_rcd { get; set; }

    }
}
