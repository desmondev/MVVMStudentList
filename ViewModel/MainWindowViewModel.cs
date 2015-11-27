using System;
using System.Collections.Generic;
using System.Windows.Input;
using MVVMStudentList.Model;
using System.ComponentModel;

namespace MVVMStudentList.ViewModel
{
    public class MainWindowViewModel : ViewModelBase, IDataErrorInfo
    {
        private Storage _storage;
        private List<Student> _students;
        private Group _selectedGroup;
        private Student _selectedStudent;
        private string firstName;
        private string lastName;


        public MainWindowViewModel()
        {
            _storage = new Storage();
            //            foreach (var student in _storage.getStudents())
            //            {
            //                Console.WriteLine(student.FirstName);
            //            }
            AddCommand = new RelayCommand(o =>
            {
                _storage.createStudent(firstName,lastName, _selectedGroup.GroupId);
                OnPropertyChanged("Students");
            },
                o =>
                {
                    return _selectedGroup != null;
                });
            UpdateCommand = new RelayCommand(o =>
            {
                _storage.updateStudent(new Student
                {
                    StudentId = _selectedStudent.StudentId,
                    FirstName = firstName,
                    LastName = LastName
                });
                OnPropertyChanged("Students");
            },
               o =>
               {
                   return _selectedStudent != null; ;
               });
            DeleteCommand = new RelayCommand(o =>
            {
                _storage.deleteStudent(_selectedStudent);
                OnPropertyChanged("Students");
            },
               o =>
               {
                   return _selectedStudent != null; ;
               });

        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public List<Group> Groups
        {
            get { return _storage.getGroups(); }
        }

        public List<Student> Students
        {
            get
            {
                if (_students != null)
                {
                    return _storage.getGroupStudents(_selectedGroup);
                }
                return _storage.getStudents();

            }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public String FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        public String LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        public Group SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                if (_selectedGroup == value)
                {
                    return;
                }
                _selectedGroup = value;
                Students = _storage.getGroupStudents(_selectedGroup);
                OnPropertyChanged();
            }
        }


        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }

            set
            {
                if (value == _selectedStudent)
                    return;

                _selectedStudent = value;
                if (_selectedStudent != null)
                {
                    FirstName = _selectedStudent.FirstName;
                    LastName = _selectedStudent.LastName;
                }
                OnPropertyChanged("SelectedStudent");
            }
        }
        public string Error { get; set; }
        public string this[string columnName]
        {
            get
            {
                if ("FirstName" == columnName)
                {
                    if (firstName != null)
                    {
                        if (firstName.Length > 32)
                        {
                            Error = "First Error";
                            return Error;
                        }
                    }
                    return "";
                    
                }
                return "";
            }
        }
    }
}