using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows;

namespace Airports.TestWpf.Infrastructure.Behaviors
{
    public class WindowCloseIEnabledBehavior 
    {
        private static readonly Type OwnerType = typeof(WindowBehavior);

        #region EnableCloseButton (attached property)

        public static readonly DependencyProperty EnableCloseButtonProperty =
            DependencyProperty.RegisterAttached(
                "EnableCloseButton",
                typeof(bool),
                OwnerType,
                new FrameworkPropertyMetadata(false, EnableCloseButtonChangedCallback));

        [AttachedPropertyBrowsableForType(typeof(Window))]
        public static bool GetEnableCloseButton(Window obj)
        {
            return (bool)obj.GetValue(EnableCloseButtonProperty);
        }

        [AttachedPropertyBrowsableForType(typeof(Window))]
        public static void SetEnableCloseButton(Window obj, bool value)
        {
            obj.SetValue(EnableCloseButtonProperty, value);
        }

        private static void EnableCloseButtonChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window == null) return;

            var enableCloseButton = (bool)e.NewValue;
            if (enableCloseButton && !GetIsEnabledCloseButton(window))
            {
                if (!window.IsLoaded)
                {
                    window.Loaded += EnableWhenLoadedDelegate;
                }
                else
                {
                    EnableCloseButton(window);
                }
                SetIsEnabledCloseButton(window, true);
            }
            else if (!enableCloseButton && GetIsEnabledCloseButton(window))
            {
                if (!window.IsLoaded)
                {
                    window.Loaded -= ShowWhenLoadedDelegate;
                }
                else
                {
                    ShowCloseButton(window);
                }
                SetIsEnabledCloseButton(window, false);
            }
        }

        #region Win32 imports


        const uint MF_GRAYED = 0x00000001;
        const uint MF_ENABLED = 0x00000000;
        const uint SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        #endregion

        private static readonly RoutedEventHandler EnableWhenLoadedDelegate = (sender, args) =>
        {
            if (sender is Window == false) return;
            var w = (Window)sender;
            EnableCloseButton(w);
            w.Loaded -= EnableWhenLoadedDelegate;
        };

        private static readonly RoutedEventHandler ShowWhenLoadedDelegate = (sender, args) =>
        {
            if (sender is Window == false) return;
            var w = (Window)sender;
            EnableCloseButton(w);
            w.Loaded -= ShowWhenLoadedDelegate;
        };

        private static void EnableCloseButton(Window w)
        {
            var hwnd = new WindowInteropHelper(w).Handle;
            IntPtr hMenu = GetSystemMenu(hwnd, false);
            EnableMenuItem(hMenu, SC_CLOSE, MF_GRAYED);
            //SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private static void ShowCloseButton(Window w)
        {
            var hwnd = new WindowInteropHelper(w).Handle;
            IntPtr hMenu = GetSystemMenu(hwnd, false);
            EnableMenuItem(hMenu, SC_CLOSE, MF_ENABLED);
           // SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) | WS_SYSMENU);
        }

        #endregion

        #region IsEnabledCloseButton (readonly attached property)

        private static readonly DependencyPropertyKey IsEnabledCloseButtonKey =
            DependencyProperty.RegisterAttachedReadOnly(
                "IsEnabledCloseButton",
                typeof(bool),
                OwnerType,
                new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty IsEnabledCloseButtonProperty =
            IsEnabledCloseButtonKey.DependencyProperty;

        [AttachedPropertyBrowsableForType(typeof(Window))]
        public static bool GetIsEnabledCloseButton(Window obj)
        {
            return (bool)obj.GetValue(IsEnabledCloseButtonProperty);
        }

        private static void SetIsEnabledCloseButton(Window obj, bool value)
        {
            obj.SetValue(IsEnabledCloseButtonKey, value);
        }

        #endregion

    }
}
