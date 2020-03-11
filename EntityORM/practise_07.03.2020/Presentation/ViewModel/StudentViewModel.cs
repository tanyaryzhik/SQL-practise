using System;
using System.Collections.ObjectModel;
using MvvmExample.DAL.Services;
using MvvmExample.Model;
using Presentation.Extensions;


namespace Presentation.ViewModel
{
    public class StudentViewModel : ViewModelBase.ViewModelBase
    {
        private ObservableCollection<Student> students;
        private Student selectedStudent;
        private readonly IStudentService studentService;

        public StudentViewModel(IStudentService studentService)
        {
            if (studentService == null) throw new ArgumentNullException(nameof(studentService));

            this.studentService = studentService;
            Students = new ObservableCollection<Student>();

            GetStudentsCommmand = new DelegateCommand.DelegateCommand(this.ExecuteGetStudents);
            SaveStudentsCommand = new DelegateCommand.DelegateCommand(this.ExecuteSaveStudents, this.GeneralCanExecute);
            RemoveStudentCommand = new DelegateCommand.DelegateCommand(this.ExecuteRemoveStudent, this.GeneralCanExecute);
        }

        private bool GeneralCanExecute()
        {
            return this.selectedStudent != null;
        }

        private void ExecuteSaveStudents()
        {
            this.studentService.SaveStudents();
        }

        private void ExecuteGetStudents()
        {
            Students = this.studentService.GetStudents().ToObservableCollection();
        }

        private void ExecuteRemoveStudent()
        {
            this.studentService.RemoveStudent(this.selectedStudent);
            this.ExecuteSaveStudents();
            this.ExecuteGetStudents();
        }

        public ObservableCollection<Student> Students
        {
            get { return this.students; }
            set
            {
                this.students = value;
                this.OnPropertyChanged();
            }
        }

        public Student SelectedStudent
        {
            get { return this.selectedStudent; }
            set
            {
                this.selectedStudent = value;
                this.OnPropertyChanged();
            }
        }

        public DelegateCommand.DelegateCommand GetStudentsCommmand { get; }

        public DelegateCommand.DelegateCommand SaveStudentsCommand { get; }

        public DelegateCommand.DelegateCommand RemoveStudentCommand { get; }
    }
}