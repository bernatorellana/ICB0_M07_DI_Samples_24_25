﻿#pragma checksum "C:\Users\Usuari\Desktop\Mila\M07\ICB0_M07_DI_Samples_24_25\UF1\20241204_DB\DBDemo\DBDemo\View\PaginationControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "45C5758FF2CC2F5C4A5B07EE094BB7AF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBDemo.View
{
    partial class PaginationControl : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBox_Text(global::Windows.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class PaginationControl_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IPaginationControl_Bindings
        {
            private global::DBDemo.View.PaginationControl dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBox obj3;
            private global::Windows.UI.Xaml.Controls.TextBlock obj4;

            private PaginationControl_obj1_BindingsTracking bindingsTracking;

            public PaginationControl_obj1_Bindings()
            {
                this.bindingsTracking = new PaginationControl_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3: // View\PaginationControl.xaml line 18
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_3(this.obj3);
                        break;
                    case 4: // View\PaginationControl.xaml line 26
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            // IPaginationControl_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::DBDemo.View.PaginationControl)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::DBDemo.View.PaginationControl obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_CurrentPage(obj.CurrentPage, phase);
                        this.Update_MaxPage(obj.MaxPage, phase);
                    }
                }
            }
            private void Update_CurrentPage(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // View\PaginationControl.xaml line 18
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj3, obj.ToString(), null);
                }
            }
            private void Update_MaxPage(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // View\PaginationControl.xaml line 26
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj4, obj.ToString(), null);
                }
            }
            private void UpdateTwoWay_3_Text()
            {
                if (this.initialized)
                {
                    this.dataRoot.CurrentPage = (global::System.Int32) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Int32), this.obj3.Text);
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class PaginationControl_obj1_BindingsTracking
            {
                private global::System.WeakReference<PaginationControl_obj1_Bindings> weakRefToBindingObj; 

                public PaginationControl_obj1_BindingsTracking(PaginationControl_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<PaginationControl_obj1_Bindings>(obj);
                }

                public PaginationControl_obj1_Bindings TryGetBindingObject()
                {
                    PaginationControl_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                }

                public void DependencyPropertyChanged_CurrentPage(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    PaginationControl_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::DBDemo.View.PaginationControl obj = sender as global::DBDemo.View.PaginationControl;
                        if (obj != null)
                        {
                            bindings.Update_CurrentPage(obj.CurrentPage, DATA_CHANGED);
                        }
                    }
                }
                public void DependencyPropertyChanged_MaxPage(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    PaginationControl_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::DBDemo.View.PaginationControl obj = sender as global::DBDemo.View.PaginationControl;
                        if (obj != null)
                        {
                            bindings.Update_MaxPage(obj.MaxPage, DATA_CHANGED);
                        }
                    }
                }
                private long tokenDPC_CurrentPage = 0;
                private long tokenDPC_MaxPage = 0;
                public void UpdateChildListeners_(global::DBDemo.View.PaginationControl obj)
                {
                    PaginationControl_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::DBDemo.View.PaginationControl.CurrentPageProperty, tokenDPC_CurrentPage);
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::DBDemo.View.PaginationControl.MaxPageProperty, tokenDPC_MaxPage);
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            tokenDPC_CurrentPage = obj.RegisterPropertyChangedCallback(global::DBDemo.View.PaginationControl.CurrentPageProperty, DependencyPropertyChanged_CurrentPage);
                            tokenDPC_MaxPage = obj.RegisterPropertyChangedCallback(global::DBDemo.View.PaginationControl.MaxPageProperty, DependencyPropertyChanged_MaxPage);
                        }
                    }
                }
                public void RegisterTwoWayListener_3(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.TextBox.TextProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_3_Text();
                        }
                    });
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\PaginationControl.xaml line 10
                {
                    this.PreviousPageButton = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.PreviousPageButton).Click += this.PreviousPageButton_Click;
                }
                break;
            case 3: // View\PaginationControl.xaml line 18
                {
                    global::Windows.UI.Xaml.Controls.TextBox element3 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)element3).TextChanged += this.TextBox_TextChanged;
                }
                break;
            case 5: // View\PaginationControl.xaml line 29
                {
                    this.NextPageButton = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.NextPageButton).Click += this.NextPageButton_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // View\PaginationControl.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.UserControl element1 = (global::Windows.UI.Xaml.Controls.UserControl)target;
                    PaginationControl_obj1_Bindings bindings = new PaginationControl_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}
