using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library;
using Lab_2_WPF.ViewModel;

namespace Lab_2_WPF
{
    public partial class StartingWindow : Window
    {
        private async Task<Class_union> LoadData()
        {
            return await MainViewModel.
                    DeserializeElement<Class_union>(MainViewModel.DefaultPathToFile) ?? new Class_union();
        }


        private void SearchButton_test_Click(object sender, RoutedEventArgs e)
        {
            DataGridOfElementsInTests.ItemsSource = this.Model.Object.Tests.Where(m => m.Theme.ToLower().
              Contains(this.Model.Search_Test.ToLower())).ToList();
        }
        private void Search_test_Click(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (this.Model.Search_Test == null)
                this.Model.Search_Test = "";
            DataGridOfElementsInTests.ItemsSource = this.Model.Object.Tests.Where(m => m.Theme.ToLower().
              Contains(this.Model.Search_Test.ToLower())).ToList();
        }


        private void SearchButton_trial_Click(object sender, RoutedEventArgs e)
        {
            DataGridOfElementsInTrial.ItemsSource = this.Model.Object.Trials.Where(m => m.Data_Analysis.Theme.ToLower().
              Contains(this.Model.Search_Trial.ToLower())).ToList();
        }
        private void Search_trial_Click(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (this.Model.Search_Trial == null)
                this.Model.Search_Trial = "";
            DataGridOfElementsInTrial.ItemsSource = this.Model.Object.Trials.Where(m => m.Data_Analysis.Theme.ToLower().
              Contains(this.Model.Search_Trial.ToLower())).ToList();
        }


        private void SearchButton_finalexam_Click(object sender, RoutedEventArgs e)
        {
            DataGridOfElementsInFinalExam.ItemsSource = this.Model.Object.Final_exams.Where(m => m.Programming.Theme.ToLower().
              Contains(this.Model.Search_FinalExam.ToLower())).ToList();
        }
        private void Search_finalexam_Click(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (this.Model.Search_FinalExam == null)
                this.Model.Search_FinalExam = "";
            DataGridOfElementsInFinalExam.ItemsSource = this.Model.Object.Final_exams.Where(m => m.Programming.Theme.ToLower().
              Contains(this.Model.Search_FinalExam.ToLower())).ToList();

        }


        private void SearchButton_exam_Click(object sender, RoutedEventArgs e)
        {
            DataGridOfElementsInExam.ItemsSource = this.Model.Object.Exams.Where(m => m.Math.Theme.ToLower().
              Contains(this.Model.Search_Exam.ToLower())).ToList();
        }
        private void Search_exam_Click(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (this.Model.Search_Exam == null)
                this.Model.Search_Exam = "";
            DataGridOfElementsInExam.ItemsSource = this.Model.Object.Exams.Where(m => m.Math.Theme.ToLower().
              Contains(this.Model.Search_Exam.ToLower())).ToList();
        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Model.Object = await LoadData();
        }
        private async void Window_Loaded(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Model.Object = await LoadData();
        }
    }
}
