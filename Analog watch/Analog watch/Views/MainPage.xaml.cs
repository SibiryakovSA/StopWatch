using System.ComponentModel;
using Xamarin.Forms;

namespace Analog_watch
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //класс - отображение
        //содержит логику отображения (визуальные эл-ты, их создание, стили и тд)
        //не содержит логику работы и информацию о презентере и модели
        //использует relative layout и grid layout для подобия адаптивного дизайна

        Grid grid;
        Image clockFace;
        Image clockSecondsHand;
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

        public string SecondsLable
        {
            get
            {
                return seconds.Text;
            }
            set
            {
                seconds.Text = value;
            }
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

            clockFace = new Image
            {
                Source = "ClockFaceWithoutHands2.png"
            };

            clockSecondsHand = new Image
            {
                Source = "ClockSecondsHand3.png"
            };

            start = new Button
            {
                Text = "Старт",
                Margin = new Thickness(5, 10, 10, 15),
                BackgroundColor = Color.FromHex("#00CB00"),
                TextColor = Color.White,
                FontSize = 25,
                CornerRadius = 50
            };

            stop = new Button
            {
                Text = "Пауза",
                IsEnabled = false,
                Margin = new Thickness(10, 10, 5, 15),
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                FontSize = 25,
                CornerRadius = 50
            };

            seconds = new Label
            {
                Text = "00:00:00",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 33),
                TextColor = Color.White,
                FontSize = 60
            };

            grid.Children.Add(clockFace, 0, 0);
            Grid.SetColumnSpan(clockFace, 2);
            grid.Children.Add(clockSecondsHand, 0, 0);
            Grid.SetColumnSpan(clockSecondsHand, 2);

            grid.Children.Add(seconds, 0, 1);
            Grid.SetColumnSpan(seconds, 2);
            grid.Children.Add(stop, 0, 2);
            grid.Children.Add(start, 1, 2);

            this.grid = grid;

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
