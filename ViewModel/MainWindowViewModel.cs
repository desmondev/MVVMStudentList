using System;
using System.Collections.Generic;
using System.Windows.Input;
using MVVMStudentList.Model;

namespace MVVMStudentList.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Storage _storage;
        private List<Student> _students;

        public MainWindowViewModel()
        {
            _storage = new Storage();
            foreach (var student in _storage.getStudents())
            {
                Console.WriteLine(student.FirstName);
            }
        }

        public ICommand ButtonCommand { get; set; }

        public List<Group> Groups
        {
            get { return _storage.getGroups(); }
        }

        public List<Student> Students
        {
            get
            {
                return _storage.getStudents();
                
            }
            set
            {
                _students = value; 
                OnPropertyChanged();
            }
        }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public Group SelectedGroup { get; set; }

        public Student SelectedStudent { get; set; }
    }
}