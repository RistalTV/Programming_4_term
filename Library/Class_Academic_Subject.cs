using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Class_Academic_Subject: Class_test
    {
        // Поля
        private readonly string _name; // название предмета
        private string _FIO_chief; // ФИО руководителя
        

        // Конструкторы
        public Class_Academic_Subject(string name, string FIO = "No data")
        {
            this._name = name;
            this.FIO_chief = FIO;
        }

        // Свойства
        public string FIO_chief 
        { 
            get => _FIO_chief; 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    _FIO_chief = "No data";
                }
                else
                {
                    _FIO_chief = value;
                }
            } 
        }
        public string Name 
        { 
            get => _name;
        }

        // Методы
        public string ToPrintAcademicSubject(bool ShowAnswer = false)
        {
            return $"Предмет: { this.Name}\n" +
                $"Руководитель: {this.FIO_chief}\n" +
                $"{this.ToPrintAllTest(ShowAnswer)}"; 
        }
    }
}
