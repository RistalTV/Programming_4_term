// ======================================================================
//            Класс Экзамен 
// ======================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioClass
{
    public class Class_exam
    {
        // Поля
        private Class_Academic_Subject _math = new Class_Academic_Subject { Name = "Математика", FIO_chief ="No data" };
        private Class_Academic_Subject _foreign_language = new Class_Academic_Subject { Name = "Иностранный язык", FIO_chief = "No data" };
        private Class_Academic_Subject _Russian_language= new Class_Academic_Subject { Name = "Русский язык", FIO_chief = "No data" };

        // Свойства
        public Class_Academic_Subject Math 
        { 
            get => _math; 
            set 
            {
                var tmp = new Class_Academic_Subject { Name = "Математика", FIO_chief = value.FIO_chief, Tasks = value.Tasks, Theme = value.Theme };
                _math = tmp; 
            } 
        }
        public Class_Academic_Subject Foreign_language 
        { 
            get => _foreign_language; 
            set 
            {
                var tmp = new Class_Academic_Subject { Name = "Иностранный язык", FIO_chief = value.FIO_chief, Tasks = value.Tasks, Theme = value.Theme };
                _foreign_language = tmp; 
            }
        }
        public Class_Academic_Subject Russian_language 
        { 
            get => _Russian_language; 
            set 
            {
                var tmp = new Class_Academic_Subject { Name = "Русский язык", FIO_chief = value.FIO_chief, Tasks = value.Tasks, Theme = value.Theme };
                _Russian_language= tmp; 
            } 
        }

        // Методы
        public string ToPrintMath(bool ShowAnswer = false)           
        {
            // Печатаем предмет "Математика"
            var text = $"Предмет: {this.Math.Name}\nРуководитель: {this.Math.FIO_chief}\n";
            text += this.Math.ToPrintAllTest(ShowAnswer);
            return text;
        }
        public string ToPrintForeignLanguage(bool ShowAnswer = false)
        {
            // Печатаем предмет "Иностранный язык"
            var text = $"Предмет: {this.Foreign_language.Name}\nРуководитель: {this.Foreign_language.FIO_chief}\n";
            text += this.Foreign_language.ToPrintAllTest(ShowAnswer);
            return text;
        }
        public string ToPrintRussianLanguage(bool ShowAnswer = false)
        {
            // Печатаем предмет "Русский язык"
            var text = $"Предмет: {this.Russian_language.Name}\nРуководитель: {this.Russian_language.FIO_chief}\n";
            text += this.Russian_language.ToPrintAllTest(ShowAnswer);
            return text;
        }
        public string ToPrintAllClassExam(bool ShowAnswer = false)
        {
            // Печатаем весь класс
            return $"{this.ToPrintForeignLanguage(ShowAnswer)}\n{this.ToPrintMath(ShowAnswer)}\n{this.ToPrintRussianLanguage(ShowAnswer)}\n";
        }
    }
}
