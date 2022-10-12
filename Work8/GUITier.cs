namespace Week8;
using System.Data;
using MySql.Data.MySqlClient;
class GuiTier{
    User user = new User();
    DataTier database = new DataTier();

    // print login page
    public User Login(){
        Console.WriteLine("------Welcome to Course Management System------");
        Console.WriteLine("Please input user ID (StudentID): ");
        user.userID = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Please input password: ");
        user.userPassword = Console.ReadLine();
        return user;
    }
    // print Dashboard after user logs in successfully
    public int Dashboard(User user){
        DateTime localDate = DateTime.Now;
        Console.WriteLine("---------------Dashboard-------------------");
        Console.WriteLine($"Hello: {user.userID}; Date/Time: {localDate.ToString()}");
        Console.WriteLine("Please select an option to continue:");
        Console.WriteLine("1. Check Enrollment");
        Console.WriteLine("2. Add A Course [TBD]");
        Console.WriteLine("3. Drop A Course [TBD]");
        Console.WriteLine("4. Log Out");
        int option = Convert.ToInt16(Console.ReadLine());
        return option;
    }

    // show enrollment records returned from database
    public void DisplayEnrollment(DataTable tableEnrollment){
        Console.WriteLine("---------------Enrollment List-------------------");
        foreach(DataRow row in tableEnrollment.Rows){
           Console.WriteLine($"CourseID: {row["courseID"]} \t CourseName: {row["courseName"]} \t Semester:{row["semester"]}");
        }
    }

public void DisplayCourseList(DataTable tableCourse){
        Console.WriteLine("---------------Course List-------------------");
        foreach(DataRow row in tableCourse.Rows){
           Console.WriteLine($"CourseID: {row["courseID"]} \t CourseName: {row["courseName"]}");
        }
}
}