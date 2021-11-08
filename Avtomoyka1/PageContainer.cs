using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Avtomoyka1
{
    public class PageContainer
    {
        static Model model;

        static Dictionary<PageType, Page> pages =
            new Dictionary<PageType, Page>();

        static Dictionary<PageType, (Type, Type)> pageTypes =
            new Dictionary<PageType, (Type, Type)>();

        /*internal static void SetModel(Model model) неправильная реализация
        {
            throw new NotImplementedException();
        }*/

        public static event EventHandler<PageType> CurrentPageChanged;
        public static void RegisterPageType(PageType type,
                Type pageType, Type vmType)
        {
            if (pageTypes.ContainsKey(type))
                throw new Exception("Заданный тип страницы уже зарегистрирован");
            pageTypes.Add(type, (pageType, vmType));
        }
        public static Page GetPageByType(PageType type)
        {
            if (pages.ContainsKey(type))
                return pages[type];
            var page = (Page)Activator.CreateInstance(pageTypes[type].Item1);
            pages.Add(type, page);
            var vm = (IPageVM)Activator.CreateInstance(pageTypes[type].Item2);
            vm.SetModel(model);
            ((IPage)page).SetVM(vm);
            return page;
        }
        public static void SetModel(Model model)
        {
            PageContainer.model = model;
        }
        public static void ChangePageTo(PageType type)
        {
            CurrentPageChanged?.Invoke(null, type); //тут я не понял...что-то помню про Invoke,но не точно
        }
        static PageContainer()
        {
            // RegisterPageType(PageType. , typeof( ), typeof( )); //(PageType.ListItems, typeof(ListItems), typeof(ListItemsVM))
        }
    }
}
