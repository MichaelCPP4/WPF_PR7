using Lib_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace WPF_PR5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Car car;
        Lorry lorry;

        public MainWindow()
        {
            InitializeComponent();
        }

        void Print(object transport)
        {
            if (transport.GetType() == typeof(Car))
            {
                car = transport as Car;
                textBoxOutLog.Text = $"Марка: {car.Marka ?? "Без названия"}" +
                        $"\nКол-во целиндров: {car.NumOfCylinders}"
                        + $"\nМощность двигателя в Л.С.: {car.HorsePower}"
                        + $"\nМощность двигателя в  кВт: {car.KW}";
            }
            else
            {
                lorry = transport as Lorry;
                textBoxOutLog.Text = $"Марка: {lorry.Marka ?? "Без названия"}" +
                        $"\nКол-во целиндров: {lorry.NumOfCylinders}"
                        + $"\nМощность двигателя в Л.С.: {lorry.HorsePower}"
                        + $"\nМощность двигателя в  кВт: {lorry.KW}"
                        + $"\nГрузоподъёмность в тоннах: {lorry.Capacity}";
            }
        }

        void Record(Car car)
        {
            if (int.TryParse(textBoxNumCylinders.Text, out int numCylinders) && double.TryParse(textBoxkW.Text, out  double kW))
            {
                car.SetParams(textBoxMarka.Text, numCylinders, kW);
            }
            else if (int.TryParse(textBoxNumCylinders.Text, out numCylinders))
            {
                car.KW = new double();
                car.SetParams(textBoxMarka.Text, numCylinders);
            }
            else if (double.TryParse(textBoxkW.Text, out kW))
            {
                car.NumOfCylinders = new int();
                car.SetParams(textBoxMarka.Text, kW);
            }
            else
            {
                car.SetParams(textBoxMarka.Text, new int(), new double());
            }
        }

        void Record(Lorry transport, double capacity)
        {
            if (int.TryParse(textBoxNumCylindersLorry.Text, out int numCylinders) && double.TryParse(textBoxkWLorry.Text, out  double kW))
            {
                lorry.SetParams(textBoxMarkaLorry.Text, numCylinders, kW);
                lorry.Capacity = capacity;
            }
            else if (int.TryParse(textBoxNumCylindersLorry.Text, out numCylinders))
            {
                lorry.KW = new double();
                lorry.SetParams(textBoxMarkaLorry.Text, numCylinders);
                lorry.Capacity = capacity;
            }
            else if (double.TryParse(textBoxkWLorry.Text, out kW))
            {
                lorry.NumOfCylinders = new int();
                lorry.SetParams(textBoxMarkaLorry.Text, kW);
                lorry.Capacity = capacity;
            }
            else
            {
                lorry.SetParams(textBoxMarkaLorry.Text, new int(), new double());
                lorry.Capacity = capacity;
            }
        }

        private void ZapisButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxCars.SelectedItem != null)
            {
                //Провверка на авто или грузовик
                if (listBoxCars.SelectedItem.GetType() == typeof(Car))
                {
                    car = listBoxCars.SelectedItem as Car;

                    Record(car);

                    listBoxCars.Items.Insert(listBoxCars.SelectedIndex, car);
                    listBoxCars.Items.RemoveAt(listBoxCars.SelectedIndex);
                }
                else
                {
                    if (textBoxMarkaLorry.Text != string.Empty && double.TryParse(textBoxCapacityLorry.Text, out double capacity))
                    {
                        Record(lorry, capacity);

                        listBoxCars.Items.Insert(listBoxCars.SelectedIndex, lorry);
                        listBoxCars.Items.RemoveAt(listBoxCars.SelectedIndex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите машину","Error!");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            if (tabControlTransport.SelectedIndex == 0)
            {
                if (textBoxMarka.Text != string.Empty)
                {

                    listBoxCars.Items.Add(new Car());

                    car = listBoxCars.Items[listBoxCars.Items.Count - 1] as Car;

                    Record(car);

                }
                else
                {
                    MessageBox.Show("Введите марку для машины.", "Error!");
                }
            }
            else
            {
                if (textBoxMarkaLorry.Text != string.Empty && double.TryParse(textBoxCapacityLorry.Text, out double capacity))
                {

                    listBoxCars.Items.Add(new Lorry());
                    lorry = new Lorry();
                    lorry = listBoxCars.Items[listBoxCars.Items.Count - 1] as Lorry;

                    Record(lorry,capacity);
                }
                else
                {
                    MessageBox.Show("Введите марку для машины и грузоподъёмность.", "Error!");
                }
            }
        }

        private void VivodButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxCars.SelectedItem != null)
            {
                //car = listBoxCars.SelectedItem as Car;

                Print(listBoxCars.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите машину", "Error!");
            }
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            listBoxCars.Items.Remove(listBoxCars.SelectedItem);

        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Задание: Использовать класс Саr (машина), характеризуемый торговой маркой (строка), \r\nчислом цилиндров, мощностью. Создать производный класс Lorry (грузовик), \r\nхарактеризуемый также грузоподъемностью кузова. Определить функции \r\nпереназначения марки и изменения грузоподъемности.\r\n Выполнил Иванов Михаил ИСП-31", "О программе");
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxCars.SelectedItem !=null)
            {
                car = listBoxCars.SelectedItem as Car;
                car.PlusPower();
                listBoxCars.SelectedItem = car;

                Print(car);
            }
            else
            {
                MessageBox.Show("Выберите машину, которой будете увеличивать мощность", "Error!");
            }
        }
    }
}