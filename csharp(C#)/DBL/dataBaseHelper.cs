using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;
using System.Security.Cryptography;



namespace shop.Models;

public class dataBaseHelper
{
   private string connectionstring = "server=localhost;database=shop_db;uid=root;pwd=;charset=utf8mb4;";
    public bool testconnect()
    {
        try
        {
            using (var connection = new MySqlConnection(connectionstring))
            {
                
                connection.Open();
                return true;
               
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show("connetionErorr" + ex.Message);
            return false;
        }
    }
    
    
   
}
