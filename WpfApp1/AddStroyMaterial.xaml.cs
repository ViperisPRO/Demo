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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddStroyMaterial.xaml
    /// </summary>
    public partial class AddStroyMaterial : Page
    {
        //public List<Sklad> SkladList { get; set; }
        public AddStroyMaterial(StroyMaterial sm)
            {
               InitializeComponent();
                this.CurrentStroyMaterial = new StroyMaterial();
                this.DataContext = this;
            //this.SkladList = Core.DB.Sklad.ToList();
        }

        public StroyMaterial CurrentStroyMaterial { get; set; }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //if (CurrentStroyMaterial.Num == 0)
            Core.DB.StroyMaterial.Add(CurrentStroyMaterial);
            Core.DB.SaveChanges();
        }

    }
}
