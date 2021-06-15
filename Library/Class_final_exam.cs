// ======================================================================
//           Класс Выпускной Экзамен
// ======================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Library
{
    [Serializable]

    public class Class_final_exam: Class_exam
    {
        // Поля
        private Class_Academic_Subject _physics     = new Class_Academic_Subject("Физика", "No data");          
        private Class_Academic_Subject _informatics = new Class_Academic_Subject("Информатика", "No data");     
        private Class_Academic_Subject _programming = new Class_Academic_Subject("Программирование", "No data");
        private string _FIO_attestation_commission; // ФИО проверяющего коммисии

        // Свойства
        public Class_Academic_Subject Programming
        {
            get => _programming;
            set => _programming = value;
        }
        public Class_Academic_Subject Informatics
        {
            get => _informatics;
            set => _informatics = value;
            
        }
        public Class_Academic_Subject Physics
        {
            get => _physics;
            set => _physics = value;
            
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
            return $"{ToPrintFIOAttestationCommission()}\n" +
                $"{ToPrintAllClassExam(ShowAnswer)}\n" +
                $"{ToPrintInformatics(ShowAnswer)}\n" +
                $"{ToPrintProgramming(ShowAnswer)}\n" +
                $"{ToPrintPhysics(ShowAnswer)}\n";
        }
        public string ToPrintInformatics(bool ShowAnswer = false)
        {
            // Печатаем класс
            return $"{this.Informatics.ToPrintAcademicSubject(ShowAnswer)}";
        }
        public string ToPrintProgramming(bool ShowAnswer = false)
        {
            // Печатаем класс
            return $"{this.Programming.ToPrintAcademicSubject(ShowAnswer)}";
        }
        public string ToPrintPhysics(bool ShowAnswer = false)
        {
            // Печатаем класс
            return $"{this.Physics.ToPrintAcademicSubject(ShowAnswer)}";
        }
        public string ToPrintFIOAttestationCommission()
        {
            // Печатаем ФИО аттестационной комиссии
            return $"{FIO_attestation_commission}";
        }

    }
}
