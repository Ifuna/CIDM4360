namespace Week8;
using System.Data;
using MySql.Data.MySqlClient;
class BusinessLogic
{
   
    static void Main(string[] args)
    {
        bool _continue = true;
        User user;
        GuiTier appGUI = new GuiTier();
        DataTier database = new DataTier();

        // start GUI
        user = appGUI.Login();

       
        if (database.LoginCheck(user)){

            while(_continue){
                int option  = appGUI.Dashboard(user);
                switch(option)
                {
                    // check enrollment
                    case 1:
                        DataTable tableEnrollment = database.CheckEnrollment(user);
                        if(tableEnrollment != null)
                            appGUI.DisplayEnrollment(tableEnrollment);
                        break;
                    // Add A Course
                    case 2:
                        DataTable tableAddEnrollment = database.CourseList();
                    if(tableAddEnrollment != null)
                            appGUI.DisplayCourseList(tableAddEnrollment);
                     tableAddEnrollment = database.AddCourse(user);
                        if(tableAddEnrollment != null)
                            appGUI.DisplayEnrollment(tableAddEnrollment);
                        
                        break;
                    // Drop A Course
                    case 3:
                    DataTable tableDropEnrollment = database.DropCourse(user);
                        if(tableDropEnrollment != null)
                            appGUI.DisplayEnrollment(tableDropEnrollment);
                        
                        break;
                    // Log Out
                    case 4:
                        _continue = false;
                        Console.WriteLine("Log out, Goodbye.");
                        break;
                    // default: wrong input
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }

            }
        }
        else{
                Console.WriteLine("Login Failed, Goodbye.");
        }        
    }    
}

