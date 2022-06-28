using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.Common.Helper;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public partial class ProjectRegisterReponsitory : IProjectRegisterReponsitory
    {
        private IDatabaseHelper _dbHelper;

        public ProjectRegisterReponsitory(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public bool Create(ProjectRegisterModel model)
        {
            try
            {
                if (model.student_project_register_id == Guid.Empty) model.student_project_register_id = Guid.NewGuid();
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_project_register_id",DbType.Guid,model.student_project_register_id),
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String,model.student_rcd),
                    _dbHelper.CreateInParameter("@teacher_pro_id",DbType.Guid,model.teacher_pro_id),
                    _dbHelper.CreateInParameter("@created_by_user_id",DbType.Guid,model.created_by_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_project_register_create", parameters);
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

        public ProjectRegisterModel GetById(string student_rcd, int project_type)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String, student_rcd),
                    _dbHelper.CreateInParameter("@project_type",DbType.Int32, project_type),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToFirstOrDefault<ProjectRegisterModel>("dbo.student_project_register_get_by_id", parameters);
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
        public bool Delete(ProjectRegisterModel model)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_rcd", DbType.String, model.student_rcd),
                    _dbHelper.CreateInParameter("@teacher_pro_id", DbType.Guid, model.teacher_pro_id),
                    _dbHelper.CreateInParameter("@lu_user_id", DbType.Guid, model.lu_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_project_register_delete", parameters);
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
        public bool Update(ProjectRegisterModel model)
        {
            try
            {

                var parameters = new List<IDbDataParameter>
                {
                     _dbHelper.CreateInParameter("@student_rcd",DbType.String,model.student_rcd),
                     _dbHelper.CreateInParameter("@project_type",DbType.Int32,model.project_type),
                     _dbHelper.CreateInParameter("@student_project_name",DbType.String,model.student_project_name),
                     _dbHelper.CreateInParameter("@project_register_status",DbType.Int32,model.project_register_status),
                     _dbHelper.CreateInParameter("@lu_user_id",DbType.Guid,model.lu_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_project_register_update", parameters);
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
