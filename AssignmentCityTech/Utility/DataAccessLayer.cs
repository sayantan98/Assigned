using AssignmentCityTech.Models;
using System.Data;
using System.Data.SqlClient;

namespace AssignmentCityTech.Utility
{
    public class DataAccessLayer
    {
        DbContext _dbContext;
        public DataAccessLayer() {
            _dbContext = new DbContext();
        }
        

        public List<VendorModel> GetAllVendor()
        {
            try
            {
                List<VendorModel> lstStudent = new List<VendorModel>();
                using (SqlConnection con = new SqlConnection(_dbContext.CName))
                {
                    SqlCommand cmd = new SqlCommand("dbo.GetVendorList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VendorModel vendorModel = new VendorModel();
                        vendorModel.VendorCode = rdr["VendorCode"].ToString();
                        vendorModel.VendorName = rdr["VendorName"].ToString();
                        vendorModel.Address = rdr["Address"].ToString();
                        vendorModel.EmailId = rdr["EmailId"].ToString();
                        vendorModel.ContactPerson = rdr["ContactPerson"].ToString();

                        lstStudent.Add(vendorModel);
                    }
                    con.Close();
                }

                return lstStudent;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ReturnModel AddStudent(VendorModel student)
        {
            ReturnModel returnModel = new ReturnModel();
            try
            {
                using (SqlConnection con = new SqlConnection(_dbContext.CName))
                {
                    SqlCommand cmd = new SqlCommand("spAddStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", student.VendorCode);
                    cmd.Parameters.AddWithValue("@LastName", student.VendorName);
                    cmd.Parameters.AddWithValue("@Email", student.EmailId);
                    cmd.Parameters.AddWithValue("@Mobile", student.ContactPerson);
                    cmd.Parameters.AddWithValue("@Address", student.PaymentTermsDayName);
                    SqlParameter outputIdParam = new SqlParameter("@OutputId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);
                    SqlParameter outputMsgParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 5000)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputMsgParam);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    returnModel.Flag = outputIdParam.Value as int? ?? default(int);
                    returnModel.Message = outputMsgParam.Value as string ?? default(string);
                    con.Close();
                    return returnModel;
                }
            }
            catch (Exception ex)
            {
                returnModel.Flag = -1;
                returnModel.Message = ex.Message;
                return returnModel;
            }
        }

        public void UpdateStudent(VendorModel student)
        {
            using (SqlConnection con = new SqlConnection(_dbContext.CName))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", student.VendorCode);
                cmd.Parameters.AddWithValue("@LastName", student.VendorName);
                cmd.Parameters.AddWithValue("@Email", student.EmailId);
                cmd.Parameters.AddWithValue("@Mobile", student.ContactPerson);
                cmd.Parameters.AddWithValue("@Address", student.PaymentTermsDayName);
                cmd.Parameters.Add(new SqlParameter("@OutputId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output,
                });
                cmd.Parameters.Add(new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 5000)
                {
                    Direction = ParameterDirection.Output,
                });
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
