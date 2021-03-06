﻿using System;
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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using RGZ.Properties;

namespace RGZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btn_openmenu.Visibility = Visibility.Collapsed;
            //btn_closeright_Click(this, new RoutedEventArgs());
            btn_delete.Visibility = Visibility.Collapsed;
            btn_count.Visibility = Visibility.Collapsed;
            btn_count1.Visibility = Visibility.Collapsed;
            btn_deleteall.Visibility = Visibility.Collapsed;
            btn_settings_Click(this, new RoutedEventArgs());
            btn_openmenu_Click(this, new RoutedEventArgs());
            label_loading.Visibility = Visibility.Collapsed;
            btn_1.Visibility = Visibility.Collapsed;
            btn_2.Visibility = Visibility.Collapsed;
            btn_3.Visibility = Visibility.Collapsed;
            showMetrics();
            // textBox_path.Text = Settings.Default["fwork"].ToString();
        }

        private void btn_closemenu_Click(object sender, RoutedEventArgs e)
        {
            if (rect_menu.Height == 568 && rect_menu.Width == 250)
            {
                System.Windows.Media.Animation.DoubleAnimation da = new System.Windows.Media.Animation.DoubleAnimation();
                da.From = 250;
                da.To = rect_menu.Width - 200;
                da.Duration = TimeSpan.FromSeconds(0.22222);
                /*--------------------------------------------------------*/
                rect_menu.BeginAnimation(Rectangle.WidthProperty, da);
                btn_closemenu.Visibility = Visibility.Collapsed;
                btn_openmenu.Visibility = Visibility.Visible;
                btn_openfile_opened.Visibility = Visibility.Collapsed;
                btn_save_opened.Visibility = Visibility.Collapsed;
                btn_settings_open.Visibility = Visibility.Collapsed;
                btn_exit_opened.Visibility = Visibility.Collapsed;
                btn_openfolder_opened.Visibility = Visibility.Collapsed;
                btn_about_opened.Visibility = Visibility.Collapsed;
                textBox_name.Visibility = Visibility.Collapsed;
                btn_training_hide.Visibility = Visibility.Collapsed;
                /*--------------------------------------------------------*/
                btn_hideUI.IsEnabled = true;
            }

        }

        private void btn_training_Click(object sender, RoutedEventArgs e)
        {

            btn_training.Visibility = Visibility.Collapsed;
            btn_training_hide.Visibility = Visibility.Visible;
            label_loading.Visibility = Visibility.Visible;
            btn_1_Click(this, new RoutedEventArgs());
            btn_1.Visibility = Visibility.Visible;
            btn_2.Visibility = Visibility.Visible;
            btn_3.Visibility = Visibility.Visible;


        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/11.png");
            var img = new BitmapImage(uri);
            image.Source = img;
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/22.png");
            var img = new BitmapImage(uri);
            image.Source = img;
        }

        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("pack://application:,,,/Resources/33.png");
            var img = new BitmapImage(uri);
            image.Source = img;
        }

        private void btn_training_hide_Click(object sender, RoutedEventArgs e)
        {
            image.Source = null;
            btn_training.Visibility = Visibility.Visible;
            btn_training_hide.Visibility = Visibility.Collapsed;
            label_loading.Visibility = Visibility.Collapsed;
            btn_1.Visibility = Visibility.Collapsed;
            btn_2.Visibility = Visibility.Collapsed;
            btn_3.Visibility = Visibility.Collapsed;

        }

        public void hideMetrics()
        {
            cb_Berlinger.Visibility = Visibility.Collapsed;
            cb_Comments.Visibility = Visibility.Collapsed;
            cb_Holsted.Visibility = Visibility.Collapsed;
            cb_Jilb.Visibility = Visibility.Collapsed;
            cb_SLOC.Visibility = Visibility.Collapsed;
            cb_MakKeib.Visibility = Visibility.Collapsed;
            label_info.Visibility = Visibility.Collapsed;
            btn_check.Visibility = Visibility.Collapsed;
            btn_uncheck.Visibility = Visibility.Collapsed;
            // textBox_path.Visibility = Visibility.Collapsed;
            // btn_framework.Visibility = Visibility.Collapsed;
        }

        public void showMetrics()
        {
            cb_SLOC.Visibility = Visibility.Visible;
            cb_Comments.Visibility = Visibility.Visible;
            cb_MakKeib.Visibility = Visibility.Visible;
            cb_Jilb.Visibility = Visibility.Visible;
            cb_Holsted.Visibility = Visibility.Visible;
            cb_Berlinger.Visibility = Visibility.Visible;
            label_info.Visibility = Visibility.Visible;
            btn_check.Visibility = Visibility.Visible;
            btn_uncheck.Visibility = Visibility.Visible;

            // textBox_path.Visibility = Visibility.Visible;
            // btn_framework.Visibility = Visibility.Visible;
        }

        private void btn_openmenu_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Media.Animation.DoubleAnimation da = new System.Windows.Media.Animation.DoubleAnimation();
            da.From = rect_menu.Width - 200;
            da.To = 250;
            da.Duration = TimeSpan.FromSeconds(0.07);
            rect_menu.BeginAnimation(Rectangle.WidthProperty, da);
            /*--------------------------------------------------------*/
            btn_openmenu.Visibility = Visibility.Collapsed;
            btn_closemenu.Visibility = Visibility.Visible;
            btn_openfile_opened.Visibility = Visibility.Visible;
            btn_save_opened.Visibility = Visibility.Visible;
            btn_settings_open.Visibility = Visibility.Visible;
            btn_exit_opened.Visibility = Visibility.Visible;
            btn_openfolder_opened.Visibility = Visibility.Visible;
            btn_about_opened.Visibility = Visibility.Visible;
            textBox_name.Visibility = Visibility.Visible;
            rect_menu.Height = 568;
            /*--------------------------------------------------------*/
            if (btn_delete.Visibility == Visibility.Visible)
                btn_hideUI_Click(this, new RoutedEventArgs());
            btn_hideUI.IsEnabled = false;
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            var result = System.Windows.MessageBox.Show("Сохранить изменения?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                btn_save_opened_Click(this, new RoutedEventArgs());
            else if (result == MessageBoxResult.No)
                Close(); //зкрыть программу
        }

        private void Minimize_MouseDown(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; //свернуть
        }

        private void Rect_navigation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove(); //перетаскивание окна
        }

        private void btn_settings_Click(object sender, RoutedEventArgs e)
        {
            if (rect_menu.Height == 568 && rect_menu.Width == 250 || rect_menu.Width == 50)
            {
                textBox_settings.Text = "настройки";
                textBox_description.Visibility = Visibility.Collapsed;
                btn_apply.Visibility = Visibility.Visible;
                btn_training.Visibility = Visibility.Collapsed;
                btn_closeright.Visibility = Visibility.Visible;
                rect_settings.Visibility = Visibility.Visible;
                textBox_settings.Visibility = Visibility.Visible;
                if (rect_menu.Width == 250)
                {
                    btn_closemenu_Click(this, new RoutedEventArgs());
                }
                showMetrics();
            }
            else if (rect_settings.Height == 568 && rect_settings.Visibility == Visibility.Collapsed && rect_menu.Width == 50)
            {
                textBox_description.Visibility = Visibility.Collapsed;
                btn_apply.Visibility = Visibility.Visible;
                btn_closeright.Visibility = Visibility.Visible;
                rect_settings.Visibility = Visibility.Visible;
                btn_training.Visibility = Visibility.Visible;
                textBox_settings.Visibility = Visibility.Collapsed;
                textBox_settings.Text = "настройки";
                showMetrics();

            }

        }

        private void btn_about_Click(object sender, RoutedEventArgs e)
        {
            if (rect_menu.Height == 568 && rect_menu.Width == 250 || rect_menu.Width == 50)
            {
                textBox_settings.Text = "о программе";
                textBox_description.Visibility = Visibility.Visible;
                btn_apply.Visibility = Visibility.Visible;
                btn_closeright.Visibility = Visibility.Visible;
                rect_settings.Visibility = Visibility.Visible;
                btn_training.Visibility = Visibility.Visible;
                textBox_settings.Visibility = Visibility.Visible;
                if (rect_menu.Width == 250)
                {
                    btn_closemenu_Click(this, new RoutedEventArgs());
                }
                hideMetrics();
            }
            else if (rect_settings.Height == 568 && rect_settings.Visibility == Visibility.Collapsed && rect_menu.Width == 50)
            {
                textBox_description.Visibility = Visibility.Visible;
                btn_apply.Visibility = Visibility.Visible;
                btn_closeright.Visibility = Visibility.Visible;
                rect_settings.Visibility = Visibility.Visible;
                textBox_settings.Visibility = Visibility.Visible;
                btn_training.Visibility = Visibility.Visible;
                textBox_settings.Text = "о программе";
                hideMetrics();
            }


        }

        private void btn_apply_Click(object sender, RoutedEventArgs e)
        {
            if (rect_settings.Height == 568 && rect_settings.Width == 250 || rect_settings.Width == 50)
            {
                textBox_description.Visibility = Visibility.Collapsed;
                rect_settings.Visibility = Visibility.Collapsed;
                textBox_settings.Visibility = Visibility.Collapsed;
                btn_apply.Visibility = Visibility.Collapsed;
                btn_closeright.Visibility = Visibility.Collapsed;
                btn_training_hide.Visibility = Visibility.Collapsed;
                btn_training.Visibility = Visibility.Collapsed;
                hideMetrics();
            }

        }

        private void btn_closeright_Click(object sender, RoutedEventArgs e)
        {
            if (rect_settings.Height == 568 && rect_settings.Width == 250 || rect_settings.Width == 50)
            {

                textBox_description.Visibility = Visibility.Collapsed;
                rect_settings.Visibility = Visibility.Collapsed;
                textBox_settings.Visibility = Visibility.Collapsed;
                btn_apply.Visibility = Visibility.Collapsed;
                btn_closeright.Visibility = Visibility.Collapsed;
                btn_training_hide.Visibility = Visibility.Collapsed;
                btn_training.Visibility = Visibility.Collapsed;
                hideMetrics();
            }
        }

        private void btn_hideUI_Click(object sender, RoutedEventArgs e)
        {
            if (btn_delete.Visibility == Visibility.Visible && btn_count.Visibility == Visibility.Visible)
            {
                btn_delete.Visibility = Visibility.Collapsed;
                btn_count.Visibility = Visibility.Collapsed;
                btn_count.Visibility = Visibility.Collapsed;
                btn_count1.Visibility = Visibility.Collapsed;
                btn_deleteall.Visibility = Visibility.Collapsed;
            }
            else
            {
                btn_delete.Visibility = Visibility.Visible;
                btn_count.Visibility = Visibility.Visible;
                btn_count.Visibility = Visibility.Visible;
                btn_count1.Visibility = Visibility.Visible;
                btn_deleteall.Visibility = Visibility.Visible;
            }

        }

        private void btn_save_opened_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.Filter = "Текстовый файл (*.txt)|*.txt";
            bool? res = sfd.ShowDialog();
            if (res == true)
            {
                using (StreamWriter sw = new StreamWriter(sfd.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(label_codes.Text + "\n");
                    sw.Close();
                }
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (listBox_namelist.Items.Count >= 1)//&& listBox_namelist.SelectedIndex == listBox_namelist.Items.Count - 1)
            {
                // listBox_namelist.SelectedIndex++;
                // listBox_namelist.Items.RemoveAt(listBox_namelist.SelectedIndex - 1);
                try
                {
                    cs.Vars.Files.RemoveAt(listBox_namelist.SelectedIndex);
                    cs.Vars.ShortNameFiles.RemoveAt(listBox_namelist.SelectedIndex);
                    listBox_namelist.Items.RemoveAt(listBox_namelist.SelectedIndex);
                    label_codes.Text = "";
                }
                catch { System.Windows.MessageBox.Show("Не выбран файл для удаления"); }
            }

        }


        private void btn_deleteall_Click(object sender, RoutedEventArgs e)
        {

            if (listBox_namelist.Items.Count != 0)
                for (int i = 0; i < listBox_namelist.Items
                      .Count; i++)
                {
                    listBox_namelist.Items.RemoveAt(i);
                    //    cs.Vars.Files.RemoveAll(string path);
                }
            label_codes.Text = "";
            listBox_namelist.SelectedIndex = 0;
            btn_delete_Click(this, new RoutedEventArgs());
            cs.Vars.Files.Clear();
<<<<<<< HEAD
            cs.Vars.ShortNameFiles.Clear();
=======
>>>>>>> 41e307b6b8ba7726a0302919b40a6593bdb90acd
        }

        private void btn_check_Click(object sender, RoutedEventArgs e)
        {
            cb_Berlinger.IsChecked = true;
            cb_Holsted.IsChecked = true;
            cb_Jilb.IsChecked = true;
            cb_MakKeib.IsChecked = true;
            cb_SLOC.IsChecked = true;
            cb_Comments.IsChecked = true;
        }

        private void btn_uncheck_Click(object sender, RoutedEventArgs e)
        {
            cb_Berlinger.IsChecked = false;
            cb_Holsted.IsChecked = false;
            cb_Jilb.IsChecked = false;
            cb_MakKeib.IsChecked = false;
            cb_SLOC.IsChecked = false;
            cb_Comments.IsChecked = false;
        }

        private void btn_count_Click(object sender, RoutedEventArgs e)//Расчитать метрики
        {
            label_codes.Text = "";
            LoadingFiles(cs.Vars.Files);//загружаем файлы, там считаем метрики
        }

        private void btn_count1_Click(object sender, RoutedEventArgs e)
        {
            label_codes.Text = "";
            if (listBox_namelist.SelectedIndex!=-1)
                LoadingFiles(new List<string>() { cs.Vars.Files[listBox_namelist.SelectedIndex] });//загружаем файлы, там считаем метрики
        }

        //private void btn_framework_Click(object sender, RoutedEventArgs e)
        //{
        //    FolderBrowserDialog dlg = new FolderBrowserDialog();
        //    DialogResult result = dlg.ShowDialog();
        //    dlg.ShowNewFolderButton = false;
        //    if (System.Windows.Forms.DialogResult.OK == result)//если папка выбрана
        //    {
        //        textBox_path.Text = dlg.SelectedPath;
        //    }
        //    Settings.Default["fwork"] = textBox_path.Text;
        //    Settings.Default.Save();
        //    textBox_path.Text = Settings.Default["fwork"].ToString();
        //}

        //РАБОТА С ФАЙЛОВОЙ СИСТЕМОЙ.........................................................................................................
        /// <summary>
        /// Доавление файлов 
        /// </summary>
        List<string> paths = new List<string>();
        private void btn_openfile_Click(object sender, RoutedEventArgs e)//кнопка открыть файлы (ПОКА ТОЛЬКО cs-ники)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "C# source (.cs)|*.cs";
            //лист путей к файлам
            dlg.Multiselect = true;//можно выбрать много файлов
            bool? res = dlg.ShowDialog();//вызываем окно открытия

            if (res == true)//если файлы выбраны
            {
                for (int i = 0; i < dlg.FileNames.Length; i++)
                {
                    if (dlg.FileNames[i].Length < 4 || (dlg.FileNames[i].Length > 3 && (dlg.FileNames[i][dlg.FileNames[i].Length - 1] != 's' || dlg.FileNames[i][dlg.FileNames[i].Length - 2] != 'c' || dlg.FileNames[i][dlg.FileNames[i].Length - 3] != '.')))
                    {
                        cs.Vars.Files.Clear();
                        cs.Vars.ShortNameFiles.Clear();
                        paths.Clear();
                        //Бросить исключение "Недопустимое имя файла"     
                    }

                    cs.Vars.Files.Add(dlg.FileNames[i]);
                    cs.Vars.ShortNameFiles.Add(cs.Vars.GetFileName(dlg.FileNames[i]));
                    listBox_namelist.Items.Add(cs.Vars.GetFileName(dlg.FileNames[i])); //добавляем вкладки
                    paths.Add(dlg.FileNames[i]);//добавляем модули к листу
                }

                //LoadingFiles(cs.Vars.Files);//загружаем каждый файл

                if (rect_settings.Height == 568 && rect_settings.Width == 250 && rect_menu.Width == 250)
                {
                    btn_closeright_Click(this, new RoutedEventArgs());
                    btn_closemenu_Click(this, new RoutedEventArgs());
                    btn_hideUI_Click(this, new RoutedEventArgs());

                }
            }

        }
        private void btn_openfolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            DialogResult result = dlg.ShowDialog();
            dlg.ShowNewFolderButton = false;
            if (System.Windows.Forms.DialogResult.OK == result)//если папка выбрана
            {
                foreach (string currentFile in System.IO.Directory.GetFiles(dlg.SelectedPath, "*.cs", SearchOption.AllDirectories))
                {
                    cs.Vars.Files.Add(currentFile);
                    cs.Vars.ShortNameFiles.Add(cs.Vars.GetFileName(currentFile));
                    listBox_namelist.Items.Add(cs.Vars.GetFileName(currentFile)); //добавляем вкладки
                    paths.Add(currentFile);//добавляем модули к листу        
                }
                LoadingFiles(paths);//загружаем каждый файл
                if (rect_settings.Height == 568 && rect_settings.Width == 250 && rect_menu.Width == 250)
                {
                    btn_closeright_Click(this, new RoutedEventArgs());
                    btn_closemenu_Click(this, new RoutedEventArgs());
                    btn_hideUI_Click(this, new RoutedEventArgs());
                    if (rect_menu.Width == 50 && btn_count.Visibility == Visibility.Collapsed)
                        btn_hideUI_Click(this, new RoutedEventArgs());

                }
            }
        }

        private void listBox_namelist_SelectionChanged(object sender, SelectionChangedEventArgs e)//выбор файла
        {
            label_codes.Text = "Код модуля:\n";
            try
            {
                if (listBox_namelist.Items.Count != 0)
                {
                    FileStream fs = new FileStream(cs.Vars.Files[listBox_namelist.SelectedIndex], FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    while (!sr.EndOfStream)
                    {
                        label_codes.Text += sr.ReadLine() + "\n";
                    }
                    sr.Close();
                    fs.Close();
                }
            }
            catch
            {
                label_codes.Text = " ";
                listBox_namelist.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Функция обработки файлов
        /// </summary>
        /// <param name="Files"></param>
        private void LoadingFiles(List<string> Files)
        {
            if ((cb_Berlinger.IsChecked == false && cb_Holsted.IsChecked == false && cb_Jilb.IsChecked == false && cb_Comments.IsChecked == false
<<<<<<< HEAD
                && cb_MakKeib.IsChecked == false && cb_SLOC.IsChecked == false) || Files.Count == 0)//если метрики не выбраны
=======
                && cb_MakKeib.IsChecked == false && cb_SLOC.IsChecked == false) || cs.Vars.Files.Count == 0)//если метрики не выбраны
>>>>>>> 41e307b6b8ba7726a0302919b40a6593bdb90acd
            {
                System.Windows.MessageBox.Show("Пожалуйста, добавьте файлы и/или выберите метрику");
                btn_settings_Click(this, new RoutedEventArgs());
                if (rect_settings.Visibility == Visibility.Collapsed)
                    btn_settings_Click(this, new RoutedEventArgs());
                if (rect_menu.Width == 50 && btn_count.Visibility == Visibility.Collapsed)
                    btn_hideUI_Click(this, new RoutedEventArgs());
            }
            else
            {
                if (rect_menu.Width == 50 && btn_count.Visibility == Visibility.Collapsed)
                    btn_hideUI_Click(this, new RoutedEventArgs());
                if (cb_Berlinger.IsChecked == true)//если выбран Берлингер
                {
                    double BerlingersResult = cs.BerlingerMetric.CalculationBerlingerMetric(Files);//значение метрики Берлингера
                    label_codes.Text = "\n" + "Мера Берлингера (чем ближе к -6.5, тем лучше): " + BerlingersResult.ToString() + "\n" + label_codes.Text;
                }
                if (cb_Holsted.IsChecked == true)//если выбран Холстед
                {
<<<<<<< HEAD
                    double[] HolstedsResults = cs.HolstedMetrics.СalculationHolstedsMetrics(Files);//значение метрик Холстеда
                    label_codes.Text = "Уровень языка выражения (больше - лучше): " + HolstedsResults[5].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Трудоёмкость кодирования (меньше - лучше): " + HolstedsResults[4].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Cложность понимания программы (меньше - лучше): " + HolstedsResults[3].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Уровень качества программирования (больше - лучше): " + HolstedsResults[2].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Объём программы (меньше - лучше): " + HolstedsResults[1].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Длина программы (меньше - лучше): " + HolstedsResults[0].ToString() + "\n" + label_codes.Text;
=======
                    double[] HolstedsResults = cs.HolstedMetrics.СalculationHolstedsMetrics(cs.Vars.Files);//значение метрик Холстеда
                    label_codes.Text = "Уровень языка выражения: " + HolstedsResults[5].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Трудоёмкость кодирования: " + HolstedsResults[4].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Cложность понимания программы: " + HolstedsResults[3].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Уровень качества программирования: " + HolstedsResults[2].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Объём программы: " + HolstedsResults[1].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Длина программы: " + HolstedsResults[0].ToString() + "\n" + label_codes.Text;
>>>>>>> 41e307b6b8ba7726a0302919b40a6593bdb90acd
                    label_codes.Text = "\n" + "Метрики Холстеда:" + "\n" + label_codes.Text;
                }
                if (cb_Jilb.IsChecked == true)
                {
<<<<<<< HEAD
                    double[] JilbResults = cs.JilbMetrics.CalculationJilbMetrics(Files);//значение метрик Холстеда
                    label_codes.Text = "Средняя глубина вложенности (меньше - лучше): " + JilbResults[3].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Максимальная глубина вложенности (меньше - лучше): " + JilbResults[2].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Количество операторов цикла (меньше - лучше): " + JilbResults[1].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Количество условных операторов (меньше - лучше): " + JilbResults[0].ToString() + "\n" + label_codes.Text;
=======
                    double[] JilbResults = cs.JilbMetrics.CalculationJilbMetrics(cs.Vars.Files);//значение метрик Холстеда
                    label_codes.Text = "Средняя глубина вложенности: " + JilbResults[3].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Максимальная глубина вложенности: " + JilbResults[2].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Количество операторов цикла: " + JilbResults[1].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Количество условных операторов: " + JilbResults[0].ToString() + "\n" + label_codes.Text;
>>>>>>> 41e307b6b8ba7726a0302919b40a6593bdb90acd
                    label_codes.Text = "\n" + "Метрики Джилба:" + "\n" + label_codes.Text;
                }
                if (cb_MakKeib.IsChecked == true)//если выбран Мак-Кейб
                {
<<<<<<< HEAD
                    double McCabeResult = cs.McCabeMetric.CalculationMcCabeMetric(Files);//значение метрики Мак-Кейба
                    label_codes.Text = "\n" + "Цикломатическое число Мак-Кейба (от 0 до 20 хорошо, больше - хуже): " + McCabeResult.ToString() + "\n" + label_codes.Text;
                }
                if (cb_SLOC.IsChecked == true)//если выбран SLOC
                {
                    double[] SLOCResults = cs.SLOC.CalculationSLOCMetric(Files);//значение метрик SLOC
                    label_codes.Text = "Количество логических строк (меньше - лучше): " + SLOCResults[1].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Количество физических строк (меньше - лучше): " + SLOCResults[0].ToString() + "\n" + label_codes.Text;
=======
                    double McCabeResult = cs.McCabeMetric.CalculationMcCabeMetric(cs.Vars.Files);//значение метрики Мак-Кейба
                    label_codes.Text = "\n" + "Цикломатическое число Мак-Кейба: " + McCabeResult.ToString() + "\n" + label_codes.Text;
                }
                if (cb_SLOC.IsChecked == true)//если выбран SLOC
                {
                    double[] SLOCResults = cs.SLOC.CalculationSLOCMetric(cs.Vars.Files);//значение метрик SLOC
                    label_codes.Text = "Количество логических строк: " + SLOCResults[1].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Количество физических строк: " + SLOCResults[0].ToString() + "\n" + label_codes.Text;
>>>>>>> 41e307b6b8ba7726a0302919b40a6593bdb90acd
                    label_codes.Text = "\n" + "SLOC (метрики оценки величины программы):" + "\n" + label_codes.Text;
                }
                if (cb_Comments.IsChecked == true)//если выбраны метрики комментариев
                {
<<<<<<< HEAD
                    double[] CommentResults = cs.Comments.CalculationCommentsMetric(Files);//значение метрик Холстеда
                    label_codes.Text = "Относительное количество комментариев (как правило, больше - лучше): " + CommentResults[1].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Абсолютное количество комментариев (как правило, больше - лучше): " + CommentResults[0].ToString() + "\n" + label_codes.Text;
=======
                    double[] CommentResults = cs.Comments.CalculationCommentsMetric(cs.Vars.Files);//значение метрик Холстеда
                    label_codes.Text = "Относительное количество комментариев: " + CommentResults[1].ToString() + "\n" + label_codes.Text;
                    label_codes.Text = "Абсолютное количество комментариев: " + CommentResults[0].ToString() + "\n" + label_codes.Text;
>>>>>>> 41e307b6b8ba7726a0302919b40a6593bdb90acd
                    label_codes.Text = "\n" + "Метрики оценки комментирования программы:" + "\n" + label_codes.Text;
                }
            }
        }
    }
}

