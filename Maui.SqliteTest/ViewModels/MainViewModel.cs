using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Maui.SqliteTest.Helpers;
using Maui.SqliteTest.Models;

namespace Maui.SqliteTest.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        StudentHelper studentHelper = new StudentHelper();

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

        //public ICommand SelectCommand => new Command(p => OnSelectCommand());
        public ICommand ChangeSelectStudentCommand => new Command(p => OnChangeSelectStudentCommand());

        public ICommand SaveCommand => new Command(p => OnSaveCommand());
        public ICommand DeleteCommand => new Command(p => OnDeleteCommand());


        public MainViewModel()
        {
            GetStudentList();
        }

        private void OnChangeSelectStudentCommand()
        {

        }

        private async void OnSaveCommand()
        {
            StudentModel newStudent = new StudentModel();
            newStudent.Name = this.newName;
            newStudent.Age = this.newAge;

            int i = await studentHelper.AddStudent(newStudent);

            await Application.Current.MainPage.DisplayAlert("Save", "Save Complete", "ok");

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
