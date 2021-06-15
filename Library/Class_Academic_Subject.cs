using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library
{
    [Serializable]
    public class Class_Academic_Subject: Class_test
    {
        // Поля

        private readonly string _name; // название предмета
        private string _FIO_chief; // ФИО руководителя

        private string tmp_name;

        // Конструкторы
        public Class_Academic_Subject() { }
        public Class_Academic_Subject(string name, List<Class_Task> _tasks, List<string> _time, string FIO = "No data", string _theme = "") : base(_theme, _tasks, _time)
        {
            this._name = name;
            this.FIO_chief = FIO;
            Tmp_name = _name;
        }
        public Class_Academic_Subject(string name, string FIO = "No data", string _theme = "") : this (name, new List<Class_Task> { }, new List<string> { "00", "00", "00" }, FIO, _theme)
        {
            this._name = name;
            this.FIO_chief = FIO;

            Tmp_name = _name;
        }
        public Class_Academic_Subject(string _theme, List<Class_Task> _tasks, List<string> _time) : base(_theme, _tasks, _time)
        {
            this.Theme = _theme;
            this.Tasks = _tasks;

            Tmp_name = _name;
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

                    tmp_name = _name;
                }
                else
                {
                    _FIO_chief = value;

                    tmp_name = _name;
                }
            } 
        }
        public string Name 
        { 
            get => _name;
        }
        public string Tmp_name { get => tmp_name; set => tmp_name = value; }

        // Методы
        public string ToPrintAcademicSubject(bool ShowAnswer = false)
        {
            return $"Предмет: { this.Name}\n" +
                $"Руководитель: {this.FIO_chief}\n" +
                $"{this.ToPrintAllTest(ShowAnswer)}"; 
        }
    }
}
