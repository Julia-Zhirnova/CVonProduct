﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace УМК_Цифра.Controls
{
    /// <summary>
    /// Логика взаимодействия для cZone.xaml
    /// </summary>
    public partial class c3Zone : Page
    {
        public c3Zone()
        {
            InitializeComponent();
            webBrowser.Navigated += (sender, args) => { HideScriptErrors((WebBrowser)sender, true); };
            webBrowser.Navigate("https://forms.yandex.ru/cloud/644ffb2943f74f2ff93a3dbf/");
        }

        public void HideScriptErrors(WebBrowser wb, bool Hide)
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            object objComWebBrowser = fiComWebBrowser.GetValue(wb);
            if (objComWebBrowser == null) return;
            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
        }
    
    }
}
