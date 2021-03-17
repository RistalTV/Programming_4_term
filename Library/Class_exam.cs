// ======================================================================
//            Класс Экзамен 
// ======================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Class_exam
    {
        // Поля
        private Class_Academic_Subject _math = new Class_Academic_Subject ("Математика", "No data");
        private Class_Academic_Subject _foreign_language = new Class_Academic_Subject("Иностранный язык", "No data");
        private Class_Academic_Subject _Russian_language= new Class_Academic_Subject("Русский язык", "No data");

        // Свойства
        public Class_Academic_Subject Math 
        { 
            get => _math;
            set => _math = value; 
        }
        public Class_Academic_Subject Foreign_language 
        { 
            get => _foreign_language;
            set => _foreign_language = value;
        }
        public Class_Academic_Subject Russian_language 
        { 
            get => _Russian_language;
            set => _Russian_language = value;
        }

        // Методы
        public string ToPrintMath(bool ShowAnswer = false)           
        {
            // Печатаем предмет "Математика"
            return $"{this.Math.ToPrintAcademicSubject(ShowAnswer)}";
        }
        public string ToPrintForeignLanguage(bool ShowAnswer = false)
        {
            // Печатаем предмет "Иностранный язык"
            return $"{this.Foreign_language.ToPrintAcademicSubject(ShowAnswer)}";
        }
        public string ToPrintRussianLanguage(bool ShowAnswer = false)
        {
            // Печатаем предмет "Русский язык"
            return $"{this.Russian_language.ToPrintAcademicSubject(ShowAnswer)}";
        }
        public string ToPrintAllClassExam(bool ShowAnswer = false)
        {
            // Печатаем весь класс
            return $"{this.ToPrintForeignLanguage(ShowAnswer)}\n" +
                $"{this.ToPrintMath(ShowAnswer)}\n" +
                $"{this.ToPrintRussianLanguage(ShowAnswer)}\n";
        }
    }
}
