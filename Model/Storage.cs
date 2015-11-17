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
    }
}