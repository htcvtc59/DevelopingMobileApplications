﻿#pragma checksum "C:\Users\MacOS\Documents\Visual Studio 2015\Projects\SqlLiteWinPhone\SqlLiteWinPhone\UpdateDelete.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "312AEBE16E4EC74F5BB235315079AC5F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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


namespace SqlLiteWinPhone {
    
    
    public partial class UpdateDelete : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock textBlock;
        
        internal System.Windows.Controls.TextBlock tb;
        
        internal System.Windows.Controls.TextBox txtName;
        
        internal System.Windows.Controls.TextBox txtPhone;
        
        internal System.Windows.Controls.Button btnUpdate;
        
        internal System.Windows.Controls.Button btnDelete;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/SqlLiteWinPhone;component/UpdateDelete.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.textBlock = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock")));
            this.tb = ((System.Windows.Controls.TextBlock)(this.FindName("tb")));
            this.txtName = ((System.Windows.Controls.TextBox)(this.FindName("txtName")));
            this.txtPhone = ((System.Windows.Controls.TextBox)(this.FindName("txtPhone")));
            this.btnUpdate = ((System.Windows.Controls.Button)(this.FindName("btnUpdate")));
            this.btnDelete = ((System.Windows.Controls.Button)(this.FindName("btnDelete")));
        }
    }
}

