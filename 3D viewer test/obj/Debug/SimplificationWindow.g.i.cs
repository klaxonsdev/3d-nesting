#pragma checksum "..\..\SimplificationWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B8391546D72AF30053FA13C1BD7BD8F379F63BCB"
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
using _3D_viewer;


namespace _3D_viewer
{


    /// <summary>
    /// SimplificationWindow
    /// </summary>
    public partial class SimplificationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 26 "..\..\SimplificationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenFilebtn;

#line default
#line hidden


#line 27 "..\..\SimplificationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Countbox;

#line default
#line hidden


#line 28 "..\..\SimplificationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TriangleLabel;

#line default
#line hidden


#line 29 "..\..\SimplificationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Reducerbtn;

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
            System.Uri resourceLocater = new System.Uri("/3D viewer test;component/simplificationwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\SimplificationWindow.xaml"
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
                    this.OpenFilebtn = ((System.Windows.Controls.Button)(target));

#line 26 "..\..\SimplificationWindow.xaml"
                    this.OpenFilebtn.Click += new System.Windows.RoutedEventHandler(this.OpenFilebtn_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.Countbox = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 3:
                    this.TriangleLabel = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 4:
                    this.Reducerbtn = ((System.Windows.Controls.Button)(target));

#line 29 "..\..\SimplificationWindow.xaml"
                    this.Reducerbtn.Click += new System.Windows.RoutedEventHandler(this.Reducerbtn_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.Trianglesum = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.TriangleScroll = ((System.Windows.Controls.Primitives.ScrollBar)(target));

#line 31 "..\..\SimplificationWindow.xaml"
                    this.TriangleScroll.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.TriangleScroll_ValueChanged);

#line default
#line hidden

#line 31 "..\..\SimplificationWindow.xaml"
                    this.TriangleScroll.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.TriangleScroll_MouseLeftButtonUp);

#line default
#line hidden

#line 31 "..\..\SimplificationWindow.xaml"
                    this.TriangleScroll.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TriangleScroll_MouseLeftButtonDown);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox TrianglesumBox;
    }
}

