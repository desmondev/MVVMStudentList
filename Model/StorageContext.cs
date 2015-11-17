using System.Data.Entity;

namespace MVVMStudentList.Model
{
    public class StorageContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}