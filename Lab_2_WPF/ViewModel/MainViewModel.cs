//using MyRepository;
using Lab_2_WPF.enums;
using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_2_WPF.ViewModel
{
    public partial class MainViewModel:BaseViewModel
    {
        public static string DefaultPathToFile { get; } = "Data\\Elements.xml";
        
        private Class_union _object;
        private List<Class_Task> _tasks;
        private Class_Academic_Subject _subject;
        private tab tab;
        private Class_trial _trial;
        private Class_final_exam _final_Exam;
        private Class_exam _exam;
        private string _search_Test;
        private string _search_Trial;
        private string _search_Exam;
        private string _search_FinalExam;

        public MainViewModel()
        {
            Object = new Class_union();
            Tasks = new List<Class_Task>();
            Trial = new Class_trial();
            Final_Exam = new Class_final_exam();
            Exam = new Class_exam();
            tab = enums.tab.test;
        }
    }
}
