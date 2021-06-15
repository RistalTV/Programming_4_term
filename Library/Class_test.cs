// ======================================================================
//           Класс Тест 
// ======================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Library
{
    [Serializable]
    [XmlInclude(typeof(Class_Academic_Subject))]
    public class Class_test 
    {
        // Поля
        private string _theme;  // тема теста
        private List<Class_Task> _tasks = new List<Class_Task> { }; // задания
        private int _countTasks; // кол-во заданий
        private string[] _time = new string[]{"00","00","00" }; // время выполнения задания

        // Конструкторы
        public Class_test(string _theme, List<Class_Task> _tasks, List<string> _time)
        {
            this._time = new string[] { "00", "00", "00" };
            this._theme = _theme;
            this._tasks = _tasks;
            if (_time.Count == 3)
            {
                this._time[0] = _time[0];
                this._time[1] = _time[1];
                this._time[2] = _time[2];
            }

        }
        public Class_test() { }

        // Свойства
        public int CountTasks
        {
            get
            {
                UpdateClass();
                return _countTasks;
                
            }
        }
        public List<Class_Task> Tasks 
        { 
            get => _tasks;
            set
            {
                _tasks = value;
                UpdateClass();
            }
        }
        public string Theme 
        { 
            get => _theme;
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    UpdateClass();
                    _theme = "No data";
                }
                else
                {
                    UpdateClass();
                    _theme = value;
                }
            }
        }

        public string Time { get => time; set => time = value; }
        public string StrTask { get => strTask; set => strTask = value; }

        private string strTask;
        private string time;
        // Методы
        public void UpdateClass()
        {
            Time = PrintTime();
            strTask = PrintTask();
        }
        public void SetTime(List<string> _time)
        {
            this._time[0] = _time[0];
            this._time[1] = _time[1];
            this._time[2] = _time[2];
            UpdateClass();
        }
        public Class_Task GetTask(int num)
        {
            if (num > this.Tasks.Count || num < 0)
                num = 0;
            var counter = 0;
            foreach(var e in this.Tasks)
            {
                if (e.Number == num)
                {
                    UpdateClass();
                    return e;
                }
                counter++;
            }
            UpdateClass();
            return this.Tasks[0];
        }
        public void SetTime(string h, string min, string sec)
        {
            this._time[0] = h;
            this._time[1] = min;
            this._time[2] = sec;

        }
        public void AddTask(string _text, List<string> _answer_option, string _answer)
        {

            Class_Task t = new Class_Task
            {
                Text = _text,
                Answer_option = _answer_option,
                Answer = _answer,
                Number = this.Tasks.Count + 1,
            };
            this.Tasks.Add(t);
            this._countTasks = this.Tasks.Count;
        }
        public void AddTask(Class_Task T)
        {
            T.Number = this.Tasks.Count + 1;
            this.Tasks.Add(T);
            this._countTasks = this.Tasks.Count;
            UpdateClass();
        }
        public void DelTasks()
        {
            this.Tasks.Clear();
            this._countTasks = 0;
        }
        public void RemoveTask(int num)
        {
            if (num > this.Tasks.Count || num < 0)
                num = 0;
            this._countTasks--;
            var counter = 0;
            foreach (var e in this.Tasks)
            {
                if (e.Number == num)
                {
                    this.Tasks.RemoveAt(counter);
                    break;
                }
                counter++;
            }
        }
        public string ToPrintTheme()
        {
            return $"Тема:'{this._theme}'. \n";
        }
        public string ToPrintCountTasks()
        {
            return $"Кол-во заданий: {this._countTasks} \n";
        }
        public string ToPrintTime()
        {
            return $"Время выполнения задания: " +
                $"{((this._time.ElementAt(0)=="00")?"":this._time.ElementAt(0)+" ч. ")}" +
                $"{((this._time.ElementAt(1) == "00") ? "" : this._time.ElementAt(1) + " мин.")}" +
                $"{((this._time.ElementAt(2) == "00") ? "" : this._time.ElementAt(2) + " сек.")}\n";
        }
        public string ToPrintAllTest(bool ShowAnswer = false)
        {
            var num = 1;
            var text = $"{this.ToPrintTheme()}{this.ToPrintTime()}{this.ToPrintCountTasks()}";
            if (this.Tasks.Count < 0)
                return "Не добавлено задание";
            else
                foreach (var el in this.Tasks)
                {
                    text += $"\n#{num.ToString()} {el.ToPrintTask(ShowAnswer)}";
                    num++;
                }
            return text;
        }
        public string PrintTask()
        {
            var text="";
            if (Tasks.Count != 0)
                foreach (var e in Tasks)
                {
                    text += $"['{e.Text}'";
                    foreach (var a in e.Answer_option)
                    {
                        text += $", ({a})";
                    }
                    text += "], ";
                }
            else
                text = "No Tasks";
            return text;
        }
        public string PrintTime()
        {
            return 
                $"{((this._time.ElementAt(0) == "00") ? "0 ч. " : this._time.ElementAt(0) + " ч. ")}" +
                $"{((this._time.ElementAt(1) == "00") ? "0 мин." : this._time.ElementAt(1) + " мин.")}" +
                $"{((this._time.ElementAt(2) == "00") ? "0 сек." : this._time.ElementAt(2) + " сек.")}";
        }

    }
}
