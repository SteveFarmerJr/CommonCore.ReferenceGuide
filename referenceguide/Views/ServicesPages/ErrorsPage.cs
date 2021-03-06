﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.CommonCore;

namespace referenceguide
{
    public class ErrorsPageCell:ViewCell
    {
		public ErrorsPageCell()
		{
            var lbl = new Label()
            {
                Margin = 5
            };
            lbl.SetBinding(Label.TextProperty, "ErrorType");

            View = new StackContainer(true)
            {
                Children = { lbl }
            };
           
		}
    }

    public class ErrorsPage : CorePage<DataExampleViewModel>
    {
        public ErrorsPage()
        {
            this.Title = "App Errors";

            var lst = new CoreListView()
            {
                ItemTemplate = new DataTemplate(typeof(ErrorsPageCell)),
                ItemClickCommand= new Command((obj) => {
                    var log = (ErrorLog)obj;
                    VM.DialogPrompt.ShowMessage(new Prompt()
                    {
                        Title = "Error",
                        Message = log.ErrorMessage
                    });
                })
            };
            lst.SetBinding(CoreListView.ItemsSourceProperty, "ErrorLogs");

			var btnAdd = new CoreButton()
			{
				Text = "Add",
                Style = CoreStyles.LightOrange,
                AutomationId = "btnAdd",
			};
			btnAdd.SetBinding(CoreButton.CommandProperty, "CreateErrorEntry");

            var btnClear = new CoreButton()
            {
                Text = "Clear",
                Style = CoreStyles.LightOrange,
                AutomationId = "btnClear"
            };
            btnClear.SetBinding(CoreButton.CommandProperty,"ClearErrorEntries");
           
            Content = new StackContainer(true)
            {
                Padding = 20,
                Spacing = 10,
                Children = { lst ,btnAdd, btnClear }
            };
      
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
            VM.OnViewMessageReceived(CoreSettings.LoadResources, null);
		}
    }
}
