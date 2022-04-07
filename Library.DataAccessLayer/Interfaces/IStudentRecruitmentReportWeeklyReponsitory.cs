using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.DataAccessLayer
{
    public partial interface IStudentRecruitmentReportWeeklyReponsitory
    {
        List<StudentRecruitmentReportWeeklyModel> Search(int pageIndex, int pageSize
            , out long total, string student_rcd, string reptort_week_rcd);

        List<DropdownOptionModel> GetListDropdown();

        StudentRecruitmentReportWeeklyModel GetById(string student_rcd,int reptort_week_rcd,int report_day_rcd);
        //bool Create(StudentRecruitmentReportWeeklyModel model);
        bool Update(StudentRecruitmentReportWeeklyModel model);
    }
}
