﻿using System.Windows;
using Captura.Models;
using Captura.ViewModels;
using Screna;

namespace Captura
{
    public partial class WebCamWindow
    {
        WebCamWindow()
        {
            InitializeComponent();
            
            Closing += (S, E) =>
            {
                Hide();

                E.Cancel = true;
            };
        }

        public static WebCamWindow Instance { get; } = new WebCamWindow();

        public WebcamControl GetWebCamControl() => WebCameraControl;

        void CloseButton_Click(object Sender, RoutedEventArgs E) => Close();
        
        async void CaptureImage_OnClick(object Sender, RoutedEventArgs E)
        {
            try
            {
                var img = ServiceProvider.Get<WebcamModel>().WebcamCapture?.Capture(GraphicsBitmapLoader.Instance);

                await ServiceProvider.Get<ScreenShotModel>().SaveScreenShot(img);
            }
            catch { }
        }
    }
}