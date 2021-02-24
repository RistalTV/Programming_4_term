using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioClass
{
    public class Class_Task
    {
        // Поля
        private string _text; // вопрос
        private List<string> _answer_option = new List<string> { }; // ответы на вопрос
        private int _number; // номер вопроса
        private string _answer; // верный ответ на вопрос

        // Свойства
        public string Text
        {
            get { return _text; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _text = "No data";
                }
                else
                {
                    _text = value;
                }
            }
        }
        public string Answer
        {
            get { return _answer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _answer = "No data";
                }
                else
                {
                    _answer = value;
                }
            }
        }
        public int Number
        {
            get { return _number; }
            set
            {
                if (value < 1)
                {
                    _number = 1;
                }
                else
                {
                    _number = value;
                }
            }
        }
        public List<string> Answer_option 
        { 
            get => _answer_option; 
            set => _answer_option = value; 
        }

        // Методы
        public void AddValueToAnswerOption(string str)
        {
            // Добавляем ответ
            this.Answer_option.Add(str);
        }
        public string ToPrintTask(bool ShowAnswer = false)
        {
            // Печатаем задание
            var tmp_text = _text.Split('\n');
            var text_ = "";
            var _num = $"№{_number}. ";
            var tab = "";
            // tab
            for (var i = 0; i < _num.Length; i++)
                tab += " ";
            // text
            foreach (var el in tmp_text)
                if (el == tmp_text[0])
                    text_ += tab + el;
                else
                    text_ += "\n" + tab + el;
            
            string text = $"{text_}?";
            try
            {
                foreach (var elem in this.Answer_option)
                {

                    var num = 1;
                    foreach (var e in this.Answer_option)
                        if (e != elem)
                            num++;
                        else
                            break;
                    text += $"\n{tab}  {num}) {elem}";
                }

            }
            catch (NullReferenceException) { }
            
            text += $"\n{((ShowAnswer)?Answer:tab)}\n";
            
            return text;
        }
    }
}
