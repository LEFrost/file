using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace file
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const string filename = "storage";
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            IO(b, filename);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            IO(b, filename);
        }

        async void IO(Button b, string name)
        {
                StorageFolder fold = ApplicationData.Current.LocalFolder;
            if (b.Content.ToString() == "储存")
            {
                StorageFile file = await fold.CreateFileAsync(name, CreationCollisionOption.OpenIfExists);
                await FileIO.WriteTextAsync(file, input.Text);
            }
            else if(b.Content.ToString()=="显示")
            {
                StorageFile file = await fold.GetFileAsync(name);
                output.Text= await FileIO.ReadTextAsync(file);
            }
        }

    }
}
