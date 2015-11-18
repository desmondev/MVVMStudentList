using System.Collections.Generic;

namespace MVVMStudentList.Model
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}