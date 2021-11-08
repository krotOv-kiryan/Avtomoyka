using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Avtomoyka1
{
    public class ListUsers :  Page, IPage
    {
        Model model;
        public ObservableCollection<User> Users { get; set; }
        public void SetVM(IPageVM vm)
        {
            throw new NotImplementedException();
        }
        public void SetModel(Model model)
        {

        }
    }
}
