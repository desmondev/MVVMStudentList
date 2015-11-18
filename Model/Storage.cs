using System.Collections.Generic;
using System.Linq;

namespace MVVMStudentList.Model
{
    public class Storage
    {
        public List<Student> getStudents()
        {
            using (var db = new StorageContext())
            {
                return db.Students.ToList();
            }
        }

        public List<Group> getGroups()
        {
            using (var db = new StorageContext())
            {
                return db.Groups.ToList();
            }
        }
    }
}