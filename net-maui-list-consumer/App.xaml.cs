﻿namespace net_maui_list_consumer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                Application.Current.UserAppTheme = AppTheme.Light;
                if (DeviceInfo.Current.Platform == DevicePlatform.Android)
                {
                    return base.CreateWindow(activationState);
                }
                else if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
                {
                    return base.CreateWindow(activationState);
                }
                else
                {
                    var window = base.CreateWindow(activationState);
                    window.Width = 720;
                    window.Height = 1280;

                    // give it some time to complete window resizing task.
                    window.Dispatcher.DispatchAsync(() => { }).GetAwaiter().OnCompleted(() =>
                    {
                        var disp = DeviceDisplay.Current.MainDisplayInfo;
                        window.X = (disp.Width / disp.Density - window.Width) / 2;
                        window.Y = (disp.Height / disp.Density - window.Height) / 2;
                    });
                    return window;
                }
            }
            else
            {
                return base.CreateWindow(activationState);
            }
        }
    }
}