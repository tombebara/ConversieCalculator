// Updated by XamlIntelliSenseFileGenerator 6/30/2022 8:21:37 PM
#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2110AAA79442A1E14EFDE233D519B6F8FABF353BDAE5AB9CABB92C7F3EECD8BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace Conversiecalculator
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl Main;

#line default
#line hidden


#line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem TiMoney;

#line default
#line hidden


#line 58 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ConversionResult;

#line default
#line hidden


#line 86 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserInputValue;

#line default
#line hidden


#line 93 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbFromValue;

#line default
#line hidden


#line 97 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SwapCmbValues;

#line default
#line hidden


#line 104 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbToValue;

#line default
#line hidden


#line 119 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Convert;

#line default
#line hidden


#line 127 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetConversion;

#line default
#line hidden


#line 139 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem TiBinary;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Conversiecalculator;component/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\MainWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.Main = ((System.Windows.Controls.TabControl)(target));
                    return;
                case 2:
                    this.TiMoney = ((System.Windows.Controls.TabItem)(target));
                    return;
                case 3:
                    this.lightOrDark = ((System.Windows.Controls.Button)(target));
                    return;
                case 4:
                    this.ConversionResult = ((System.Windows.Controls.Label)(target));
                    return;
                case 5:
                    this.UserInputValue = ((System.Windows.Controls.TextBox)(target));

#line 90 "..\..\MainWindow.xaml"
                    this.UserInputValue.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumbersOnly);

#line default
#line hidden
                    return;
                case 6:
                    this.CmbFromValue = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 7:
                    this.SwapCmbValues = ((System.Windows.Controls.Button)(target));

#line 100 "..\..\MainWindow.xaml"
                    this.SwapCmbValues.Click += new System.Windows.RoutedEventHandler(this.SwapCmbValues_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.CmbToValue = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 9:
                    this.ConversionHistory = ((System.Windows.Controls.Button)(target));
                    return;
                case 10:
                    this.Convert = ((System.Windows.Controls.Button)(target));

#line 126 "..\..\MainWindow.xaml"
                    this.Convert.Click += new System.Windows.RoutedEventHandler(this.ConvertInput_Click);

#line default
#line hidden
                    return;
                case 11:
                    this.ResetConversion = ((System.Windows.Controls.Button)(target));

#line 134 "..\..\MainWindow.xaml"
                    this.ResetConversion.Click += new System.Windows.RoutedEventHandler(this.ResetConversion_Click);

#line default
#line hidden
                    return;
                case 12:
                    this.TiBinary = ((System.Windows.Controls.TabItem)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TabItem TiHistory;
        internal System.Windows.Controls.Button LightOrDark;
        internal System.Windows.Controls.Button LightOrDarkTwo;
    }
}

