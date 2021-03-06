﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.CommonCore;

namespace referenceguide
{
    public class SimpleObect
    {
        public string Text { get; set; }
    }
    public class SimpleCell:ViewCell
    {
        public SimpleCell()
        {
            var lbl = new Label()
            {
                Margin=10
            };
            lbl.SetBinding(Label.TextProperty,"Text");

            View = new StackContainer(true)
            {
                Children = { lbl }
            };
        }
    }
    public class ListViewEffect: BasePages
    {
        public ListViewEffect(bool hideSeparators = false)
        {
            var lst = new List<SimpleObect>();
            lst.Add(new SimpleObect(){Text="Test 1"});
            lst.Add(new SimpleObect() { Text = "Test 2" });
            lst.Add(new SimpleObect() { Text = "Test 3" });
            lst.Add(new SimpleObect() { Text = "Test 4" });

            var lstView = new ListView(ListViewCachingStrategy.RecycleElement)
            {
                ItemTemplate = new DataTemplate(typeof(SimpleCell)),
                ItemsSource = lst
            };
#if __IOS__
            lstView.Effects.Add(new RemoveEmptyRowsEffect());
#endif


			if(hideSeparators)
                lstView.Effects.Add(new HideListSeparatorEffect());

            Content = new StackContainer(true)
            {
                Children = { lstView }
            };

        }

        protected override void OnAppearing()
        {
            this.SetAnalyticsTimeStamp();
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {

            this.SaveAnalyticsDetails();
            base.OnDisappearing();
        }
    }
}
