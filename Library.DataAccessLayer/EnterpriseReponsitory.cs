using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.Common.Helper;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public partial class EnterpriseReponsitory : IEnterpriseReponsitory
    {
        private IDatabaseHelper _dbHelper;
        public EnterpriseReponsitory(IDatabaseHelper dbHelper/*, IJobInfoReponsitory jobInfo*/)
        {
            _dbHelper = dbHelper;
        }
        public EnterpriseModel GetById(Guid? id)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@enterprise_id",DbType.Guid, id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = 
                    _dbHelper.CallToFirstOrDefault<EnterpriseModel>("dbo.student_enterprise_get_by_id", parameters);
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