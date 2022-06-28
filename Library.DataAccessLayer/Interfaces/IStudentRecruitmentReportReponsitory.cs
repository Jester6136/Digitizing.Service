using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.DataAccessLayer
{
    public partial interface IStudentRecruitmentReportReponsitory
    {
        List<StudentRecruitmentReportModel> Search(int pageIndex, int pageSize
            , out long total, string student_rcd, string report_week);

        List<DropdownOptionModel> GetListDropdown();

        StudentRecruitmentReportModel GetById(string student_rcd, int report_week, int report_day);
        InternshipProcessEvaluateModel GetInternshipProcessEvaluateById(string student_rcd, int report_week);
        bool Create(StudentRecruitmentReportModel model);
        StudentRecruitmentReportModel GetStudentRecuitmentReportById(string student_rcd);
        bool Update(StudentRecruitmentReportModel model);
        bool UpdateReport(StudentRecruitmentReportModel model);
    }
}
