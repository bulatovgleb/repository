﻿#pragma checksum "..\..\..\Pages\AddClientPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "66A919C838EE92570C894099FD2E162BC5C51035DBAD0B2980B454F97A056C78"
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
    /// AddClientPage
    /// </summary>
    public partial class AddClientPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\Pages\AddClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxClientLogin;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\AddClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxClientPassword;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\AddClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxClientSurname;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\AddClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxClientName;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Pages\AddClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxClientPatronymic;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\AddClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxClientAddress;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\AddClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxClientPhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Pages\AddClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxRole;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Pages\AddClientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/BookStoreApp;component/pages/addclientpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AddClientPage.xaml"
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
            this.TextBoxClientLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextBoxClientPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBoxClientSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxClientName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TextBoxClientPatronymic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TextBoxClientAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TextBoxClientPhoneNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ComboBoxRole = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.BtnSave = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\Pages\AddClientPage.xaml"
            this.BtnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

