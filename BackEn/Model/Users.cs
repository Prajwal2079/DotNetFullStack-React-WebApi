namespace User.Model;
using System.ComponentModel.DataAnnotations;

public class Users
{

    public int userid { get; set; }
    [Required]
    public string username { get; set; }
    [Required]
    public string course { get; set; }

    public Users(int userid,string username, string course)
    {
        this.userid = userid;
        this.username = username;
        this.course = course;
    }
}