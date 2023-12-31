﻿#pragma checksum "..\..\..\Pages\CatalogPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BF292658C3F71D4DE4763FCA19C3999FF7AC106B691F516092DE3AC80031C60E"
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
    /// CatalogPage
    /// </summary>
    public partial class CatalogPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxSearch;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxBookGenre;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxPublishingHouse;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxAuthor;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboSort;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockCount;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockBasketInfo;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBasket;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Pages\CatalogPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxBooks;
        
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
            System.Uri resourceLocater = new System.Uri("/BookStoreApp;component/pages/catalogpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\CatalogPage.xaml"
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
            
            #line 10 "..\..\..\Pages\CatalogPage.xaml"
            ((BookStoreApp.Pages.CatalogPage)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TBoxSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\Pages\CatalogPage.xaml"
            this.TBoxSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TBoxSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ComboBoxBookGenre = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\Pages\CatalogPage.xaml"
            this.ComboBoxBookGenre.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxBookGenre_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ComboBoxPublishingHouse = ((System.Windows.Controls.ComboBox)(target));
            
            #line 39 "..\..\..\Pages\CatalogPage.xaml"
            this.ComboBoxPublishingHouse.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxPublishingHouse_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ComboBoxAuthor = ((System.Windows.Controls.ComboBox)(target));
            
            #line 44 "..\..\..\Pages\CatalogPage.xaml"
            this.ComboBoxAuthor.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxAuthor_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ComboSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 63 "..\..\..\Pages\CatalogPage.xaml"
            this.ComboSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboSort_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBlockCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.TextBlockBasketInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.BtnBasket = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\Pages\CatalogPage.xaml"
            this.BtnBasket.Click += new System.Windows.RoutedEventHandler(this.BtnBasket_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ListBoxBooks = ((System.Windows.Controls.ListBox)(target));
            
            #line 78 "..\..\..\Pages\CatalogPage.xaml"
            this.ListBoxBooks.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxProducts_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 111 "..\..\..\Pages\CatalogPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

