﻿#pragma checksum "D:\Users\Desk\Face++SDK for windows phone silverlight 8.1\FaceCpp\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DFA9641D641D4B97236BB11A4783DED3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace FaceCpp {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image image1;
        
        internal System.Windows.Controls.Canvas canvas1;
        
        internal System.Windows.Controls.TextBlock label1;
        
        internal System.Windows.Controls.TextBlock label2;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/FaceCpp;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.image1 = ((System.Windows.Controls.Image)(this.FindName("image1")));
            this.canvas1 = ((System.Windows.Controls.Canvas)(this.FindName("canvas1")));
            this.label1 = ((System.Windows.Controls.TextBlock)(this.FindName("label1")));
            this.label2 = ((System.Windows.Controls.TextBlock)(this.FindName("label2")));
        }
    }
}

