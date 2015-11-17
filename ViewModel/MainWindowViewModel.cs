using System;
using System.Collections.Generic;
using System.Windows.Input;
using MVVMStudentList.Model;

namespace MVVMStudentList.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Storage _storage;

        public MainWindowViewModel()
        {
            _storage = new Storage();
        }

        public ICommand ButtonCommand { get; set; }

        public List<Group> Groups
        {
            get { throw new System.NotImplementedException(); }
        }

        public List<Student> Students
        {
            get { throw new System.NotImplementedException(); }
        }

        public String Imie { get; set; }

        public String FirstName
        {
            get { throw new NotImplementedException(); }
        }

        public String LastName
        {
            get { throw new NotImplementedException(); }
        }

        public Group SelectedGroup
        {
            get { throw new NotImplementedException(); }
        }

        public Student SelectedStudent
        {
            get { throw new NotImplementedException(); }
        }
    }
}