using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.Common.Helper;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public partial class StudentReponsitory : IStudentReponsitory
    {
        private IDatabaseHelper _dbHelper;
        private IMajorReponsitory _major;

        public StudentReponsitory(IDatabaseHelper dbHelper, IMajorReponsitory major)
        {
            _dbHelper = dbHelper;
            _major = major;
        }
        public bool Update(StudentModel model)
        {
            try
            {
                if (model.father_year_of_birth == DateTime.MinValue)
                    model.father_year_of_birth = null;
                if (model.mother_year_of_birth == DateTime.MinValue)
                    model.mother_year_of_birth = null;
                var parameters = new List<IDbDataParameter>
                {
                     _dbHelper.CreateInParameter("@student_rcd",DbType.String,model.student_rcd),
                     _dbHelper.CreateInParameter("@student_name",DbType.String,model.student_name),
                     _dbHelper.CreateInParameter("@student_nationality",DbType.String,model.student_nationality),
                     _dbHelper.CreateInParameter("@student_nation",DbType.String,model.student_nation),
                     _dbHelper.CreateInParameter("@student_religion",DbType.String,model.student_religion),
                     _dbHelper.CreateInParameter("@student_countryside",DbType.String,model.student_countryside),
                     _dbHelper.CreateInParameter("@student_apartment_number",DbType.Int32,model.student_apartment_number),
                     _dbHelper.CreateInParameter("@student_health_insurance_code",DbType.String,model.student_health_insurance_code),
                     _dbHelper.CreateInParameter("@student_citizen_identity_card",DbType.String,model.student_citizen_identity_card),
                     _dbHelper.CreateInParameter("@student_citizen_identity_card_date",DbType.String,model.student_citizen_identity_card_date),
                     _dbHelper.CreateInParameter("@student_citizen_identity_card_place",DbType.String,model.student_citizen_identity_card_place),
                     _dbHelper.CreateInParameter("@student_phone_home",DbType.String,model.student_phone_home),
                     _dbHelper.CreateInParameter("@student_email",DbType.String,model.student_email),
                     _dbHelper.CreateInParameter("@student_phone",DbType.String,model.student_phone),
                     _dbHelper.CreateInParameter("@student_province_of_residence",DbType.String,model.student_province_of_residence),
                     _dbHelper.CreateInParameter("@student_resident_district",DbType.String,model.student_resident_district),
                     _dbHelper.CreateInParameter("@student_resident_ward",DbType.String,model.student_resident_ward),
                     _dbHelper.CreateInParameter("@student_address",DbType.String,model.student_address),
                     _dbHelper.CreateInParameter("@student_province_born",DbType.String,model.student_province_born),
                     _dbHelper.CreateInParameter("@student_district_born",DbType.String,model.student_district_born),
                     _dbHelper.CreateInParameter("@student_ward_born",DbType.String,model.student_ward_born),
                     _dbHelper.CreateInParameter("@student_address_receive",DbType.String,model.student_address_receive),
                     _dbHelper.CreateInParameter("@student_facebook_url",DbType.String,model.student_facebook_url),
                     _dbHelper.CreateInParameter("@student_card_photo",DbType.String,model.student_card_photo),
                     _dbHelper.CreateInParameter("@citizen_identification_photo",DbType.String,model.citizen_identification_photo),
                     _dbHelper.CreateInParameter("@cv_path",DbType.String,model.cv_path),

                     _dbHelper.CreateInParameter("@spouses_name",DbType.String,model.spouses_name),
                     _dbHelper.CreateInParameter("@spouses_nationality",DbType.String,model.spouses_nationality),
                     _dbHelper.CreateInParameter("@spouses_nation",DbType.String,model.spouses_nation),
                     _dbHelper.CreateInParameter("@spouses_religion",DbType.String,model.spouses_religion),
                     _dbHelper.CreateInParameter("@spouses_address",DbType.String,model.spouses_address),
                     _dbHelper.CreateInParameter("@spouses_work",DbType.String,model.spouses_work),
                     _dbHelper.CreateInParameter("@spouses_phone_number",DbType.String,model.spouses_phone_number),


                     _dbHelper.CreateInParameter("@father_name",DbType.String,model.father_name),
                     _dbHelper.CreateInParameter("@father_year_of_birth",DbType.DateTime,model.father_year_of_birth),
                     _dbHelper.CreateInParameter("@father_nationality",DbType.String,model.father_nationality),
                     _dbHelper.CreateInParameter("@father_nation",DbType.String,model.father_nation),
                     _dbHelper.CreateInParameter("@father_religion",DbType.String,model.father_religion),
                     _dbHelper.CreateInParameter("@father_permanent_residence",DbType.String,model.father_permanent_residence),
                     _dbHelper.CreateInParameter("@father_work",DbType.String,model.father_work),
                     _dbHelper.CreateInParameter("@father_phone_number",DbType.String,model.father_phone_number),
                     _dbHelper.CreateInParameter("@mother_name",DbType.String,model.mother_name),
                     _dbHelper.CreateInParameter("@mother_year_of_birth",DbType.DateTime,model.mother_year_of_birth),
                     _dbHelper.CreateInParameter("@mother_nationality",DbType.String,model.mother_nationality),
                     _dbHelper.CreateInParameter("@mother_nation",DbType.String,model.mother_nation),
                     _dbHelper.CreateInParameter("@mother_religion",DbType.String,model.mother_religion),
                     _dbHelper.CreateInParameter("@mother_permanent_residence",DbType.String,model.mother_permanent_residence),
                     _dbHelper.CreateInParameter("@mother_work",DbType.String,model.mother_work),
                     _dbHelper.CreateInParameter("@mother_phone_number",DbType.String,model.mother_phone_number),


                    _dbHelper.CreateInParameter("@lu_user_id",DbType.Guid,model.lu_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.student_update", parameters);
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
        public StudentModel GetById(string student_rcd)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String, student_rcd),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = 
                    _dbHelper.CallToFirstOrDefault<StudentModel>("dbo.student_get_by_id", parameters);
                if (!string.IsNullOrEmpty(result.ErrorMessage) && result.ErrorCode != 0)
                {
                    throw new Exception(result.ErrorMessage);
                }
                StudentModel student = new StudentModel();
                student = result.Value;

                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MajorRegisterModel GetMajorRegister(string student_rcd)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String, student_rcd),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result =
                    _dbHelper.CallToFirstOrDefault<MajorRegisterModel>("dbo.student_get_major_register_by_id", parameters);
                if (!string.IsNullOrEmpty(result.ErrorMessage) && result.ErrorCode != 0)
                {
                    throw new Exception(result.ErrorMessage);
                }
                MajorRegisterModel m = new MajorRegisterModel();
                m = result.Value;
                m.major_info = _major.GetById(m.major_id);
                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public StudentFamilyModel GetFamily(string student_rcd)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@student_rcd",DbType.String, student_rcd),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result =
                    _dbHelper.CallToFirstOrDefault<StudentFamilyModel>("dbo.student_get_family_by_id", parameters);
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
        public List<DropdownOptionModel> GetDistricts(char lang, string provinces_rcd)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@lang", DbType.String, lang),
                    _dbHelper.CreateInParameter("@id", DbType.String, provinces_rcd),

                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToList<DropdownOptionModel>("dbo.districts_ref_get_list_dropdown_by_id", parameters);
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
        public List<DropdownOptionModel> GetWards(char lang, string districts_rcd)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@lang", DbType.String, lang),
                    _dbHelper.CreateInParameter("@id", DbType.String, districts_rcd),

                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToList<DropdownOptionModel>("dbo.wards_ref_get_list_dropdown_by_id", parameters);
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
        public List<DropdownOptionModel> GetProvinces(char lang)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@lang", DbType.String, lang),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToList<DropdownOptionModel>("dbo.provinces_ref_get_list_dropdown", parameters);
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