namespace User.DAL;

using User.Model;
using MySql.Data.MySqlClient;
public class UserDataAccess{

    public static string constring = @"server=localhost;username=root;password=root123;database=userinfo";

    public static List<Users> GetAllUser(){
        List<Users> alluser = new List<Users>();

        MySqlConnection con = new MySqlConnection(constring);
        try{
            con.Open();
            string query = "Select * from user";
            MySqlCommand command = new MySqlCommand(query,con);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read()){

                int userid = int.Parse(reader["userid"].ToString());
                string username = reader["username"].ToString();
                string course = reader["course"].ToString();
                Users user = new Users(userid,username,course);

                alluser.Add(user);
            }

        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
        return alluser;
    }

    public static Users GetUserById(int id){
        
        Users user = null;
       MySqlConnection con = new MySqlConnection(constring);
       string query = "Select * from user where userid = "+id;
       try{
        con.Open();
        MySqlCommand command = new MySqlCommand(query,con);
        MySqlDataReader reader = command.ExecuteReader();
        if(reader.Read()){

            int userid = int.Parse(reader["userid"].ToString());
            string username = reader["username"].ToString();
            string course = reader["course"].ToString();
            user = new Users(userid,username,course);
        }
       }
       catch(Exception e){
        Console.WriteLine(e.Message);
       }
       finally{
        con.Close();
       }
       return user;
    }
}