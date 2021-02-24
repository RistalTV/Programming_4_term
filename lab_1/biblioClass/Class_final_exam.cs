// ======================================================================
//           Класс Выпускной Экзамен
// ======================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioClass
{
    public class Class_final_exam: Class_exam
    {
        // Поля
        private Class_Academic_Subject _physics = new Class_Academic_Subject { Name = "Физика", FIO_chief = "No data" };
        private Class_Academic_Subject _informatics = new Class_Academic_Subject { Name = "Информатика", FIO_chief = "No data" };
        private Class_Academic_Subject _programming = new Class_Academic_Subject { Name = "Программирование", FIO_chief = "No data" };
        private string _FIO_attestation_commission; // ФИО проверяющего коммисии

        // Свойства
        public Class_Academic_Subject Programming
        {
            get => _programming;
            set
            {
                var tmp = new Class_Academic_Subject { Name = "Программирование", FIO_chief = value.FIO_chief, Tasks = value.Tasks, Theme = value.Theme };
                _programming = tmp;
            }
        }
        public Class_Academic_Subject Informatics
        {
            get => _informatics;
            set
            {
                var tmp = new Class_Academic_Subject { Name = "Информатика", FIO_chief = value.FIO_chief, Tasks = value.Tasks, Theme = value.Theme };
                _informatics = tmp;
            }
        }
        public Class_Academic_Subject Physics
        {
            get => _physics;
            set
            {
                var tmp = new Class_Academic_Subject { Name = "Физика", FIO_chief = value.FIO_chief, Tasks = value.Tasks, Theme = value.Theme };
                _physics = tmp;
            }
        }
        public string FIO_attestation_commission
        {
            get => _FIO_attestation_commission;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _FIO_attestation_commission = "No data";
                }
                else
                {
                    _FIO_attestation_commission = value;
                }
            }
        }

        // Методв
        public string ToPrintAllFinalExam(bool ShowAnswer = false)
        {
            // Печатаем класс
            return $"{ToPrintFIOAttestationCommission()}" +
                $"{ToPrintAllClassExam(ShowAnswer)}" +
                $"{ToPrintInformatics(ShowAnswer)}" +
                $"{ToPrintProgramming(ShowAnswer)}" +
                $"{ToPrintPhysics(ShowAnswer)}\n";
        }
        public string ToPrintInformatics(bool ShowAnswer = false)
        {
            // Печатаем класс
            return $"{Informatics.ToPrintAllTest(ShowAnswer)}\n";
        }
        public string ToPrintProgramming(bool ShowAnswer = false)
        {
            // Печатаем класс
            return $"{Programming.ToPrintAllTest(ShowAnswer)}\n";
        }
        public string ToPrintPhysics(bool ShowAnswer = false)
        {
            // Печатаем класс
            return $"{Physics.ToPrintAllTest(ShowAnswer)}\n";
        }
        public string ToPrintFIOAttestationCommission()
        {
            // Печатаем ФИО аттестационной комиссии
            return $"{FIO_attestation_commission}\n";
        }

    }
}
