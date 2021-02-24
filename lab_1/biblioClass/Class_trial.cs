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

namespace biblioClass
{
    public class Class_trial: Class_exam
    {
        // Поля
        private Class_Academic_Subject _data_analysis = new Class_Academic_Subject { Name = "Анализ данных", FIO_chief = "No data" };
        private Class_Academic_Subject _data_structures = new Class_Academic_Subject { Name = "Структуры данных", FIO_chief = "No data" };
        private Class_Academic_Subject _deep_learning = new Class_Academic_Subject { Name = "Машинное обучение", FIO_chief = "No data" };

        // Свойства
        public Class_Academic_Subject Data_Analysis
        {
            get => _data_analysis;
            set
            {
                var tmp = new Class_Academic_Subject { Name = "Анализ данных", FIO_chief = value.FIO_chief, Tasks = value.Tasks, Theme = value.Theme };
                _data_analysis = tmp;
            }
        }
        public Class_Academic_Subject Data_structures
        {
            get => _data_structures;
            set
            {
                var tmp = new Class_Academic_Subject { Name = "Структуры данных", FIO_chief = value.FIO_chief, Tasks = value.Tasks, Theme = value.Theme };
                _data_structures = tmp;
            }
        }
        public Class_Academic_Subject Deep_learning
        {
            get => _deep_learning;
            set
            {
                var tmp = new Class_Academic_Subject { Name = "Машинное обучение", FIO_chief = value.FIO_chief, Tasks = value.Tasks, Theme = value.Theme };
                _deep_learning = tmp;
            }
        }

        // Методы
        public string ToPrintAllClassTrial(bool ShowAnswer = false)
        {
            // Печатаем всё испытание
            return $"{ToPrintAllClassExam(ShowAnswer)}\n{Deep_learning.ToPrintAllTest(ShowAnswer)}\n{Data_structures.ToPrintAllTest(ShowAnswer)}\n{Data_Analysis.ToPrintAllTest(ShowAnswer)}\n";
        }
        public string ToPrintDeepLearning(bool ShowAnswer = false)
        {
            // Печатаем Машинное изучение
            return $"{Deep_learning.ToPrintAllTest(ShowAnswer)}\n";
        }
        public string ToPrintDataStructures(bool ShowAnswer = false)
        {
            // Печатаем Структуры Данных
            return $"{Data_structures.ToPrintAllTest(ShowAnswer)}\n";
        }
        public string ToPrintDataAnalysis(bool ShowAnswer = false)
        {
            // Печатаем Анализ Данных
            return $"{Data_Analysis.ToPrintAllTest(ShowAnswer)}\n";
        }
    }
}
