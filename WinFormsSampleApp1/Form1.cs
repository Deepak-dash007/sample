using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace WinFormsSampleApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var sendButton = new Button()
            {
                Text = "Send",
                AutoSize = true,
            };
            sendButton.Click += SendButton_Click;
            this.Controls.Add(sendButton);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            try 
            {
                // Construct the visuals of the toast (using Notifications library)
                ToastContent toastContent = new ToastContentBuilder()
                    .AddToastActivationInfo("", ToastActivationType.Protocol)
                    .AddText("Hello world!")
                    .GetToastContent();

                // And create the toast notification
                var toast = new ToastNotification(toastContent.GetXml());

                Debug.WriteLine(toastContent.GetContent());
                // And then show it
                DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);
            }
            catch(Exception exception)
            {
                Debug.WriteLine("Send to debug output.");
                Debug.WriteLine(exception.ToString());
            }
        }
    }
}
