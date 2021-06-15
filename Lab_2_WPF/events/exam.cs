using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library;
using Lab_2_WPF.ViewModel;
using System.Windows.Media;

namespace Lab_2_WPF
{
    public partial class StartingWindow : Window
    {
        private void Btn_math_Click(object sender, RoutedEventArgs e)
        {
            if (label_math.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Математика", "No data", enums.tab.exam);
            }
        }

        private void Btn_foreign_language_Click(object sender, RoutedEventArgs e)
        {
            if (label_foreign_language.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Иностранный язык", "No data", enums.tab.exam);
            }
        }

        private void Btn_Russian_language_Click(object sender, RoutedEventArgs e)
        {
            if (label_Russian_language.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Русский язык", "No data", enums.tab.exam);
            }
        }

        private async void Btn_exam_Click(object sender, RoutedEventArgs e)
        {
            var f = 0;
            if (label_math.Text != "да")
                f += 1;
            if (label_foreign_language.Text != "да")
                f += 1;
            if (label_Russian_language.Text != "да")
                f += 1;
            if (f != 0)
            {
                if (MessageBox.Show($"У вас не заполнено {f} поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                {
                    if (MessageBox.Show("Добавить ещё один объект?", "WHO?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Model.Object.Exams.Add(Model.Exam);
                        Model.Exam = new Class_exam();
                        to_default_exam();
                        HideAcademicSubject();
                    }
                    else
                    {
                        Model.Object.Exams.Add(Model.Exam);
                        Model.Exam = new Class_exam();
                        to_default_exam();
                        HideAcademicSubject();
                        if (!(await MainViewModel.SerializeElement(MainViewModel.DefaultPathToFile,
                                    this.Model.Object)))
                        {
                            MessageBox.Show($"В процессе произошла ошибка");
                        }
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Добавить ещё один объект?", "WHO?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Model.Object.Exams.Add(Model.Exam);
                    Model.Exam = new Class_exam();
                    to_default_exam();
                    HideAcademicSubject();
                }
                else
                {
                    Model.Object.Exams.Add(Model.Exam);
                    Model.Exam = new Class_exam();
                    to_default_exam();
                    HideAcademicSubject();
                    if (!(await MainViewModel.SerializeElement(MainViewModel.DefaultPathToFile,
                                this.Model.Object)))
                    {
                        MessageBox.Show($"В процессе произошла ошибка");
                    }
                }
            }
        }
        private void to_default_exam()
        {
            label_math.Text = "нет";
            label_math.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
            btn_math.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_foreign_language.Text = "нет";
            label_foreign_language.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
            btn_foreign_language.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_Russian_language.Text = "нет";
            label_Russian_language.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
            btn_Russian_language.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));

        }
    }
}
