using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RAP.Control;
using RAP.Research;
using RAP;


namespace RAP
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //声明controller
        private ResearcherController ResearcherControl = new ResearcherController();

        public MainWindow()
        {
            InitializeComponent();
            //            ResearcherControl = (ResearcherController)(Application.Current.FindResource("researcherList") as
            //ObjectDataProvider).ObjectInstance;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ResearcherController.LoadReseachers();

            Dictionary<int, string> dic = new Dictionary<int, string>();
            for (int k = 0; k < ResearcherController.Researchers.Count; k++)
            {
                var name = ResearcherController.Researchers[k].FamilyName + ResearcherController.Researchers[k].GivenName + "(" + ResearcherController.Researchers[k].Title + ")";
                dic.Add(ResearcherController.Researchers[k].ID, name);
            }
            // var list = ResearcherController.Researchers.Select(o => o.FamilyName + o.GivenName).ToList();

            lbx_ResearchList.ItemsSource = dic;

            List<string> levelLSt = new List<string>();
            levelLSt.Add("A");
            levelLSt.Add("B");
            levelLSt.Add("C");
            levelLSt.Add("D");
            level.ItemsSource = levelLSt;
        }

        private void lbx_ResearchList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox thislist = e.Source as ListBox;
            var item = (KeyValuePair<int, string>)e.AddedItems[0];

            //查询数据
            ResearcherController.LoadResearcherDetails(item.Key);
            // ResearcherController.detail
            name.Text = ResearcherController.detail.GivenName + ResearcherController.detail.FamilyName;
            title.Text = ResearcherController.detail.Title;
            school.Text = ResearcherController.detail.School;
           
            campus.Text = ResearcherController.detail.Campus.ToString();
            email.Text = ResearcherController.detail.Email;

            currentjob.Text = ResearcherController.detail.CurrentJobTitle();
            
           
            
            
           




            //   name.tex
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var names = fullName.Text;
            var levels = level.SelectedItem?.ToString();

            ResearcherController.LoadReseachers(names, levels);

            Dictionary<int, string> dic = new Dictionary<int, string>();
            for (int k = 0; k < ResearcherController.Researchers.Count; k++)
            {
                var name = ResearcherController.Researchers[k].FamilyName + ResearcherController.Researchers[k].GivenName + "(" + ResearcherController.Researchers[k].Title + ")";
                dic.Add(ResearcherController.Researchers[k].ID, name);
            }
            // var list = ResearcherController.Researchers.Select(o => o.FamilyName + o.GivenName).ToList();

            lbx_ResearchList.ItemsSource = dic;

        }
    }
}
