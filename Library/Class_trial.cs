// ======================================================================
//           Класс Испытание
// ======================================================================

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Class_trial: Class_exam
    {
        // Поля
        private Class_Academic_Subject _data_analysis   = new Class_Academic_Subject("Анализ данных", "No data");    
        private Class_Academic_Subject _data_structures = new Class_Academic_Subject("Структуры данных", "No data"); 
        private Class_Academic_Subject _deep_learning   = new Class_Academic_Subject("Машинное обучение", "No data");

        // Свойства
        public Class_Academic_Subject Data_Analysis
        {
            get => _data_analysis;
            set => _data_analysis = value;
        }
        public Class_Academic_Subject Data_structures
        {
            get => _data_structures;
            set => _data_structures = value;
            
        }
        public Class_Academic_Subject Deep_learning
        {
            get => _deep_learning;
            set => _deep_learning = value;
            
        }

        // Методы
        public string ToPrintAllClassTrial(bool ShowAnswer = false)
        {
            // Печатаем всё испытание
            return $"{ToPrintAllClassExam(ShowAnswer)}\n" +
                $"{ToPrintDeepLearning(ShowAnswer)}\n" +
                $"{ToPrintDataStructures(ShowAnswer)}\n" +
                $"{ToPrintDataAnalysis(ShowAnswer)}\n";
        }
        public string ToPrintDeepLearning(bool ShowAnswer = false)
        {
            // Печатаем Машинное изучение
            return $"{this.Deep_learning.ToPrintAcademicSubject(ShowAnswer)}";
        }
        public string ToPrintDataStructures(bool ShowAnswer = false)
        {
            // Печатаем Структуры Данных
            return $"{this.Data_structures.ToPrintAcademicSubject(ShowAnswer)}";
        }
        public string ToPrintDataAnalysis(bool ShowAnswer = false)
        {
            // Печатаем Анализ Данных
            return $"{this.Data_Analysis.ToPrintAcademicSubject(ShowAnswer)}";
        }
    }
}
