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

namespace dz6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum Sex
    {
        Male,
        Female,
        Any
    }
    class Person
    {
        public string name { get; set; }
        public string patronymic;
        public string lastname;
        public int age;
        public Sex sex;

        public string getSex()
        {
            if (sex == Sex.Male)
                return "Мужской";
            else if (sex == Sex.Female)
                return "Женский";
            else
                return "Другой";
        }
    }

    class Doschoolnik : Person
    {
        public int nashel;
        public int potratil;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}\n\tВозраст:{3}  Пол:{4}\n\tCтатус: Дошкольник\n\tДоход {5},   Расход: {6}",
                    name, patronymic, lastname, age, getSex(), nashel, potratil);
        }
        public override bool Equals(object obj)
        {
            Doschoolnik o = obj as Doschoolnik;
            if (o.nashel == this.potratil)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return potratil;
        }
    }
    class Schoolnik : Person
    {
        public int na_obed;
        public int na_syhariki;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}\n\tВозраст:{3}  Пол:{4}\n\tCтатус: Школьник\n\tДоход {5},   Расход: {6}",
                    name, patronymic, lastname, age, getSex(), na_obed, na_syhariki);
        }
        public override bool Equals(object obj)
        {
            Schoolnik o = obj as Schoolnik;
            if (o.na_obed == this.na_syhariki)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return na_syhariki;
        }
    }
    class Student : Person
    {
        public int stipendia;
        public int rastrat;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}\n\tВозраст:{3}  Пол:{4}\n\tCтатус: Студент\n\tДоход {5},   Расход: {6}",
                    name, patronymic, lastname, age, getSex(), stipendia, rastrat);
        }
        public override bool Equals(object obj)
        {
            Student o = obj as Student;
            if (o.stipendia == this.rastrat)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return rastrat;
        }
    }
    class Worker : Person
    {
        public int zarplata;
        public int rastrata;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}\n\tВозраст: {3}  Пол: {4}\n\tCтатус: Работающий \n\tДоход: {5} ₽   Расход: {6} ₽",
                    name, patronymic, lastname, age, getSex(), zarplata, rastrata);
        }
        public override bool Equals(object obj)
        {
            Worker o = obj as Worker;
            if (o.zarplata == this.rastrata)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return rastrata;
        }
    }
    public partial class MainWindow : Window
    {


        List<Person> Spisok = new List<Person>
        {
            new Student {name =  "Невилл",patronymic = "Френкович", lastname = "Долгопупс", age = 19, sex = Sex.Male,
                stipendia = 5000, rastrat = 15  },
            new Worker {name =  "Иван",patronymic = "Иванович", lastname = "Иванов", age = 64, sex = Sex.Male,
                zarplata = 25000, rastrata = 25000 },
            new Doschoolnik {name =  "Алексей",patronymic = "Андреевич", lastname = "Руков", age = 4, sex = Sex.Male,
                nashel = 0, potratil = 0 },
            new Schoolnik {name =  "Александр",patronymic = "Сергеевич", lastname = "Пушкин", age = 7, sex = Sex.Male,
                na_obed = 0, na_syhariki = 0 },
        };
        bool input_txt = false, input_cb = false;
        public MainWindow()
        {
            InitializeComponent();
            Write();
            TB_NAME.IsEnabled = false;
            TB_FAM.IsEnabled = false;
            TB_OTECH.IsEnabled = false;
            TB_DOH.IsEnabled = false;
            TB_RAS.IsEnabled = false;
            TB_VOZR.IsEnabled = false;
            CB_SEX.IsEnabled = false;
            CB_STATUS.IsEnabled = false;
        }

        private void Write()
        {
            SPISOK.Items.Clear();
            for (int i = 0; i < Spisok.Count; i++)
            {
                SPISOK.Items.Add($"{i + 1}. {Spisok[i].ToString()}");
            }
        }

        private void BT_ADD_Click(object sender, RoutedEventArgs e)
        {
            TB_NAME.IsEnabled = true;
            TB_FAM.IsEnabled = true;
            TB_OTECH.IsEnabled = true;
            TB_DOH.IsEnabled = true;
            TB_RAS.IsEnabled = true;
            TB_VOZR.IsEnabled = true;
            CB_SEX.IsEnabled = true;
            CB_STATUS.IsEnabled = true;
        }
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            input_txt = true;
            int y;

            if (sender is TextBox)
            {
                if (String.Compare((sender as TextBox).Name, "TB_NAME") == 0 || String.Compare((sender as TextBox).Name, "TB_FAM") == 0 || String.Compare((sender as TextBox).Name, "TB_OTECH") == 0)
                {
                    for (int i = 0; i < (sender as TextBox).Text.Length; i++)
                    {
                        if (!char.IsLetter((sender as TextBox).Text[i]) && (sender as TextBox).Text.Length != 0)
                        {
                            MessageBox.Show("ФИО могут содержать только буквы");
                            input_txt = false;
                        }

                    }
                }

                if (String.Compare((sender as TextBox).Name, "TB_RAS") == 0 || String.Compare((sender as TextBox).Name, "TB_DOH") == 0 || String.Compare((sender as TextBox).Name, "TB_VOZR") == 0)
                {
                    if (!int.TryParse((sender as TextBox).Text, out y) && (sender as TextBox).Text.Length != 0)
                    {
                        MessageBox.Show("Вводить надо число.");
                        input_txt = false;
                    }

                    else if (String.Compare((sender as TextBox).Name, "TB_VOZR") == 0)
                    {
                        if (TB_VOZR.Text == "")
                        {
                            input_txt = false;
                        }

                        else if (Int32.Parse(TB_VOZR.Text) > 120)
                        {
                            MessageBox.Show("Введите реальный возраст.");
                            input_txt = false;
                        }
                    }

                    else if (TB_RAS.Text.Length != 0 && TB_DOH.Text.Length != 0)
                    {
                        if (Int32.Parse(TB_RAS.Text) > Int32.Parse(TB_DOH.Text))
                        {
                            MessageBox.Show("Расход не может превышать доход.");
                            input_txt = false;
                        }
                    }
                }
            }

            if (TB_NAME.Text.Length == 0 || TB_FAM.Text.Length == 0 || TB_OTECH.Text.Length == 0 || TB_DOH.Text.Length == 0 || TB_VOZR.Text.Length == 0 || TB_VOZR.Text == null || TB_RAS.Text.Length == 0)
                input_txt = false;
            else
                input_txt = true;

            if (input_cb && input_txt)
                BT_SAVE.IsEnabled = true;
            else
                BT_SAVE.IsEnabled = false;
        }

        private void BT_DEL_Click(object sender, RoutedEventArgs e)
        {
            int n = SPISOK.SelectedIndex;
            Spisok.RemoveAt(n);
            Write();
        }

        private void BT_SAVE_Click(object sender, RoutedEventArgs e)
        {
            int type = CB_STATUS.SelectedIndex, sex_ind = CB_SEX.SelectedIndex;
            switch (type)
            {
                case 0:
                    {
                        Spisok.Add(new Doschoolnik
                        {
                            name = TB_NAME.Text,
                            patronymic = TB_OTECH.Text,
                            lastname = TB_FAM.Text,
                            age = Int32.Parse(TB_VOZR.Text),
                            nashel = Int32.Parse(TB_DOH.Text),
                            potratil = Int32.Parse(TB_RAS.Text)
                        });
                        break;
                    }
                case 1:
                    {
                        Spisok.Add(new Schoolnik
                        {
                            sex = Sex.Any,
                            name = TB_NAME.Text,
                            patronymic = TB_OTECH.Text,
                            lastname = TB_FAM.Text,
                            age = Int32.Parse(TB_VOZR.Text),
                            na_obed = Int32.Parse(TB_DOH.Text),
                            na_syhariki = Int32.Parse(TB_RAS.Text)
                        });
                        break;
                    }
                case 2:
                    {
                        Spisok.Add(new Student
                        {
                            sex = Sex.Any,
                            name = TB_NAME.Text,
                            patronymic = TB_OTECH.Text,
                            lastname = TB_FAM.Text,
                            age = Int32.Parse(TB_VOZR.Text),
                            stipendia = Int32.Parse(TB_DOH.Text),
                            rastrat = Int32.Parse(TB_RAS.Text),
                        });
                        break;
                    }
                case 3:
                    {
                        Spisok.Add(new Worker
                        {
                            sex = Sex.Any,
                            name = TB_NAME.Text,
                            patronymic = TB_OTECH.Text,
                            lastname = TB_FAM.Text,
                            age = Int32.Parse(TB_VOZR.Text),
                            zarplata = Int32.Parse(TB_DOH.Text),
                            rastrata = Int32.Parse(TB_RAS.Text)
                        });
                        break;
                    }
            }

            switch (sex_ind)
            {
                case 0:
                    {
                        Spisok[Spisok.Count - 1].sex = Sex.Male;
                        break;
                    }
                case 1:
                    {
                        Spisok[Spisok.Count - 1].sex = Sex.Female;
                        break;
                    }
            }
            TB_NAME.Text = "";
            TB_FAM.Text = "";
            TB_OTECH.Text = "";
            TB_DOH.Text = "";
            TB_RAS.Text = "";
            TB_VOZR.Text = "";
            CB_SEX.Text = "";
            CB_STATUS.Text = "";
            TB_NAME.IsEnabled = false;
            TB_FAM.IsEnabled = false;
            TB_OTECH.IsEnabled = false;
            TB_DOH.IsEnabled = false;
            TB_RAS.IsEnabled = false;
            TB_VOZR.IsEnabled = false;
            CB_SEX.IsEnabled = false;
            CB_STATUS.IsEnabled = false;

            Write();

        }

        private void SPISOK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SPISOK.SelectedIndex != -1)
                BT_DEL.IsEnabled = true;
            else
                BT_DEL.IsEnabled = false;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            input_cb = false;
            if (CB_SEX.SelectedIndex != -2 && CB_STATUS.SelectedIndex != -2)
                input_cb = true;

            if (input_cb && input_txt)
                BT_SAVE.IsEnabled = true;
            else
                BT_SAVE.IsEnabled = false;
        }

    }
}
