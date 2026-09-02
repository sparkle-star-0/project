using MySqlConnector;


using shop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DBL;

public class userHelper
{
    private string connectionstring = "server=localhost;database=shop_db;uid=root;pwd=;charset=utf8mb4;";
    public bool passAddress = false;
    public bool passinfo = false;
    public customer getUserInfoById(int user_id)
    {
        customer result = new customer();
        using (var connection = new MySqlConnection(connectionstring))
        {
            connection.Open();
            string query = "SELECT * FROM users WHERE user_id = @user_id";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@user_id", user_id);
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DataRow dr = dt.Rows[0];
                    string FN = dr["first_name"].ToString();
                    string LN = dr["last_name"].ToString();
                    string NC = dr["nasional_code"].ToString();
                    string UN = dr["username"].ToString();
                    string PW = dr["password"].ToString();
                    result = customer.register_customer(FN, LN, NC, UN, PW);
                    return result;
                }
            }
        }
        
    }
    public address[] getAddressById(int user_id)
    {
        address[] result = new address[0];
        using (var connection = new MySqlConnection(connectionstring))
        {
            connection.Open();
            string query = "SELECT * FROM address WHERE user_id = @user_id";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@user_id", user_id);
                using (var adapter = new MySqlDataAdapter(cmd))
                {

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count == 0)
                        return result;
                    result = new address[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        string title = dr["Title"].ToString();
                        string detail = dr["details"].ToString();
                        string postCode = dr["postal_code"].ToString();
                        result[i] = address.register_address(title, detail, postCode);


                    }

                    return result;


                }
            }
        }
    }
    public int findUserId(string userName)
    {
        int id;
        using (var connection = new MySqlConnection(connectionstring))
        {
            connection.Open();
            string query = "SELECT user_id FROM users WHERE username = @userName ";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@userName", userName);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    id = Convert.ToInt16(result);
                }
                else
                {
                    id = -1;
                }
                return id;

            }
        }
    }
    public byte[] loadPicUsersBytes(int id)
    {
        using (var con = new MySqlConnection(connectionstring))
        {
            con.Open();
            string query = "SELECT image FROM users WHERE user_id = @id";
            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                object result = cmd.ExecuteScalar();
                Byte[] photo = (Byte[])result;
                return photo;

            }
        }
    }
    public void updateUserInfo(int id, string fName, string lName, string nCode)
    {
        using (var con = new MySqlConnection(connectionstring))
        {
            con.Open();
            string query = "UPDATE users SET first_name = @fName , last_name = @lName , nasional_code = @nCode WHERE user_id =@id";
            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fName", fName);
                cmd.Parameters.AddWithValue("@lName", lName);
                cmd.Parameters.AddWithValue("@nCode", nCode);
                int run = cmd.ExecuteNonQuery();
            }

        }
        passinfo = true;
    }
    public void updateUserAddress(int id, string title, string details, string postalCode)
    {

        using (var con = new MySqlConnection(connectionstring))
        {
            con.Open();
            string query = "UPDATE address SET title = @aTitle , details = @aDetails , postal_code = @aPostalCode WHERE user_id =@id";
            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@aTitle", title);
                cmd.Parameters.AddWithValue("@aDetails", details);
                cmd.Parameters.AddWithValue("@aPostalCode", postalCode);
                int run = cmd.ExecuteNonQuery();
            }

        }
        passAddress = true;
    }
    public bool checkAddress(string title, string detail, string postalCode)
    {
        bool valid = false;
        if (title != null & detail != null & postalCode != null)
        {
            if (title.Length <= 2)
            {
                throw new Exception(message: "عنوان نادرست است ");

            }
            else if (detail.Length <= 10)
            {
                throw new Exception(message: "آدرس نادرست است");

            }
            else if (postalCode.Length < 12)
            {
                throw new Exception(message: " کد پستی  نادرست است  ");

            }
            else if (!postalCode.All(char.IsDigit))
            {
                throw new Exception(message: "کد پستی باید تماما شامل اعداد باشد");
            }
            else
            {
                valid = true;
            }

        }
        return valid;
    }
    public bool checkInfoUser(string fName, string lName, string nasionalCode)
    {
        bool valid = false;
        if (fName.Trim().Length < 3)
        {
            throw new Exception(message: "نام وارد شده غلط است ");
        }
        else if (lName.Trim().Length < 3)
        {
            throw new Exception(message: "نام خانوادگی وارد شده غلط است ");
        }
        else if (nasionalCode.Trim().Length < 10)
        {
            throw new Exception(message: "کد ملی وارد شده غلط است ");
        }
        else if (!nasionalCode.All(char.IsDigit))
        {
            throw new Exception(message: "کد ملی فقط شامل اعداد میباشد ");
        }
        else
        {
            valid = true;
        }
        return valid;
    }

}
