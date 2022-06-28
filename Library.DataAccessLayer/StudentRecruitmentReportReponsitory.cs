using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.Common.Helper;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public partial class StudentRecruitmentReportWeeklyReponsitory : IStudentRecruitmentReportReponsitory
    {
        private IDatabaseHelper _dbHelper;

        public StudentRecruitmentReportWeeklyReponsitory(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        List<StudentRecruitmentReportModel> IStudentRecruitmentReportReponsitory.Search(int pageIndex, int pageSize, out long total, string student_rcd, string report_week)
        {
            total = 0;
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@page_index", DbType.Int32, pageIndex),
                    _dbHelper.CreateInParameter("@page_size", DbType.Int32,  pageSize),
                    _dbHelper.CreateInParameter("@student_rcd" ,DbType.String,student_rcd),
                    _dbHelper.CreateInParameter("@report_week" ,DbType.Int32,report_week),
                    _dbHelper.CreateOutParameter("@OUT_TOTAL_ROW", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToList<StudentRecruitmentReportModel>("dbo.student_recruitment_report_search", parameters);
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
        public StudentRecruitmentReportModel GetById(string student_rcd, int report_week,int report_day)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String, student_rcd),
                    _dbHelper.CreateInParameter("@report_week",DbType.Int32, report_week),
                    _dbHelper.CreateInParameter("@report_day",DbType.Int32, report_day),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToFirstOrDefault<StudentRecruitmentReportModel>("dbo.student_recruitment_report_weekly_get_by_id", parameters);
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
        public InternshipProcessEvaluateModel GetInternshipProcessEvaluateById(string student_rcd, int report_week)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String, student_rcd),
                    _dbHelper.CreateInParameter("@report_week",DbType.Int32, report_week),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToFirstOrDefault<InternshipProcessEvaluateModel>("dbo.internship_process_evaluate_get_by_id", parameters);
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
        public StudentRecruitmentReportModel GetStudentRecuitmentReportById(string student_rcd)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String, student_rcd),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToFirstOrDefault<StudentRecruitmentReportModel>("dbo.student_recruitment_report_get_by_id", parameters);
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
        public bool UpdateReport(StudentRecruitmentReportModel model)
        {
            return true;
            //try
            //{
            //    var parameters = new List<IDbDataParameter>
            //    {
            //        _dbHelper.CreateInParameter("@student_rcd",DbType.String,model.student_rcd),
            //        _dbHelper.CreateInParameter("@recruitment_id",DbType.Guid,model.recruitment_id),
            //        _dbHelper.CreateInParameter("@report_doc",DbType.String,model.report_doc),
            //        _dbHelper.CreateInParameter("@lu_user_id",DbType.Guid,model.created_by_user_id),
            //        _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
            //        _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
            //    };
            //    var result = _dbHelper.CallToValueWithTransaction("dbo.student_recruitment_report_update", parameters);
            //    if ((result != null && !string.IsNullOrEmpty(result.ErrorMessage)) && result.ErrorCode != 0)
            //    {
            //        throw new Exception(result.ErrorMessage);
            //    }
            //    else if (result.Value != null && result.Value.ToString().IndexOf("MESSAGE") >= 0)
            //    {
            //        throw new Exception(result.Value.ToString());
            //    }
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
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
        public bool Update(StudentRecruitmentReportModel model)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_recruitment_report_id",DbType.Guid,model.student_recruitment_report_id),
                    _dbHelper.CreateInParameter("@description",DbType.String,model.description),
                    _dbHelper.CreateInParameter("@job_assignment",DbType.String,model.job_assignment),
                    _dbHelper.CreateInParameter("@result_in_day",DbType.String,model.result_in_day),
                    _dbHelper.CreateInParameter("@lu_user_id",DbType.Guid,model.created_by_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_recruitment_report_update", parameters);
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

        public bool Create(StudentRecruitmentReportModel model)
        {
            try
            {
                model.student_recruitment_report_id = Guid.NewGuid();
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_recruitment_report_id",DbType.Guid,model.student_recruitment_report_id),
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String,model.student_rcd),
                    _dbHelper.CreateInParameter("@report_week",DbType.Int32,model.report_week),
                    _dbHelper.CreateInParameter("@report_day",DbType.Int32,model.report_day),
                    _dbHelper.CreateInParameter("@description",DbType.String,model.description),
                    _dbHelper.CreateInParameter("@job_assignment",DbType.String,model.job_assignment),
                    _dbHelper.CreateInParameter("@result_in_day",DbType.String,model.result_in_day),
                    _dbHelper.CreateInParameter("@created_by_user_id",DbType.Guid,model.created_by_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_recruitment_report_create", parameters);
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
