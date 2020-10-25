using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {

        List<Student> students;
        

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.students.Count;
            }
        }
        public Classroom(int capacity)
        {
           
            Capacity = capacity;          
            students = new List<Student>();
        }

       

        public string RegisterStudent(Student student) ///////////////// ?????????????
        {
            if (Capacity > Count)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)  ///////////////// ?????????????
        {
            
            
            if (students.Any(x => x.FirstName == firstName && x.LastName == lastName))
            {
                Student studentToRemove = students.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();
                return $"Dismissed student {firstName} {lastName}";
                students.Remove(studentToRemove);
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (var item in students.Where(x => x.Subject == subject))
            {
                sb.AppendLine($"{item.FirstName} {item.LastName}");
            }

            return sb.ToString().TrimEnd();
        }



        public int GetStudentsCount => students.Count;

        public Student GetStudent(string firstName, string lastName) => students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

        
        

}
}
