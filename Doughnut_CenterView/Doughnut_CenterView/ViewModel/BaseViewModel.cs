﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Doughnut_CenterView
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GridModel> ItemSource { get; set; }

        public ObservableCollection<DataModel> MonthlyExpenses { get; set; }
        public ObservableCollection<View> CustomViews { get; set; }

        public ObservableCollection<Color> CustomColors { get; set; }

        private ContentView content;
        public ContentView ContentView
        {
            get { return content; }
            set
            {
                content = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ContentView"));
            }
        }

        public BaseViewModel()
        {
            CustomViews = new ObservableCollection<View>();
            string fontfamily = "FontAwesome5Pro-Regular";
            if (Device.RuntimePlatform == Device.Android)
            {
                fontfamily = "FontAwesome.otf#FontAwesome5Pro-Regular";
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                fontfamily = "/Assets/FontAwesome.otf#FontAwesome5Pro-Regular";
            }

            Image photo = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };

            Image video = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            Image doc = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            photo.Source = new FontImageSource()
            {
                FontFamily = fontfamily,
                // Glyph = "\uf03e",
                Glyph = "\uf09d",
                Size = 20,
                Color = Color.White,
            };

            video.Source = new FontImageSource()
            {
                FontFamily = fontfamily,
                Glyph = "\uf149",
                //Glyph = "\uf03d",
                Size = 20,
                Color = Color.Red,
            };

            doc.Source = new FontImageSource()
            {
                FontFamily = fontfamily,
                Glyph = "\uf001",
                Size = 25,
                Color = Color.Accent,
            };

            var stack_1 = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 0, Padding = 0 };
            Label l1 = new Label() { Text = "Expense Analysis", FontSize = 15, FontAttributes = FontAttributes.Bold, TextColor = Color.White, HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.StartAndExpand };
            stack_1.Children.Add(photo);
            stack_1.Children.Add(l1);
            Label l2 = new Label() { Text = "Decrease", FontSize = 15, FontAttributes = FontAttributes.Bold, TextColor = Color.Red, HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center };
            var stack_2 = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 0, Padding = 0 };
            stack_2.Children.Add(video);
            stack_2.Children.Add(l2);
            CustomViews.Add(stack_1);
            // CustomViews.Add(stack_2);

            CustomColors = new ObservableCollection<Color>()
            {
                Color.FromHex("#DE8565"),
                Color.FromHex("#148083"),
                Color.FromHex("#544763"),
                Color.FromHex("#D07574"),
                Color.FromHex("#EEB462"),
            };

            ItemSource = new ObservableCollection<GridModel>()
            {
                new GridModel(){GridColumn=0, GridRow=0},
                new GridModel(){GridColumn=0, GridRow=0},
                new GridModel(){GridColumn=0, GridRow=0},
                new GridModel(){GridColumn=0, GridRow=1},
                new GridModel(){GridColumn=0, GridRow=1},
                new GridModel(){GridColumn=0, GridRow=1},
                new GridModel(){GridColumn=0, GridRow=2},
                new GridModel(){GridColumn=0, GridRow=2},
                new GridModel(){GridColumn=0, GridRow=2},
                new GridModel(){GridColumn=0, GridRow=3},
                new GridModel(){GridColumn=0, GridRow=3},
                new GridModel(){GridColumn=0, GridRow=3},
            };

            MonthlyExpenses = new ObservableCollection<DataModel>()
            {
                new DataModel(){XData = "Books", YData=90},
                new DataModel(){XData = "Housing", YData= 120},
                new DataModel(){XData = "Mobile", YData=40},
                new DataModel(){XData = "Food", YData=55},
                new DataModel(){XData = "Others", YData=155},
            };
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
