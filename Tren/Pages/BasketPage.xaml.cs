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
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        decimal? help;

        public BasketPage()
        {
            InitializeComponent();

            BasketList.ItemsSource = CurrentList.basketProducts;
            CountOfSelected.Text = (CurrentList.basketProducts.Count).ToString();
            CurrentList.priceTotal = 0;
            CurrentList.discountTotal = 0;
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

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            BasketList.ItemsSource = null;
            CurrentList.basketProducts.Clear();
            CountOfSelected.Text = (CurrentList.basketProducts.Count).ToString();
            CurrentList.priceTotal = 0;
            CurrentList.discountTotal = 0;
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

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new MainPage());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Products result = (sender as Button)?.DataContext as Products; // получение объекта, который нужно добавить
            CurrentList.basketProducts.Remove(result); // добавляем элемент в лист корзины
            BasketList.ItemsSource = null;
            BasketList.ItemsSource = CurrentList.basketProducts;
            CountOfSelected.Text = (CurrentList.basketProducts.Count).ToString();
            CurrentList.priceTotal = 0;
            CurrentList.discountTotal = 0;
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
}
