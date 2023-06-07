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

namespace Tren.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        
        public MainPage()
        {
            InitializeComponent();
            CurrentList.products = CurrentList.db.Products
                .ToList();
            MainList.ItemsSource = CurrentList.products;
            if (CurrentList.basketProducts.Count != 0)
            {
                BasketButton.Visibility = Visibility.Visible;
                CurrentList.priceTotal = 0;
                CurrentList.discountTotal = 0;
                CountOfSelected.Text = (CurrentList.basketProducts.Count).ToString();
                foreach (Products item in CurrentList.basketProducts)
                { 
                    CurrentList.priceTotal += item.Price;
                }
                help = CurrentList.priceTotal;
                while (help > 0)
                {
                    help -= 500;
                    CurrentList.discountTotal += 1;
                }
                CurrentList.discountTotal -= 1;
                if (CurrentList.basketProducts.Count >= 3 && CurrentList.basketProducts.Count < 5)
                {
                    CurrentList.discountTotal += 5;

                }
                Price.Text = CurrentList.priceTotal.ToString();
                Discount.Text = CurrentList.discountTotal.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new BasketPage());
        }
        decimal? help;

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            BasketButton.Visibility = Visibility.Visible;
            CurrentList.basketProducts.Add(MainList.SelectedValue as Products);
            Products product = MainList.SelectedValue as Products;
            CountOfSelected.Text = (CurrentList.basketProducts.Count).ToString();
            CurrentList.priceTotal += product.Price;
            help = CurrentList.priceTotal;
            while (help > 0)
            {
                help -= 500;
                CurrentList.discountTotal += 1;
            }
            CurrentList.discountTotal -= 1;
            if (CurrentList.basketProducts.Count >= 3 && CurrentList.basketProducts.Count < 5)
            {
                CurrentList.discountTotal += 5;

            }
            Price.Text = CurrentList.priceTotal.ToString();
            Discount.Text = CurrentList.discountTotal.ToString();
        }
    }
}
