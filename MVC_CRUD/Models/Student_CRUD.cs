using System.Data.SqlClient;

namespace MVC_CRUD.Models
{
    public class Student_CRUD
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public Student_CRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }
        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> list = new List<Student>();
            string qry = "select * from student where isActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student s = new Student();
                   s.Id = Convert.ToInt32(dr["id"]);
                   s.Name = dr["name"].ToString();
                   s.DOB = Convert.ToDateTime(dr["dob"]);
                   s.Percentage = Convert.ToDouble(dr["percentage"]);
                   s.isActive = Convert.ToInt32(dr["isActive"]);
                    list.Add(s);


                }
            }
            con.Close();
            return list;
        }
        public Student GetStudentById(int id)
        {
            Student s = new Student();
            string qry = "select * from student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    s.Id = Convert.ToInt32(dr["id"]);
                    s.Name = dr["name"].ToString();
                    s.DOB = Convert.ToDateTime(dr["dob"]);
                    s.Percentage = Convert.ToDouble(dr["percentage"]);
                }
            }
            con.Close();
            return s;
        }
        public int AddStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "insert into student values(@name,@dob,@percentage,@isActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@dob", student.DOB);
            cmd.Parameters.AddWithValue("@percentage", student.Percentage);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
        public int UpdateStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "update student set name=@name,dob=@dob,percentage=@percentage,isActive=@isActive where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@dob", student.DOB);
            cmd.Parameters.AddWithValue("@percentage", student.Percentage);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            cmd.Parameters.AddWithValue("@id", student.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        // soft delete --> record should be present in DB , but should not visible on the form
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "update student set isActive=0 where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
