using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.Common.Helper;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public partial class TeacherProjectReponsitory : ITeacherProjectReponsitory
    {
        private IDatabaseHelper _dbHelper;
        private ITeacherReponsitory _teacher;

        public TeacherProjectReponsitory(IDatabaseHelper dbHelper,
            ITeacherReponsitory teacher)
        {
            _dbHelper = dbHelper;
            _teacher = teacher;
        }
        public List<TeacherProjectModel> Search(int pageIndex, int pageSize
            , out long total, string student_rcd, int project_type)
        {
            total = 0;
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@page_index", DbType.Int32, pageIndex),
                    _dbHelper.CreateInParameter("@page_size", DbType.Int32, pageSize),
                    _dbHelper.CreateInParameter("@student_rcd" ,DbType.String, student_rcd),
                    _dbHelper.CreateInParameter("@project_type" ,DbType.Int32, project_type),

                    _dbHelper.CreateOutParameter("@OUT_TOTAL_ROW", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToList<TeacherProjectModel>("dbo.student_teacher_project_search", parameters);

                if (!string.IsNullOrEmpty(result.ErrorMessage) && result.ErrorCode != 0)
                    throw new Exception(result.ErrorMessage);

                if (result.Output["OUT_TOTAL_ROW"] + "" != "")
                    total = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);

                return result.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}