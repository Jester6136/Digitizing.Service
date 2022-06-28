using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.Common.Helper;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public partial class ProjectReportReponsitory : IProjectReportReponsitory
    {
        private IDatabaseHelper _dbHelper;

        public ProjectReportReponsitory(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(ProjectReportModel model)
        {
            try
            {

                if (model.student_project_report_id == Guid.Parse("00000000-0000-0000-0000-000000000000")) model.student_project_report_id = Guid.NewGuid();
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String,model.student_rcd),
                    _dbHelper.CreateInParameter("@project_type",DbType.Int32,model.project_type),
                    _dbHelper.CreateInParameter("@student_project_report_id",DbType.Guid,model.student_project_report_id),
                    _dbHelper.CreateInParameter("@report_week",DbType.Int32,model.report_week),
                    _dbHelper.CreateInParameter("@report_url",DbType.String,model.report_url),
                    _dbHelper.CreateInParameter("@report_final_file",DbType.String,model.report_final_file),
                    _dbHelper.CreateInParameter("@created_by_user_id",DbType.Guid,model.created_by_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_project_report_create", parameters);
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

        public List<ProjectReportModel> Search(int pageIndex, int pageSize,
            out long total, string project_type, string student_rcd)
        {
            total = 0;
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@page_index", DbType.Int32, pageIndex),
                    _dbHelper.CreateInParameter("@page_size", DbType.Int32,  pageSize),
                    _dbHelper.CreateInParameter("@project_type" ,DbType.Int32,project_type),
                    _dbHelper.CreateInParameter("@student_rcd" ,DbType.String,student_rcd),
                    _dbHelper.CreateOutParameter("@OUT_TOTAL_ROW", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToList<ProjectReportModel>("dbo.student_project_report_search", parameters);
                if (!string.IsNullOrEmpty(result.ErrorMessage) && result.ErrorCode != 0)
                    throw new Exception(result.ErrorMessage);

                if (result.Output["OUT_TOTAL_ROW"] + "" != "")
                    total = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);
                return result.Value;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Update(ProjectReportModel model)
        {
            try
            {

                var parameters = new List<IDbDataParameter>
                {
                     _dbHelper.CreateInParameter("@student_project_report_id",DbType.Guid,model.student_project_report_id),
                     _dbHelper.CreateInParameter("@student_project_register_id",DbType.Guid,model.student_project_register_id),
                     _dbHelper.CreateInParameter("@report_week",DbType.Int32,model.report_week),
                     _dbHelper.CreateInParameter("@report_url",DbType.String,model.report_url),
                     _dbHelper.CreateInParameter("@report_final_file",DbType.String,model.report_final_file),
                     _dbHelper.CreateInParameter("@lu_user_id",DbType.Guid,model.lu_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_project_report_update", parameters);
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
