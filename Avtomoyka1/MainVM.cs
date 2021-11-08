using System.Collections.Generic;
using System.Windows.Controls;

namespace Avtomoyka1
{
    internal class MainVM : Mvvm1125.MvvmNotify
    { //тут и все команды?MainWindow.xaml
        Model model;
        public List<User> Users { get; set; }
        private string currentMessage;
        public Page CurrentPage { get; set; }
       
        public MainVM()
        {
            model = new Model();
            model.CreateMessage += (o, e) => CurrentMessage = e;
            PageContainer.SetModel(model);
            CurrentPage = PageContainer.GetPageByType(PageType.ListUsers);

            PageContainer.CurrentPageChanged += PageContainer_CurrentPageChanged;
        }
        void PageContainer_CurrentPageChanged(object sender, PageType e)
        {
            CurrentPage = PageContainer.GetPageByType(e);
            NotifyPropertyChanged("CurrentPage");
        }
        public string CurrentMessage
        {
            get => currentMessage;
            private set
            {
                currentMessage = value;
                NotifyPropertyChanged();
            }
        }
    }
}