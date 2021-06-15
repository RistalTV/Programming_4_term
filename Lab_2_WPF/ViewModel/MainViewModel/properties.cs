using System.Collections.Generic;
using Lab_2_WPF.enums;
using Library;

namespace Lab_2_WPF.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        public List<Class_Task> Tasks
        {
            get => _tasks;
            set { _tasks = value; OnPropertyChanged(); }
        }
        


        public Class_union Object
        {
            get => _object;
            set { _object = value; OnPropertyChanged(); }
        }

        public Class_Academic_Subject Subject
        {
            get => _subject;
            set { _subject = value; OnPropertyChanged(); }
        }

        internal tab Tab { get => tab; set => tab = value; }

        public Class_exam Exam
        {
            get => _exam;
            set { _exam = value; OnPropertyChanged(); }
        }
        public Class_final_exam Final_Exam
        {
            get => _final_Exam;
            set { _final_Exam = value; OnPropertyChanged(); }
        }
        public Class_trial Trial
        {
            get => _trial;
            set { _trial = value; OnPropertyChanged(); }
        }

        public string Search_Test 
        {
            get => _search_Test;
            set { _search_Test = value; OnPropertyChanged(); }
        }
        public string Search_Trial
        {
            get => _search_Trial;
            set
            {
                _search_Trial = value; OnPropertyChanged();
            }
        }
        public string Search_Exam
        {
            get => _search_Exam;
            set
            {
                _search_Exam = value; OnPropertyChanged();
            }
        }
        public string Search_FinalExam
        {
            get => _search_FinalExam;
            set
            {
                _search_FinalExam = value; OnPropertyChanged();
            }
        }


    }
}
