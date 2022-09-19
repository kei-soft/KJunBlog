﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Maui.SqliteTest.Helpers;
using Maui.SqliteTest.Models;

namespace Maui.SqliteTest.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Fields
        StudentHelper studentHelper = new StudentHelper();
        #endregion

        #region Properties
        private bool isUpdate = false;

        public bool IsUpdate
        {
            get
            {
                return this.isUpdate;
            }
            set
            {
                this.isUpdate = value;
                OnPropertyChanged();
            }
        }

        private string newName;

        public string NewName
        {
            get
            {
                return this.newName;
            }
            set
            {
                this.newName = value;
                OnPropertyChanged();
            }
        }

        private string newAge;

        public string NewAge
        {
            get
            {
                return this.newAge;
            }
            set
            {
                this.newAge = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<StudentModel> students;

        public ObservableCollection<StudentModel> Students
        {
            get
            {
                if (this.students == null)
                {
                    this.students = new ObservableCollection<StudentModel>();
                }

                return this.students;
            }
            set
            {
                this.students = value;
                OnPropertyChanged();
            }
        }

        private StudentModel selectStudent;

        public StudentModel SelectStudent
        {
            get
            {
                return this.selectStudent;
            }
            set
            {
                this.selectStudent = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand ChangeSelectStudentCommand => new Command<StudentModel>(p => OnChangeSelectStudentCommand(p));
        public ICommand SaveCommand => new Command(p => OnSaveCommand());
        public ICommand DeleteCommand => new Command(p => OnDeleteCommand());
        #endregion

        public MainViewModel()
        {
            GetStudentList();
        }

        private void OnChangeSelectStudentCommand(StudentModel studentModel)
        {
            this.IsUpdate = true;

            this.NewName = this.SelectStudent.Name;
            this.NewAge = this.SelectStudent.Age;
        }

        private async void OnSaveCommand()
        {
            if (this.IsUpdate)
            {
                this.SelectStudent.Name = this.NewName;
                this.SelectStudent.Age = this.NewAge;

                int i = await studentHelper.UpdateStudent(this.SelectStudent);

                await Application.Current.MainPage.DisplayAlert("Update", "Update Complete", "ok");

                this.IsUpdate = false;
            }
            else
            {
                StudentModel newStudent = new StudentModel();
                newStudent.Name = this.newName;
                newStudent.Age = this.newAge;

                int i = await studentHelper.AddStudent(newStudent);

                await Application.Current.MainPage.DisplayAlert("Save", "Save Complete", "ok");
            }

            this.NewName = "";
            this.NewAge = "";

            GetStudentList();
        }

        private async void OnDeleteCommand()
        {
            foreach (var student in this.Students)
            {
                await studentHelper.DeleteStudent(student);
            }

            GetStudentList();
        }

        private async void GetStudentList()
        {
            var students = await studentHelper.GetStudentList();

            if (students != null)
            {
                this.Students.Clear();

                foreach (var student in students)
                {
                    this.Students.Add(student);
                }
            }
        }
    }
}
