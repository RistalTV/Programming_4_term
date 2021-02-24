using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioClass
{
    public class Class_Academic_Subject: Class_test
    {
        // Поля
        private string _name; // название предмета
        private string _FIO_chief; // ФИО руководителя
        
        
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
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _name = "No data";
                }
                else
                {
                    _name = value;
                }
            }
        }
    }
}
