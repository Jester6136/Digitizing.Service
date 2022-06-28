using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class StudentRecruitmentReportBusiness : IStudentRecruitmentReportBusiness
    {
        private IStudentRecruitmentReportReponsitory _res;
        public StudentRecruitmentReportBusiness(IStudentRecruitmentReportReponsitory res)
        {
            _res = res;
        }

        public bool Create(StudentRecruitmentReportModel model)
        {
            return _res.Create(model);
        }

        public StudentRecruitmentReportModel GetById(string student_rcd, int report_week, int report_day)
        {
            return _res.GetById(student_rcd,report_week,report_day);
        }

        public InternshipProcessEvaluateModel GetInternshipProcessEvaluateById(string student_rcd, int report_week)
        {
            return _res.GetInternshipProcessEvaluateById(student_rcd, report_week);
        }

        public List<DropdownOptionModel> GetListDropdown()
        {
            var result = _res.GetListDropdown();
            return result == null ? null : result;
        }

        public StudentRecruitmentReportModel GetStudentRecuitmentReportById(string student_rcd)
        {
            return _res.GetStudentRecuitmentReportById(student_rcd);
        }

        public List<StudentRecruitmentReportModel> Search(int pageIndex, int pageSize, out long total, string student_rcd, string report_week)
        {
            return _res.Search(pageIndex, pageSize, out total, student_rcd, report_week);
        }

        public bool Update(StudentRecruitmentReportModel model)
        {
            return _res.Update(model);
        }


        public bool UpdateReport(StudentRecruitmentReportModel model)
        {
            return _res.UpdateReport(model);
        }
    }
}
