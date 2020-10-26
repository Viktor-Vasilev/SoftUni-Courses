using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students = new List<Student>();

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count { get { return students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student realStudent = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            if (realStudent == null)
            {
                return "Student not found";
            }
            else
            {
                students.Remove(realStudent);
                return $"Dismissed student {realStudent.FirstName} {realStudent.LastName}";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsSelect = students.Where(s => s.Subject == subject).ToList();
            if (studentsSelect.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (Student student in studentsSelect)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }
            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
         => students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
    }
}