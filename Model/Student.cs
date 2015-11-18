using System;

namespace MVVMStudentList.Model
{
    public class Student
    {
        public int StudentId { get ; set ; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public virtual Group Group { get; set; }

    }
}