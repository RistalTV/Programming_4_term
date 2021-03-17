using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_console
{
    static public class GUI
    {
        public static void Start()
        {
            // Создаём линию
            var line = "=";
            for (var k = 0; k < Console.WindowWidth; k++)
                line += "=";

            int i;
            do
            {
                // выводим текст и ждём ответа от пользователя
                Console.Clear();
                Header(new List<string>
                {
                    "Лабораторная работа №1",
                    "Выполнил: Скребнев Леонид ФИТУ 2-5б 020303-АИСа-о19"
                });// выводим шапку
                Console.WriteLine(" Выберите из списка:");
                Console.WriteLine("   1) Заполнить класс 'Выпускной Экзамен'");
                Console.WriteLine("   2) Заполнить класс 'Испытание'");
                Console.WriteLine("   3) Заполнить класс 'Тест'");
                Console.WriteLine("   4) Заполнить класс 'Экзамен'");
                Console.WriteLine("   0) Выйти из приложения ");
                Console.WriteLine(line);
                if(!(int.TryParse(Console.ReadLine(), out i)))
                { 
                    i = 5;
                }
                Console.Clear();
                switch (i)
                {
                    case 1: GUI.Final_Exam(); break;
                    case 2: GUI.Trial(); break;
                    case 3: GUI.Test(); break;
                    case 4: GUI.Exam(); break;
                }
            }
            while (i > 0);
        }
        // Получаем данные от пользователя и заполняем класс потом выводим
        private static void Exam()
        {
            var e = new Class_exam();
            // В данный момент идёт заполнение предмета: 'Математика'      
            Input_Item(e.Math, "Экзамен");
            // В данный момент идёт заполнение предмета: 'Иностранный язык'      
            Input_Item(e.Foreign_language, "Экзамен");
            // В данный момент идёт заполнение предмета: 'Русский язык'      
            Input_Item(e.Russian_language, "Экзамен");

            GUI.Header(new List<string> { "Полный список заполнения класса 'Экзамен'" });
            Console.WriteLine(e.ToPrintAllClassExam(true));
            Console.ReadKey();
        }
        // Получаем данные от пользователя и заполняем класс потом выводим
        private static void Test()
        {
            var e = new Class_test();
            // Класс 'Тест'
            // В данный момент идёт заполнение теста
            GUI.Header(new List<string> { "Класс 'Тест'", "В данный момент идёт заполнение теста" });

            // темa
            Console.Write("\nВведите тему: ");
            e.Theme = Console.ReadLine();
            // кол-во тестовых заданий
            Console.Write("\nВведите кол-во тестовых заданий: ");
            if (!(int.TryParse(Console.ReadLine(), out int CountTasks)))
            {
                CountTasks = 1;
            }
            if (CountTasks <= 0)
                CountTasks = 1;
            // Спрашиваем у пользователя Вопросы
            var task = new Class_Task();
            for (var i = 0; i < CountTasks; i++)
            {
                // вопрос
                Console.Write($"\nВопрос №{i + 1}. Введите вопрос: ");
                var text = Console.ReadLine();
                if (text == "lorem")
                    text = LoremIpsum();
                task.Text = text;

                // ответ на вопрос
                Console.Write($"\n Введите ответ на вопрос: ");
                text = Console.ReadLine();
                if (text == "lorem")
                    text = LoremIpsum(1, 1);
                task.Text = text;

                // кол-во вариантов
                Console.Write($"\n Введите кол-во вариантов: ");
                if (!(int.TryParse(Console.ReadLine(), out int Count)))
                {
                    Count = 1;
                }
                if (Count <= 0)
                    Count = 1;
                // Спрашиваем у пользователя ответы
                var AnO = new List<string>(Count) { };
                for (var j = 0; j < Count; j++)
                {
                    // варианты
                    Console.Write($"\n   Введите вариант: ");
                    text = Console.ReadLine();
                    if (text == "lorem")
                        text = LoremIpsum(1, 1);
                    AnO.Add(text);
                }
                // заполняем класс
                task.Answer_option = AnO;
                e.AddTask(task);
            }
            
            // Выводим полученные данные
            Console.Clear();
            GUI.Header(new List<string> { "Полный список заполнения класса 'Экзамен'" });
            Console.WriteLine(e.ToPrintAllTest(true));
            Console.ReadKey();
        }
        // Получаем данные от пользователя и заполняем класс потом выводим
        private static void Trial()
        {
            var e = new Class_trial();
            // В данный момент идёт заполнение предмета: 'Анализ данных'      
            Input_Item(e.Data_Analysis, "Испытание");
            // В данный момент идёт заполнение предмета: 'Структуры данных'      
            Input_Item(e.Data_structures, "Испытание");
            // В данный момент идёт заполнение предмета: 'Машинное обучение'      
            Input_Item(e.Deep_learning, "Испытание");
            // В данный момент идёт заполнение предмета: 'Математика'      
            Input_Item(e.Math, "Испытание");
            // В данный момент идёт заполнение предмета: 'Иностранный язык'      
            Input_Item(e.Foreign_language, "Испытание");
            // В данный момент идёт заполнение предмета: 'Русский язык'      
            Input_Item(e.Russian_language, "Испытание");

            // Выводим полученные данные
            GUI.Header(new List<string> { "Полный список заполнения класса 'Испытание'" });
            Console.WriteLine(e.ToPrintAllClassTrial(true));
            Console.ReadKey();
        }
        // Получаем данные от пользователя и заполняем класс потом выводим
        private static void Final_Exam()
        {
            var e = new Class_final_exam();
            GUI.Header(new List<string>
                {
                    $"Класс 'Выпускной Экзамен'",
                    $"В данный момент идёт заполнение общей информации" });
            // ФИО проверяющего коммисии
            Console.Write("\nВведите ФИО проверяющего коммисии: ");
            e.FIO_attestation_commission = Console.ReadLine();
            // В данный момент идёт заполнение предмета: 'Физика'      
            Input_Item(e.Physics, "Выпускной Экзамен");
            // В данный момент идёт заполнение предмета: 'Информатика'      
            Input_Item(e.Programming, "Выпускной Экзамен");
            // В данный момент идёт заполнение предмета: 'Программирование'      
            Input_Item(e.Informatics, "Выпускной Экзамен");
            // В данный момент идёт заполнение предмета: 'Математика'      
            Input_Item(e.Math, "Выпускной Экзамен");
            // В данный момент идёт заполнение предмета: 'Иностранный язык'      
            Input_Item(e.Foreign_language, "Выпускной Экзамен");
            // В данный момент идёт заполнение предмета: 'Русский язык'      
            Input_Item(e.Russian_language, "Выпускной Экзамен");

            // Выводим полученные данные
            GUI.Header(new List<string> { "Полный список заполнения класса 'Выпускной Экзамен'" });
            Console.WriteLine(e.ToPrintAllFinalExam(true));
            Console.ReadKey();
        }
        // Получаем данные от пользователя и заполняем класс 
        public static void Input_Item(Class_Academic_Subject e, string nameClass)
        {
            GUI.Header(new List<string>
                {
                    $"Класс '{nameClass}'",
                    $"В данный момент идёт заполнение предмета: '{e.Name}'" });

            // темa
            Console.Write("\nВведите тему: ");
            e.Theme = Console.ReadLine();

            // ФИО руководителя
            Console.Write("\nВведите ФИО руководителя: ");
            e.FIO_chief = Console.ReadLine();

            // Время
            Console.Write($"\n Введите сколько мин будет идти экзамен(0 - по умолчанию): ");
            if (!(int.TryParse(Console.ReadLine(), out int Min)))
            {
                Min = 20;
            }
            if (Min <= 0)
                Min = 20;
            e.SetTimeMinutes(Min);

            // кол-во тестовых заданий
            Console.Write("\nВведите кол-во тестовых заданий: ");
            if (!(int.TryParse(Console.ReadLine(), out int CountTasks)))
            {
                CountTasks = 1;
            }
            if (CountTasks <= 0)
                CountTasks = 1;

            // Получаем данные вопросов
            var task = new Class_Task();
            for (var i = 0; i < CountTasks; i++)
            {
                // вопрос
                Console.Write($"\nВопрос №{i + 1}. Введите вопрос: ");
                var text = Console.ReadLine();

                if (text == "lorem")
                    text = LoremIpsum();
                task.Text = text;

                // ответ на вопрос
                Console.Write($"\n Введите ответ на вопрос: ");
                text = Console.ReadLine();

                if (text == "lorem")
                    text = LoremIpsum(1, 1);
                task.Text = text;

                // кол-во вариантов
                Console.Write($"\n Введите кол-во вариантов: ");
                if (!(int.TryParse(Console.ReadLine(), out int Count)))
                {
                    Count = 1;
                }
                if (Count <= 0)
                    Count = 1;
                // Получаем ответы
                var AnO = new List<string>(Count) { };
                for (var j = 0; j < Count; j++)
                {
                    // варианты
                    Console.Write($"\n   Введите вариант: ");
                    text = Console.ReadLine();
                    if (text == "lorem")
                        text = LoremIpsum(1, 1);
                    AnO.Add(text);
                }
                task.Answer_option = AnO;
                e.AddTask(task);
            }
            Console.Clear();
        }
        // Шапка
        public static void Header(List<string> str)
        {
            var line = "=";
            for (var i = 0; i < Console.WindowWidth; i++)
                line += "=";
            Console.WriteLine(line);
            foreach (var el in str)
            {
                var tab = " ";
                for (var i = 0; i < Math.Round(Convert.ToDouble((Console.WindowWidth - el.Length) / 2)); i++)
                    tab += " ";
                Console.WriteLine($"{tab}{el}");
            }
            Console.WriteLine(line);
        }
        // lorem функция которая генерирует случайные предложения
        static string LoremIpsum(int minWords = 4, int maxWords = 10, int minSentences = 1, int maxSentences = 1, int numParagraphs = 1)
        {
            // Список слов
            var words = new[]
            {
                "lorem", "слово", "любые", "это", "множество", "слов","решений",
                "выбираюстя", "разные", "и", "рандомные", "слова", "этот", "код",
                "был", "взят", "с", "замечательного", "сайта", "под", "названием",
                "стэк","овер","флоу","точка","ком","в","котором","изложены","много",
                "вопросов","к","ним","там","много","материала","из","можно",
            };
            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            // Создаём предложения
            for (int p = 0; p < numParagraphs; p++)
            {
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                };
            }

            return result.ToString();
        }
    }
}
