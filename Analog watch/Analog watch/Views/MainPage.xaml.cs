using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Analog_watch
{
    
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Grid grid;
        Image clockFace;
        Image clockSecondsHand;
        Image clockMinutesHand;
        Label seconds;
        Button start;
        Button stop;

        public Button GetStartButton
        {
            get
            {
                return start;
            }
        }

        public Button GetStopButton
        {
            get
            {
                return stop;
            }
        }

        public Image GetClockSecondsHand
        {
            get
            {
                return clockSecondsHand;
            }
        }

        public Image GetClockMinutesHand
        {
            get
            {
                return clockMinutesHand;
            }
        }

        public void SetTimeLable(int secondsLeft)
        {
            string seconds = secondsLeft % 60 < 10 ? "0" + (secondsLeft % 60).ToString() : (secondsLeft % 60).ToString();
            string minutes = secondsLeft % 3600 / 60 < 10 ? "0" + (secondsLeft % 3600 / 60).ToString() : (secondsLeft % 3600 / 60).ToString();
            string hours = secondsLeft / 3600 < 10 ? "0" + (secondsLeft / 3600).ToString() : (secondsLeft / 3600).ToString();;
            this.seconds.Text = String.Format(" {0}:{1}:{2} ", hours, minutes, seconds);
        }

        void Init()
        {
            Grid grid = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            clockFace = new Image {Source = "ClockFaceWithoutHands2.png"};
            clockSecondsHand = new Image { Source = "ClockSecondsHand2.png" };
            clockMinutesHand = new Image { Source = "ClockMinutsHand2.png" };
            start = new Button { Text = "Старт" };
            stop = new Button { Text = "Пауза", IsEnabled = false };
            seconds = new Label { Text = " 00:00:00 ", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 24 , BackgroundColor = Color.White};

            grid.Children.Add(clockFace, 0, 0);
            Grid.SetColumnSpan(clockFace, 2);
            grid.Children.Add(clockMinutesHand, 0, 0);
            Grid.SetColumnSpan(clockMinutesHand, 2);
            grid.Children.Add(clockSecondsHand, 0, 0);
            Grid.SetColumnSpan(clockSecondsHand, 2);

            grid.Children.Add(seconds, 0, 1);
            Grid.SetColumnSpan(seconds, 2);
            grid.Children.Add(stop, 0, 2);
            grid.Children.Add(start, 1, 2);

            this.grid = grid;
            //Content = grid;         


            relativeLayout.Children.Add(grid, 
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));
        }


        public MainPage()
        {
            InitializeComponent();
            Init();
        }
    }
}
