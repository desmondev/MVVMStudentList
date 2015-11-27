using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

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

        public List<Student> getGroupStudents(Group selectedGroup)
        {
            using (var db = new StorageContext())
            {
                return db.Students.Where(student => student.Group.GroupId.Equals(selectedGroup.GroupId)).ToList();
            }
        }

        public void createStudent(string firstName, string lastName/*, string indexNo*/, int groupId)
        {
            try
            {
                using (var db = new StorageContext())
                {
                    var group = db.Groups.Find(groupId);
                    var student = new Student
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Group = group
                    };

                    db.Students.Add(student);
                    db.SaveChanges();
                    student.IndexNo = Convert.ToString(student.StudentId);
                    db.SaveChanges();

                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var errors in dbEx.EntityValidationErrors)
                {
                    foreach (var error in errors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property name: {0} Error: {1}", error.PropertyName, error.ErrorMessage);
                    }
                }
            }

        }

        public void updateStudent(Student newStudent)
        {
            using (var db = new StorageContext())
            {
                var oldStudent = db.Students.Find(newStudent.StudentId);
                if (oldStudent != null)
                {
                    oldStudent.FirstName = newStudent.FirstName;
                    oldStudent.LastName = newStudent.LastName;
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var errors in dbEx.EntityValidationErrors)
                        {
                            foreach (var error in errors.ValidationErrors)
                            {
                                Trace.TraceInformation("Property name: {0} Error: {1}", error.PropertyName, error.ErrorMessage);
                            }
                        }
                    }
                }
            }
        }

        public void deleteStudent(Student student)
        {
            try
            {
                using (var db = new StorageContext())
                {
                    var oldStudent = db.Students.Find(student.StudentId);
                    if (oldStudent != null)
                    {
                        db.Students.Remove(oldStudent);
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
    }
}