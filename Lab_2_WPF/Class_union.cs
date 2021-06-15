using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_WPF
{
    public class Class_union
    {
        private List<Class_trial> _trials = new List<Class_trial>();
        private List<Class_exam> _exams = new List<Class_exam>();
        private List<Class_final_exam> _final_exams = new List<Class_final_exam>();
        private List<Class_test> _tests = new List<Class_test>();

        public List<Class_test> Tests { get => _tests; set => _tests = value; }
        public List<Class_final_exam> Final_exams { get => _final_exams; set => _final_exams = value; }
        public List<Class_exam> Exams { get => _exams; set => _exams = value; }
        public List<Class_trial> Trials { get => _trials; set => _trials = value; }
    }
}
