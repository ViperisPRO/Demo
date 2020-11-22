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
    /// Логика взаимодействия для StroyMaterialPage.xaml
    /// </summary>
    public partial class StroyMaterialPage : Page
    {
        public List<StroyMaterial> MyStroyMaterials { get; set; }

        public StroyMaterialPage(List<StroyMaterial> materials)
        {
            InitializeComponent();
            MyStroyMaterials = materials;
            this.DataContext = this;
        }
    }
}
