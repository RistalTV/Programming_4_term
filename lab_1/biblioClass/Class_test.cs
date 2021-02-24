// ======================================================================
//           Класс Тест 
// ======================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace biblioClass
{
    public class Class_test
    {
        // Поля
        private string _theme;  // тема теста
        private List<Class_Task> _tasks = new List<Class_Task> { }; // задания
        private int _countTasks; // кол-во заданий
        private List<string> _time = new List<string>(3) {"00","00","00" }; // вре мя выполнения задания
        
        // Свойства
        public int CountTasks
        {
            get { return _countTasks; }
        }
        public List<Class_Task> Tasks 
        { 
            get => _tasks; 
            set => _tasks = value; 
        }
        public string Theme 
        { 
            get => _theme;
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    _theme = "No data";
                }
                else
                {
                    _theme = value;
                }
            }
        }

        // Методы
        public Class_Task GetTask(int num)
        {
            if (num > this.Tasks.Count || num < 0)
                num = 0;
            var counter = 0;
            foreach(var e in this.Tasks)
            {
                if (e.Number == num)
                    return e;
                counter++;
            }
            return this.Tasks[0];
        }
        public void AddTimeHours(int Hour)
        {
            var hour_ = Convert.ToInt32(_time[0]);
            Hour += hour_;
            if (Hour <= 0)
                _time[0] = "00";
            else
                _time[0] = Hour.ToString();
        }
        public void AddTimeMinutes(int Min)
        {
            var min_ = Convert.ToInt32(_time[1]);
            Min += min_;

            while (Min > 59)
            {
                Min -= 60;
                this.AddTimeHours(1);
            }
            if (Min <= 0)
                _time[1] = "00";
            else
                _time[1] = Min.ToString();
        }
        public void AddTimeSeconds(int Sec)
        {
            var sec_ = Convert.ToInt32(_time[2]);
            Sec += sec_;

            while (Sec > 59)
            {
                Sec -= 60;
                this.AddTimeMinutes(1);
            }
            if (Sec <= 0)
                _time[2] = "0";
            else
                _time[2] = Sec.ToString();
        }
        public void SetTimeHours(int Hour)
        {
            if (Hour <= 0)
                _time[0] = "00";
            else
                _time[0] = Hour.ToString();
        }
        public void SetTimeMinutes(int Min)
        {
            while (Min > 59)
            {
                Min -= 60;
                this.AddTimeHours(1);
            }
            if (Min <= 0)
                _time[1] = "00";
            else
                _time[1] = Min.ToString();
        }
        public void SetTimeSeconds(int Sec)
        {
            while (Sec > 59)
            {
                Sec -= 60;
                this.AddTimeMinutes(1);
            }
            if (Sec <= 0)
                _time[2] = "0";
            else
                _time[2] = Sec.ToString();
        }
        public void DelTimeHours(int Hour)
        {
            Hour = ((-1) * Hour) + Convert.ToInt32(_time[0]);
            if (Hour <= 0)
                _time[0] = "00";
            else
                _time[0] = Hour.ToString();
        }
        public void DelTimeMinutes(int Min)
        {

            Min = ((-1) * Min) + Convert.ToInt32(_time[1]) + Convert.ToInt32(_time[0])*60;
            this.DelTimeHours(Convert.ToInt32(_time[0]));
            while (Min > 59)
            {
                Min -= 60;
                this.AddTimeHours(1);
            }
            if (Min <= 0)
                _time[1] = "00";
            else
                _time[1] = Min.ToString();
        }
        public void DelTimeSeconds(int Sec)
        {
            Sec = ((-1) * Sec) + Convert.ToInt32(_time[2]) + Convert.ToInt32(_time[1]) * 60 + Convert.ToInt32(_time[0]) * 3600;
            this.DelTimeHours(Convert.ToInt32(_time[0]));
            this.DelTimeHours(Convert.ToInt32(_time[1]));
            while (Sec > 59)
            {
                Sec -= 60;
                this.AddTimeMinutes(1);
            }
            if (Sec <= 0)
                _time[2] = "0";
            else
                _time[2] = Sec.ToString();
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
                    text += $"\n#1 {el.ToPrintTask(ShowAnswer)}";
                    num++;
                }
            return text;
        }
    }
}
