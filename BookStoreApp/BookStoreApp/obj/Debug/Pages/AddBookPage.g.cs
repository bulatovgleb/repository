﻿#pragma checksum "..\..\..\Pages\AddBookPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D5B7DC67219974BF0314884412492024FACDFA810D914D23722CA579129C0A26"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BookStoreApp.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BookStoreApp.Pages {
    
    
    /// <summary>
    /// AddBookPage
    /// </summary>
    public partial class AddBookPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxBookName;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxBookDescription;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBookGenre;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBookProvider;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboPublishingHouse;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboAuthor;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxBookISBN;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxBookCount;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxBookPrice;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSave;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImagePhoto;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\Pages\AddBookPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLoad;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BookStoreApp;component/pages/addbookpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AddBookPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBoxBookName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextBoxBookDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ComboBookGenre = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.ComboBookProvider = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.ComboPublishingHouse = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ComboAuthor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.TextBoxBookISBN = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TextBoxBookCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.TextBoxBookPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.BtnSave = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\Pages\AddBookPage.xaml"
            this.BtnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ImagePhoto = ((System.Windows.Controls.Image)(target));
            return;
            case 12:
            this.BtnLoad = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\Pages\AddBookPage.xaml"
            this.BtnLoad.Click += new System.Windows.RoutedEventHandler(this.BtnLoad_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

