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
        private void Btn_data_analysis_Click(object sender, RoutedEventArgs e)
        {
            if (label_data_analysis.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Анализ данных", "No data", enums.tab.trial);
            }
        }

        private void Btn_data_structures_Click(object sender, RoutedEventArgs e)
        {
            if (label_data_structures.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Структуры данных", "No data", enums.tab.trial);
            }
        }

        private void Btn_deep_learning_Click(object sender, RoutedEventArgs e)
        {
            if (label_deep_learning.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Машинное обучение", "No data", enums.tab.trial);
            }
        }

        private void Btn_math_trial_Click(object sender, RoutedEventArgs e)
        {
            if (label_math_trial.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Математика", "No data", enums.tab.trial);
            }
        }

        private void Btn_foreign_language_trial_Click(object sender, RoutedEventArgs e)
        {
            if (label_foreign_language_trial.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Иностранный язык", "No data", enums.tab.trial);
            }
        }

        private void Btn_Russian_language_trial_Click(object sender, RoutedEventArgs e)
        {
            if (label_Russian_language_trial.Text != "да")
            {
                if (MessageBox.Show("У вас 1 попытка создать данное поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    ViewAcademicSubject("Русский язык", "No data", enums.tab.trial);
            }
        }

        private async void Btn_trial_Click(object sender, RoutedEventArgs e)
        {
            var f = 0;
            if (label_data_analysis.Text != "да")
                f += 1;
            if (label_data_structures.Text != "да")
                f += 1;
            if (label_deep_learning.Text != "да")
                f += 1;
            if (label_foreign_language_trial.Text != "да")
                f += 1;
            if (label_math_trial.Text != "да")
                f += 1;
            if (label_Russian_language_trial.Text != "да")
                f += 1;

            if (f!=0)
            {
                if (MessageBox.Show($"У вас не заполнено {f} поле, хотите продолжить заполнение поля?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                {
                    if (MessageBox.Show("Добавить ещё один объект?", "WHO?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Model.Object.Trials.Add(Model.Trial);
                        Model.Trial = new Class_trial();
                        to_default_trial();
                        HideAcademicSubject();
                    }
                    else
                    {
                        Model.Object.Trials.Add(Model.Trial);
                        Model.Trial = new Class_trial();
                        to_default_trial();
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
                    Model.Object.Trials.Add(Model.Trial);
                    Model.Trial = new Class_trial();
                    to_default_trial();
                    HideAcademicSubject();
                }
                else
                {
                    Model.Object.Trials.Add(Model.Trial);
                    Model.Trial = new Class_trial();
                    to_default_trial();
                    HideAcademicSubject();
                    if (!(await MainViewModel.SerializeElement(MainViewModel.DefaultPathToFile,
                                this.Model.Object)))
                    {
                        MessageBox.Show($"В процессе произошла ошибка");
                    }
                }
            }
        }
        
        private void to_default_trial()
        {
            label_data_analysis.Text = "нет";
            label_data_analysis.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
            btn_data_analysis.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_data_structures.Text = "нет";
            label_data_structures.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
            btn_data_structures.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_deep_learning.Text = "нет";
            label_deep_learning.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
            btn_deep_learning.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_Russian_language_trial.Text = "нет";
            label_Russian_language_trial.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
            btn_Russian_language_trial.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_foreign_language_trial.Text = "нет";
            label_foreign_language_trial.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
            btn_foreign_language_trial.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
            label_math_trial.Text = "нет";
            label_math_trial.Foreground = new SolidColorBrush(Color.FromRgb(224, 39, 39));
            btn_math_trial.Background = new SolidColorBrush(Color.FromRgb(237, 175, 66));
        }
    }
}
