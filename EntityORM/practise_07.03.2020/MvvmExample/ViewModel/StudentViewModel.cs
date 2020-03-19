using System;
using System.Collections.ObjectModel;
using MvvmExample.Extensions;
using MvvmExample.Model;
using MvvmExample.DAL.Services;

namespace MvvmExample.ViewModel
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

            GetStudentsCommmand = new DelegateCommand.DelegateCommand(ExecuteGetStudents);
            SaveStudentsCommand = new DelegateCommand.DelegateCommand(ExecuteSaveStudents, CanExecuteSaveStudents);
        }

        private bool CanExecuteSaveStudents()
        {
            return selectedStudent != null;
        }

        private void ExecuteSaveStudents()
        {
            studentService.SaveStudents(Students);
        }

        private void ExecuteGetStudents()
        {
            Students = studentService.GetStudents().ToObservableCollection();
        }

        public ObservableCollection<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged();
            }
        }

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand.DelegateCommand GetStudentsCommmand { get; }

        public DelegateCommand.DelegateCommand SaveStudentsCommand { get; }

    }
}