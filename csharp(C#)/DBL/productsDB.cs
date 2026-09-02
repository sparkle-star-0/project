using MySqlConnector;
using System.Data;
using static System.Net.Mime.MediaTypeNames;




namespace DBL;

public class productsDB
{
    public DataRow getProductsById(int id)
    {
        using (var connection = new MySqlConnection(connectionstring))
        {
            connection.Open();
            string query = "SELECT * FROM products WHERE product_id = @id";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    
                    adapter.Fill(dt);
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }
    }
    private string connectionstring = "server=localhost;database=shop_db;uid=root;pwd=;charset=utf8mb4;";
    public void updateStock(int id)
    {

        using (var con = new MySqlConnection(connectionstring))
        {
            con.Open();
            string update = "UPDATE products SET stock = stock - 1 WHERE product_id =@id";
            using (var cmd = new MySqlCommand(update, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                int run = cmd.ExecuteNonQuery();
            }
            
        }

    }
    public void addStock(int id, int stock)
    {
        using (var connection = new MySqlConnection(connectionstring))
        {
            connection.Open();
            string query = "UPDATE products SET stock = @stock WHERE product_id =@id";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@stock", stock);
                int run = cmd.ExecuteNonQuery();


            }
        }
    }
    public void addprice(int id , int price)
    {
        using(var con = new MySqlConnection(connectionstring))
        {
            con.Open();
            string query = "UPDATE products SET price = @price WHERE product_id = @id";
            using(var cmd = new MySqlCommand (query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@price", price);
                int run = cmd.ExecuteNonQuery();
            }
        }
    }
    public byte[] loadPicProductBytes(int id)
    {
        using (var con = new MySqlConnection(connectionstring)) 
        { 
            con.Open();
            string query = "SELECT photos FROM products WHERE product_id = @id";
            using(var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                object result = cmd.ExecuteScalar();
                Byte[] photo = (Byte[])result;
                return photo;

            }
        }
    }
    public DataTable getAllProducts()
    {
        using (var connection = new MySqlConnection(connectionstring))
        {
            connection.Open();

            string query = "SELECT * FROM products";

            using (var cmd = new MySqlCommand(query, connection))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                return dt;
            }
        }
    }
    public void editProduct(int id ,int price , int stock , string title , string details , byte[] image)
    {
        if (image == null)
        {
           image = loadPicProductBytes(id);
        }
        using (var connection = new MySqlConnection(connectionstring))
        {
            connection.Open();
            string query = "UPDATE products SET stock = @stock , price = @price" +
                ", detile = @details,title = @title,photos = @image WHERE product_id =@id";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@details", details);
                cmd.Parameters.AddWithValue("@image", image);
                int run = cmd.ExecuteNonQuery();


            }
        }
    }
    public void registerProduct( int price,int stock , string title , string details , byte[] image )
    {
        using (var connection = new MySqlConnection(connectionstring))
        {
            connection.Open();
            string query = "INSERT INTO products (price , title , detile , stock , photos ) VALUES (@price , @title , @details , @stock , @image) ";
            using (var cmd = new MySqlCommand(query, connection))
            {
                
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@details", details);
                cmd.Parameters.AddWithValue("@image", image);
                int run = cmd.ExecuteNonQuery();


            }
        }
    }
    public void deleteProductById(int id )
    {
        using (var connection = new MySqlConnection(connectionstring))
        {
            connection.Open();
            string query = "DELETE FROM products WHERE product_id = @id ";
            using (var cmd = new MySqlCommand(query, connection))
            {

                cmd.Parameters.AddWithValue("@id", id);
                int run = cmd.ExecuteNonQuery();


            }
        }
    }
    public void setOffer(int id, int offer) 
    {
        using (var con = new MySqlConnection(connectionstring))
        {
            con.Open();
            string query = "UPDATE products SET offer = @offer WHERE product_id = @id";
            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@offer",offer);
                int run = cmd.ExecuteNonQuery();
            }
        }
    }
}
