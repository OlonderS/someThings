﻿#pragma checksum "..\..\PoWybraniuStolika.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D5E92D764262EE298B904587D6C05EE8084B998FA4F0732B52800DED22257DC1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp2;


namespace WpfApp2 {
    
    
    /// <summary>
    /// PoWybraniuStolika
    /// </summary>
    public partial class PoWybraniuStolika : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\PoWybraniuStolika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NazwaModeluBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\PoWybraniuStolika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CenaBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\PoWybraniuStolika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WysokoscBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\PoWybraniuStolika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SzerokoscBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\PoWybraniuStolika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GlebokoscBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\PoWybraniuStolika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboKsztalt;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\PoWybraniuStolika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxProducenci;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\PoWybraniuStolika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxMaterialy;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/powybraniustolika.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PoWybraniuStolika.xaml"
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
            this.NazwaModeluBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.CenaBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.WysokoscBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.SzerokoscBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.GlebokoscBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ComboKsztalt = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\PoWybraniuStolika.xaml"
            this.ComboKsztalt.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboMaterac_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ComboBoxProducenci = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            
            #line 35 "..\..\PoWybraniuStolika.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ComboBoxMaterialy = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
