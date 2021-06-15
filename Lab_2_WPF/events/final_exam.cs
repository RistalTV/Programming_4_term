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
        private void Btn_physics_Click(object sender, RoutedEventArgs e)
        {
            if (label_data_analysis.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Физика", "No data", enums.tab.final_exam);
            }
        }

        private void Btn_informatics_Click(object sender, RoutedEventArgs e)
        {
            if (label_data_structures.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Информатика", "No data", enums.tab.final_exam);
            }
        }

        private void Btn_programming_Click(object sender, RoutedEventArgs e)
        {
            if (label_deep_learning.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Программирование", "No data", enums.tab.final_exam);
            }
        }

        private void Btn_math_final_exam_Click(object sender, RoutedEventArgs e)
        {
            if (label_math_final_exam.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Математика", "No data", enums.tab.final_exam);
            }
        }

        private void Btn_foreign_language_final_exam_Click(object sender, RoutedEventArgs e)
        {
            if (label_foreign_language_final_exam.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Иностранный язык", "No data", enums.tab.final_exam);
            }
        }

        private void Btn_Russian_language_final_exam_Click(object sender, RoutedEventArgs e)
        {
            if (label_Russian_language_final_exam.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Русский язык", "No data", enums.tab.final_exam);
            }
        }

        private async void Btn_final_exam_Click(object sender, RoutedEventArgs e)
        {
            var f = 0;
            if (label_physics.Text != "да")
                f += 1;
            if (label_informatics.Text != "да")
                f += 1;
            if (label_programming.Text != "да")
                f += 1;
            if (label_foreign_language_final_exam.Text != "да")
                f += 1;
            if (label_math_final_exam.Text != "да")
                f += 1;
            if (label_Russian_language_final_exam.Text != "да")
                f += 1;

            if (f != 0)
            {
                if (MessageBox.Show($"У вас не заполнено {f} поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                {
                    if (MessageBox.Show("Добавить ещё один объект?", "WHO?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Model.Object.Final_exams.Add(Model.Final_Exam);
                        Model.Final_Exam = new Class_final_exam();
                        to_default_final_exam();
                        HideAcademicSubject();
                    }
                    else
                    {
                        Model.Object.Final_exams.Add(Model.Final_Exam);
                        Model.Final_Exam = new Class_final_exam();
                        to_default_final_exam();
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
                    Model.Object.Final_exams.Add(Model.Final_Exam);
                    Model.Final_Exam = new Class_final_exam();
                    to_default_final_exam();
                    HideAcademicSubject();
                }
                else
                {
                    Model.Object.Final_exams.Add(Model.Final_Exam);
                    Model.Final_Exam = new Class_final_exam();
                    to_default_final_exam();
                    HideAcademicSubject();
                    if (!(await MainViewModel.SerializeElement(MainViewModel.DefaultPathToFile,
                                this.Model.Object)))
                    {
                        MessageBox.Show($"В процессе произошла ошибка");
                    }
                }
            }
        }

        private void to_default_final_exam()
        {
            label_physics.Text = "нет";
            label_physics.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
              btn_physics.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_informatics.Text = "нет";
            label_informatics.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
              btn_informatics.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_programming.Text = "нет";
            label_programming.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
              btn_programming.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_Russian_language_final_exam.Text = "нет";
            label_Russian_language_final_exam.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
              btn_Russian_language_final_exam.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_foreign_language_final_exam.Text = "нет";
            label_foreign_language_final_exam.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
              btn_foreign_language_final_exam.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_math_final_exam.Text = "нет";
            label_math_final_exam.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
              btn_math_final_exam.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
        }
    }
}
