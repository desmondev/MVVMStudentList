using System;
using System.ComponentModel.DataAnnotations;

namespace MVVMStudentList.Model
{
    public class Student
    {
        public int StudentId { get ; set ; }
        [MaxLength(32)] 
        public String FirstName { get; set; }
        [MaxLength(32)] 
        public String LastName { get; set; }
        public String IndexNo { get; set; }
        [Required]
        public virtual Group Group { get; set; }
    }
}