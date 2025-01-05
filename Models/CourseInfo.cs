using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProject.Models
{
    public class CourseInfo
    {
        public string courseName { get; set; }
        public string courseYear { get;set; }
        public List<Student> students { get;set; }
        //convert from JSON to C# Class
        public void Load_JSON() {
            string dir = GlobalData.directory + GlobalData.Year + "\\" + GlobalData.Course
                + "\\course_info.json";
            string text = File.ReadAllText(dir);
            var c = Newtonsoft.Json.JsonConvert.DeserializeObject<CourseInfo>(text);
            if (c != null)
            {
                this.courseName = c.courseName;
                this.courseYear = c.courseYear;
                this.students = c.students;
            }
            else {
                this.courseYear = GlobalData.Year;
                this.courseName = GlobalData.Course;
                this.students = new List<Student>();
            }
        }
        //convert from C# class to JSON file
        public void Save_JSON()
        {
            if (GlobalData.Year == "N" || GlobalData.Course == "N")
            {
                MessageBox.Show("please select a year and a course");
                return;
            }
            else { 
                var res = Newtonsoft.Json.JsonConvert.SerializeObject(this);
                string target = GlobalData.directory + GlobalData.Year + "\\" + GlobalData.Course
                    + "\\course_info.json";
                System.IO.File.WriteAllText(target, res);
            }
        }
    }


    public class Student { 
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class StudentGrade { 
        public Student student { get; set; }
        public int grade { get; set; }
    }
}
