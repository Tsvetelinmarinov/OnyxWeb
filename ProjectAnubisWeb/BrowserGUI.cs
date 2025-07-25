﻿/// <summary>
///   The Graphical User Interface (GUI) of the application
/// </summary> 

using Microsoft.Web.WebView2.WinForms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAnubisWeb
{
    /// <summary>
    ///  Simple web browser
    /// </summary>
    internal class BrowserGUI : Form
    { 
        // Default home page of the browser
        private static readonly Uri defaultPage = new("https://www.google.com/");

        /// <summary>
        ///  The bowser has five different base buttons: Back, Forward, Home, Refresh and Search
        ///  They will be repesented as objects of type PictureBox for better visualization of the Images on them
        /// </summary> 
        private readonly PictureBox? goBackButton;
        private readonly PictureBox? goForwardButton;
        private readonly PictureBox? refreshButton;
        private readonly PictureBox? goHomeButton;
        private readonly PictureBox? searchButton;
        
        // The text box used to enter the URL adress in
        private readonly TextBox? searchBox = new();

        //The engine of the web browser: An object of type WebView2 - The Micosoft Edge WebView2 engine
        private readonly WebView2? engine = new();


        /// <summary>
        ///  Get the default home page URL
        /// </summary>
        public static Uri DefaultPage
        {
            get => defaultPage;           
        }


#pragma warning disable CS4014
        /// <summary>
        ///  Create new instace of the browser
        /// </summary>
        public BrowserGUI()
            => Build();
#pragma warning restore CS4014


        /// <summary>
        ///  Builds the interface
        /// </summary>
        /// <returns></returns>
        private async Task Build()
        {          
            ComponentLoader.SetWinProperties(this);
            ComponentLoader.SetWebEngine(this, engine);
            ComponentLoader.SetSearchBox(this, searchBox, engine!);
            await ComponentLoader.SetBaseButtons(
                this,
                [goBackButton, goForwardButton, refreshButton, goHomeButton, searchButton],
                engine,
                searchBox
            );
            ComponentLoader.SetAppearanceButton(this, searchBox!, engine!);
            ComponentLoader.SetHistoryButton(this, engine!);
            ComponentLoader.SetTabPanel(this);

            engine!.CoreWebView2.Navigate(defaultPage.ToString());
        }
    }
}
