using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_2_WPF
{
    public partial class StartingWindow : Window
    {
        private void Tab_trial_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            tab_Test.Header = "Тест";
            this.HideAcademicSubject();
        }

        private void BackToTab()
        {
            tab_Test.Header = "Тест";
            if (Model.Tab == enums.tab.trial)
                MainTab.SelectedItem = tab_trial;
            else if (Model.Tab == enums.tab.test)
                MainTab.SelectedItem = tab_Test;
            else if (Model.Tab == enums.tab.final_exam)
                MainTab.SelectedItem = tab_final_exam;
            else if (Model.Tab == enums.tab.exam)
                MainTab.SelectedItem = tab_exam;
        }
        
    }
}
