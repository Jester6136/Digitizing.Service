using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.Common.Helper;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public partial class MajorReponsitory : IMajorReponsitory
    {
        private IDatabaseHelper _dbHelper;
        public MajorReponsitory(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public MajorModel GetById(Guid majors_id)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@majors_id",DbType.Guid, majors_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = 
                    _dbHelper.CallToFirstOrDefault<MajorModel>("dbo.student_majors_get_by_id", parameters);
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
       

    }
}