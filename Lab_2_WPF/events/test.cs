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
        private void setToDefaultTasks()
        {
            this.quest.Text = "";
            this.answer_1.Text = "";
            this.answer_2.Text = "";
            this.answer_3.Text = "";
            this.answer_4.Text = "";
            this.task.Visibility = Visibility.Hidden;
            this.tasks_left_1.Visibility = Visibility.Hidden;
            this.tasks_left_main.Content = "";
        }


        private void setToDefaultMainInfo()
        {
            this.FIO_teacher_input.Text = "";
            this.theme.Text = "";
            this.countTask.Content = "1";
            this.time.Text = "00:10:00";

        }


        private void PART_IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(this.countTask.Content.ToString(), out int count))
            {
                if (count > 30)
                    this.countTask.Content = "30";
                else
                    this.countTask.Content = $"{count + 1}";
                this.task.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении кол-ва заданий");
                this.countTask.Content = "1";
            }
        }


        private void PART_DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(this.countTask.Content.ToString(), out int count))
            {
                if (count <= 1)
                    this.countTask.Content = "1";
                else
                    this.countTask.Content = $"{count - 1}";
                this.task.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Ошибка при убавлении кол-ва заданий");
                this.countTask.Content = "1";
            }
        }


        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.task.Visibility != Visibility.Visible && this.countTask.Content.ToString() != "0")
            {
                this.task.Visibility = Visibility.Visible;
            }
            else
            {
                if (int.TryParse(this.countTask.Content.ToString(), out int count))
                {
                    this.tasks_left_1.Visibility = Visibility.Visible;
                    this.tasks_left_main.Visibility = Visibility.Visible;
                    if (this.tasks_left_main.Content.ToString() == "")
                    {
                        this.tasks_left_main.Content = "0";
                    }
                    else if (int.TryParse(this.tasks_left_main.Content.ToString(), out int cTask))
                    {
                        if (cTask < count)
                        {
                            this.tasks_left_main.Content = $"{cTask + 1}";
                            this.Model.Tasks.Add(
                                new Class_Task
                                {
                                    Text = this.quest.Text,
                                    Answer_option = new List<string>
                                    {
                                        this.answer_1.Text,
                                        this.answer_2.Text,
                                        this.answer_3.Text,
                                        this.answer_4.Text
                                    },
                                    Number = cTask,
                                    Answer = this.answer_1.Text
                                }
                            );
                            this.quest.Text = "";
                            this.answer_1.Text = "";
                            this.answer_2.Text = "";
                            this.answer_3.Text = "";
                            this.answer_4.Text = "";
                            if (cTask + 1 == count)
                                NextButton_Click(sender, e);
                        }
                        else if (cTask >= count)
                        {
                            if (Model.Tab == enums.tab.test)
                            {
                                if (MessageBox.Show("Добавить ещё один объект?", "WHO?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                                {
                                    var t = this.time.Value.ToString();
                                    t.Remove(0, 11);
                                    this.Model.Object.Tests.Add(new Class_test(
                                          this.theme.Text,
                                          this.Model.Tasks,
                                          new List<string>
                                          {
                                            $"{ t[0] }{ t[1] }",
                                            $"{ t[3] }{ t[4] }",
                                            $"{ t[6] }{ t[7] }"
                                          }
                                        )
                                      );
                                    
                                    this.Model.Tasks = new List<Class_Task> { };
                                    setToDefaultTasks();
                                    setToDefaultMainInfo();
                                }
                                else
                                {
                                    var t = this.time.Value.ToString();
                                    t = t.Remove(0, 11);
                                    if (t.Length == 7)
                                        t = t.Insert(0, "0");
                                    this.Model.Object.Tests.Add(new Class_test(
                                        this.theme.Text,
                                        this.Model.Tasks,
                                        new List<string>
                                        {
                                            $"{ t[0] }{ t[1] }",
                                            $"{ t[3] }{ t[4] }",
                                            $"{ t[6] }{ t[7] }"
                                        })
                                    );

                                    this.Model.Tasks = new List<Class_Task> { };
                                    setToDefaultTasks();
                                    setToDefaultMainInfo();
                                    if (!(await MainViewModel.SerializeElement(MainViewModel.DefaultPathToFile,
                                    this.Model.Object)))
                                    {
                                        MessageBox.Show($"В процессе произошла ошибка");
                                    }
                                }
                            }
                            else
                            {
                                var t = this.time.Value.ToString();
                                t.Remove(0, 11);
                                Model.Subject.FIO_chief = FIO_teacher_input.Text.ToString();
                                Model.Subject.Tasks = this.Model.Tasks;
                                Model.Subject.Theme = this.theme.Text;
                                Model.Subject.SetTime
                                (
                                    new List<string>
                                    {
                                                $"{ t[0] }{ t[1] }",
                                                $"{ t[3] }{ t[4] }",
                                                $"{ t[6] }{ t[7] }"
                                    }
                                );

                                if (Model.Tab == enums.tab.trial)
                                {
                                    switch(name_of_academic_subject.Content.ToString())
                                    {
                                        case "Анализ данных": { Model.Trial.Data_Analysis = Model.Subject; label_data_analysis.Text = "да"; label_data_analysis.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_data_analysis.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Структуры данных": { Model.Trial.Data_structures = Model.Subject; label_data_structures.Text = "да"; label_data_structures.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_data_structures.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Машинное обучение": { Model.Trial.Deep_learning = Model.Subject; label_deep_learning.Text = "да"; label_deep_learning.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_deep_learning.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Математика": { Model.Trial.Math = Model.Subject; label_math_trial.Text = "да"; label_math_trial.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_math_trial.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Иностранный язык": { Model.Trial.Foreign_language = Model.Subject; label_foreign_language_trial.Text = "да"; label_foreign_language_trial.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_foreign_language_trial.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Русский язык": { Model.Trial.Russian_language = Model.Subject; label_Russian_language_trial.Text = "да"; label_Russian_language_trial.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_Russian_language_trial.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }

                                    }
                                }
                                else if(Model.Tab == enums.tab.exam)
                                {
                                    switch (name_of_academic_subject.Content.ToString())
                                    {
                                        case "Математика": { Model.Exam.Math = Model.Subject; label_math.Text = "да"; label_math.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_math.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Иностранный язык": { Model.Exam.Foreign_language = Model.Subject; label_foreign_language.Text = "да"; label_foreign_language.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_foreign_language.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Русский язык": { Model.Exam.Russian_language = Model.Subject; label_Russian_language.Text = "да"; label_Russian_language.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_Russian_language.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                    }
                                }
                                else if(Model.Tab == enums.tab.final_exam)
                                {
                                    switch (name_of_academic_subject.Content.ToString())
                                    {
                                        case "Физика": { Model.Final_Exam.Physics = Model.Subject; label_physics.Text = "да"; label_physics.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_physics.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Информатика": { Model.Final_Exam.Informatics= Model.Subject; label_informatics.Text = "да"; label_informatics.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_informatics.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Программирование": { Model.Final_Exam.Programming= Model.Subject; label_programming.Text = "да"; label_programming.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_programming.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Математика": { Model.Final_Exam.Math = Model.Subject; label_math_final_exam.Text = "да"; label_math_final_exam.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_math_final_exam.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Иностранный язык": { Model.Final_Exam.Foreign_language = Model.Subject; label_foreign_language_final_exam.Text = "да"; label_foreign_language_final_exam.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_foreign_language_final_exam.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                        case "Русский язык": { Model.Final_Exam.Russian_language = Model.Subject; label_Russian_language_final_exam.Text = "да"; label_Russian_language_final_exam.Foreground = new SolidColorBrush(Color.FromRgb(107, 189, 103)); btn_Russian_language_final_exam.Background = new SolidColorBrush(Color.FromRgb(119, 197, 125)); break; }
                                    }
                                }
                                BackToTab();
                                HideAcademicSubject();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Ошибка c countTask");
                }
                else
                    MessageBox.Show("Ошибка c countTask");
            }


        }


        private void HideAcademicSubject()
        {
            this.setToDefaultTasks();
            this.Model.Tab = enums.tab.test;
            this.name_item.Visibility = Visibility.Hidden;
            this.name_of_academic_subject.Visibility = Visibility.Hidden;
            this.FIO_teacher.Visibility = Visibility.Hidden;
            this.FIO_teacher_input.Visibility = Visibility.Hidden;
            this.name_of_academic_subject.Content = "";
            this.FIO_teacher_input.Text = "";
            this.theme.Text = "";

        }


        private void ViewAcademicSubject(string name, string fio, enums.tab tab)
        {
            this.Model.Subject = new Class_Academic_Subject(name, fio);
            this.Model.Tab = tab;
            tab_Test.Header = name;
            this.name_item.Visibility = Visibility.Visible;
            this.name_of_academic_subject.Visibility = Visibility.Visible;
            this.FIO_teacher.Visibility = Visibility.Visible;
            this.FIO_teacher_input.Visibility = Visibility.Visible;
            this.name_of_academic_subject.Content = name;
            MainTab.SelectedItem = tab_Test;
        }


    }
}
