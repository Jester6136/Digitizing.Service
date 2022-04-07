using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.Common.Helper;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public partial class ProjectReponsitory : IProjectReponsitory
    {
        private IDatabaseHelper _dbHelper;
        private ISubjectReponsitory _subject;
        private ITeacherReponsitory _teacher;
        private IStudentReponsitory _student;

        public ProjectReponsitory(IDatabaseHelper dbHelper, ISubjectReponsitory subject,
            ITeacherReponsitory teacher, IStudentReponsitory student)
        {
            _dbHelper = dbHelper;
            _subject = subject;
            _teacher = teacher;
            _student = student;
        }
        public ReportModel GetReport(Guid student_project_register_id)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_project_register_id", DbType.Guid, student_project_register_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result =
                    _dbHelper.CallToFirstOrDefault<ReportModel>("dbo.student_project_get_report", parameters);
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
        public ProjectModel GetProjectInfo(Guid student_project_id)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_project_id", DbType.Guid, student_project_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result =
                    _dbHelper.CallToFirstOrDefault<ProjectModel>("dbo.student_project_get_by_id", parameters);
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
        public List<ProjectRegisterModel> Search(int pageIndex, int pageSize
           , out long total, string student_rcd)
        {
            total = 0;
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@page_index", DbType.Int32, pageIndex),
                    _dbHelper.CreateInParameter("@page_size", DbType.Int32, pageSize),
                    _dbHelper.CreateInParameter("@student_rcd" ,DbType.String, student_rcd),

                    _dbHelper.CreateOutParameter("@OUT_TOTAL_ROW", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result =
                _dbHelper.CallToList<ProjectRegisterModel>("dbo.student_project_search", parameters);

                if (!string.IsNullOrEmpty(result.ErrorMessage) && result.ErrorCode != 0)
                    throw new Exception(result.ErrorMessage);

                if (result.Output["OUT_TOTAL_ROW"] + "" != "")
                    total = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);

                List<ProjectRegisterModel> list = new List<ProjectRegisterModel>();
                list = result.Value;

                foreach (ProjectRegisterModel item in list)
                {
                    item.project = GetProjectInfo(item.student_project_id);
                    item.project.subject_info = _subject.GetById(item.project.student_subject_rcd);
                    item.report = GetReport(item.student_project_register_id);
                    item.teacher_information = _teacher.GetById(item.teacher_rcd);
                    item.student_information = _student.GetById(item.student_rcd);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ProjectRegisterModel> SearchMember(int pageIndex, int pageSize
           , out long total, Guid student_project_id)
        {
            total = 0;
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@page_index", DbType.Int32, pageIndex),
                    _dbHelper.CreateInParameter("@page_size", DbType.Int32, pageSize),
                    _dbHelper.CreateInParameter("@student_project_id" ,DbType.Guid, student_project_id),

                    _dbHelper.CreateOutParameter("@OUT_TOTAL_ROW", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result =
                _dbHelper.CallToList<ProjectRegisterModel>("dbo.student_project_register_search", parameters);

                if (!string.IsNullOrEmpty(result.ErrorMessage) && result.ErrorCode != 0)
                    throw new Exception(result.ErrorMessage);

                if (result.Output["OUT_TOTAL_ROW"] + "" != "")
                    total = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);

                List<ProjectRegisterModel> list = new List<ProjectRegisterModel>();
                list = result.Value;

                foreach (ProjectRegisterModel item in list)
                {
                    item.project = GetProjectInfo(item.student_project_id);
                    item.project.subject_info = _subject.GetById(item.project.student_subject_rcd);
                    item.report = GetReport(item.student_project_register_id);
                    item.teacher_information = _teacher.GetById(item.teacher_rcd);
                    item.student_information = _student.GetById(item.student_rcd);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProjectRegisterModel GetById(Guid student_project_register_id)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_project_register_id",DbType.Guid, student_project_register_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result =
                _dbHelper.CallToFirstOrDefault<ProjectRegisterModel>("dbo.student_project_register_get_by_id", parameters);
                if (!string.IsNullOrEmpty(result.ErrorMessage) && result.ErrorCode != 0)
                {
                    throw new Exception(result.ErrorMessage);
                }

                ProjectRegisterModel register = new ProjectRegisterModel();
                register = result.Value;
                register.project = GetProjectInfo(register.student_project_id);
                register.project.subject_info = _subject.GetById(register.project.student_subject_rcd);
                register.report = GetReport(register.student_project_register_id);
                register.teacher_information = _teacher.GetById(register.teacher_rcd);
                register.student_information = _student.GetById(register.student_rcd);

                return register;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(ProjectRegisterModel register)
        {
            try
            {
                //register.project = new ProjectModel();
                register.report = new ReportModel();

                if (register.project.student_project_id == Guid.Empty) 
                    register.project.student_project_id = Guid.NewGuid();
                if (register.student_project_register_id == Guid.Empty) 
                    register.student_project_register_id = Guid.NewGuid();
                if (register.report.report_id == Guid.Empty) register.report.report_id = Guid.NewGuid();
                
                register.student_project_id = register.project.student_project_id;
                register.report.student_project_register_id = register.student_project_register_id;

                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_project_id", DbType.Guid, register.project.student_project_id),
                    _dbHelper.CreateInParameter("@teacher_rcd", DbType.String,  register.teacher_rcd),
                    _dbHelper.CreateInParameter("@student_class_rcd", DbType.String,  register.project.student_class_rcd),
                    _dbHelper.CreateInParameter("@student_subject_rcd", DbType.String,  register.project.student_subject_rcd),
                    _dbHelper.CreateInParameter("@student_project_type", DbType.Int32,  register.project.student_project_type),

                    _dbHelper.CreateInParameter("@student_project_register_id", DbType.Guid,
                    register.student_project_register_id),
                    _dbHelper.CreateInParameter("@student_rcd", DbType.String, register.student_rcd),

                    _dbHelper.CreateInParameter("@report_id", DbType.Guid, register.report.report_id),

                    _dbHelper.CreateInParameter("@created_by_user_id", DbType.Guid, register.created_by_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_project_create", parameters);
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
        public bool CreateMember(ProjectRegisterModel register)
        {
            try
            {
                register.report = new ReportModel();

                if (register.student_project_register_id == Guid.Empty)
                    register.student_project_register_id = Guid.NewGuid();

                if (register.report.report_id == Guid.Empty)
                    register.report.report_id = Guid.NewGuid();

                register.report.student_project_register_id = register.student_project_register_id;

                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_project_register_id", DbType.Guid, register.student_project_register_id),
                    _dbHelper.CreateInParameter("@student_rcd", DbType.String,  register.student_rcd),
                    _dbHelper.CreateInParameter("@teacher_rcd", DbType.String,  register.teacher_rcd),
                    _dbHelper.CreateInParameter("@student_project_id", DbType.Guid,  register.student_project_id),
                    _dbHelper.CreateInParameter("@report_id", DbType.Guid, register.report.report_id),

                    _dbHelper.CreateInParameter("@student_subject_rcd", DbType.String,  register.project.student_subject_rcd),
                    _dbHelper.CreateInParameter("@student_class_rcd", DbType.String ,  register.project.student_class_rcd),

                    _dbHelper.CreateInParameter("@created_by_user_id", DbType.Guid, register.created_by_user_id),
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

        public bool Update(ProjectRegisterModel register)
        {
            try
            {
                Console.WriteLine(register); 
                var parameters = new List<IDbDataParameter>
                {
                     _dbHelper.CreateInParameter("@student_project_register_id",
                     DbType.Guid, register.student_project_register_id),
                     _dbHelper.CreateInParameter("@student_project_id",
                     DbType.Guid, register.student_project_id),
                     _dbHelper.CreateInParameter("@student_project_title", DbType.String, 
                     register.project.student_project_title),
                     _dbHelper.CreateInParameter("@student_project_detail", DbType.String,
                     register.project.student_project_detail),
                     _dbHelper.CreateInParameter("@report_url", DbType.String,
                     register.report.report_url),
                     _dbHelper.CreateInParameter("@lu_user_id", DbType.Guid, register.lu_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_project_update", parameters);
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
        public bool Delete(ProjectRegisterModel register)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_project_register_id",
                    DbType.Guid, register.student_project_register_id),
                    _dbHelper.CreateInParameter("@student_project_id",
                    DbType.Guid, register.student_project_id),
                    _dbHelper.CreateInParameter("@report_id",
                    DbType.Guid, register.report.report_id),
                    _dbHelper.CreateInParameter("@teacher_rcd", 
                    DbType.String, register.teacher_rcd),
                    _dbHelper.CreateInParameter("@class_rcd",
                    DbType.String, register.project.student_class_rcd),
                    _dbHelper.CreateInParameter("@course_rcd", 
                    DbType.String, register.project.student_subject_rcd),
                    
                    _dbHelper.CreateInParameter("@lu_user_id", DbType.Guid, register.lu_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_project_delete_multi", parameters);
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