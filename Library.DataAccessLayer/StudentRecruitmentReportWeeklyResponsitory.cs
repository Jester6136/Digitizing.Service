using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.Common.Helper;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public partial class StudentRecruitmentReportWeeklyReponsitory : IStudentRecruitmentReportWeeklyReponsitory
    {
        private IDatabaseHelper _dbHelper;

        public StudentRecruitmentReportWeeklyReponsitory(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        List<StudentRecruitmentReportWeeklyModel> IStudentRecruitmentReportWeeklyReponsitory.Search(int pageIndex, int pageSize, out long total, string student_rcd, string reptort_week_rcd)
        {
            total = 0;
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@page_index", DbType.Int32, pageIndex),
                    _dbHelper.CreateInParameter("@page_size", DbType.Int32,  pageSize),
                    _dbHelper.CreateInParameter("@student_rcd" ,DbType.String,student_rcd),
                    _dbHelper.CreateInParameter("@reptort_week_rcd" ,DbType.Int32,reptort_week_rcd),
                    _dbHelper.CreateOutParameter("@OUT_TOTAL_ROW", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToList<StudentRecruitmentReportWeeklyModel>("dbo.student_recruitment_report_search", parameters);
                if (!string.IsNullOrEmpty(result.ErrorMessage) && result.ErrorCode != 0)
                    throw new Exception(result.ErrorMessage);

                if (result.Output["OUT_TOTAL_ROW"] + "" != "")
                    total = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);
                return result.Value;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public StudentRecruitmentReportWeeklyModel GetById(string student_rcd, int reptort_week_rcd,int report_day_rcd)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String, student_rcd),
                    _dbHelper.CreateInParameter("@reptort_week_rcd",DbType.Int32, reptort_week_rcd),
                    _dbHelper.CreateInParameter("@report_day_rcd",DbType.Int32, report_day_rcd),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToFirstOrDefault<StudentRecruitmentReportWeeklyModel>("dbo.student_recruitment_report_weekly_get_by_id", parameters);
                if (!string.IsNullOrEmpty(result.ErrorMessage) && result.ErrorCode != 0)
                {
                    throw new Exception(result.ErrorMessage);
                }
                return result.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DropdownOptionModel> GetListDropdown()
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToList<DropdownOptionModel>("dbo.student_recruitment_report_get_list_dropdown", parameters);
                if (!string.IsNullOrEmpty(result.ErrorMessage) && result.ErrorCode != 0)
                {
                    throw new Exception(result.ErrorMessage);
                }
                return result.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(StudentRecruitmentReportWeeklyModel model)
        {
            try
            {

                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String,model.student_rcd),
                    _dbHelper.CreateInParameter("@reptort_week_rcd",DbType.Int32,model.reptort_week_rcd),
                    _dbHelper.CreateInParameter("@report_day_rcd",DbType.Int32,model.report_day_rcd),
                    _dbHelper.CreateInParameter("@job_assignment",DbType.String,model.job_assignment),
                    _dbHelper.CreateInParameter("@result_in_day",DbType.String,model.result_in_day),
                    _dbHelper.CreateInParameter("@description",DbType.String,model.description),
                    _dbHelper.CreateInParameter("@lu_user_id",DbType.Guid,model.created_by_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_recruitment_report_weekly_update", parameters);
                if ((result != null && !string.IsNullOrEmpty(result.ErrorMessage)) && result.ErrorCode != 0)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else if (result.Value != null && result.Value.ToString().IndexOf("MESSAGE") >= 0)
                {
                    throw new Exception(result.Value.ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
