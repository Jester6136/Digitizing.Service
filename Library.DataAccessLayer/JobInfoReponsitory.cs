using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.Common.Helper;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public partial class JobInfoReponsitory : IJobInfoReponsitory
    {
        private IDatabaseHelper _dbHelper;
        private IEnterpriseReponsitory _enterprise;

        public JobInfoReponsitory(IDatabaseHelper dbHelper, IEnterpriseReponsitory enterprise)
        {
            _dbHelper = dbHelper;
            _enterprise = enterprise;
        }
        public List<JobInfoModel> Search(int pageIndex, int pageSize, char lang
            , out long total, string keyword, string provinces_rcd)
        {
            total = 0;
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@page_index", DbType.Int32, pageIndex),
                    _dbHelper.CreateInParameter("@page_size", DbType.Int32, pageSize),
                    _dbHelper.CreateInParameter("@lang", DbType.String, lang),
                    _dbHelper.CreateInParameter("@keyword" ,DbType.String, keyword),
                    _dbHelper.CreateInParameter("@provinces_rcd",
                    DbType.String, provinces_rcd),
                    _dbHelper.CreateOutParameter("@OUT_TOTAL_ROW", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToList<JobInfoModel>("dbo.student_job_info_search", parameters);

                if (!string.IsNullOrEmpty(result.ErrorMessage) && result.ErrorCode != 0)
                    throw new Exception(result.ErrorMessage);

                if (result.Output["OUT_TOTAL_ROW"] + "" != "")
                    total = Convert.ToInt32(result.Output["OUT_TOTAL_ROW"]);

                List<JobInfoModel> list = new List<JobInfoModel>();
                list = result.Value;

                foreach (JobInfoModel item in list)
                    item.enterprise = _enterprise.GetById(item.enterprise_id);

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}