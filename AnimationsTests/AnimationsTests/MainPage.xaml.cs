using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Xamanimation;

using Xamarin.Forms;

namespace AnimationsTests
{
    public partial class MainPage : BaseModel
    {
        private string _isDeviceOnline;

        public string Color
        {
            get => _isDeviceOnline;
            set => SetProperty(ref _isDeviceOnline, value);
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Color = "#1DD813";

            //await BadgeIcon.Animate(new RotateToAnimation() { Rotation = -90, Duration = "500", RepeatForever = false, Delay = 0 });

            var animations = new List<AnimationBase>
            {
                 new RotateToAnimation() { Rotation = -60, Duration = "100", RepeatForever = false, Delay = 0 },
                new RotateToAnimation() { Rotation = 0, Duration = "100", RepeatForever = false, Delay = 0 },
                new RotateToAnimation() { Rotation = 60, Duration = "100", RepeatForever = false, Delay = 0 },
                  new RotateToAnimation() { Rotation = 0, Duration = "100", RepeatForever = false, Delay = 0 },
            };

            await BadgeIcon.Animate(new StoryBoard(animations) { Delay = 3000, Duration = "400", RepeatForever = true });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Color = "#C0C0C0";
            //await OnlineStatusBox2.Animate(new Xamanimation.ScaleToAnimation() { Delay = 200, Duration = "1500", Scale = 2, Easing = Xamanimation.EasingType.SinIn });

            //OnlineStatusBox2.Animate(new Xamanimation.TranslateToAnimation() { Delay = 0, Duration = "1000", TranslateX = -Width / 2, TranslateY = -Height / 2, Easing = Xamanimation.EasingType.SinOut });
            //await OnlineStatusBox2.Animate(new Xamanimation.ScaleToAnimation() { Delay = 0, Duration = "1200", Scale = 0, Easing = Xamanimation.EasingType.SinOut });
            await GetAnimation(0, 0);
        }

        private async Task GetAnimation(double x, double y)
        {

            //AbsoluteLayout.SetLayoutBounds(SelectedExercise, new Rectangle(x, y, 0.2, 0.2));
            //AbsoluteLayout.SetLayoutFlags(SelectedExercise, AbsoluteLayoutFlags.All);

            await OnlineStatusBox2.Animate(new ScaleToAnimation() { Delay = 200, Duration = "1500", Scale = 2, Easing = EasingType.SinIn });
            _ = OnlineStatusBox2.Animate(new TranslateToAnimation() { Delay = 0, Duration = "1000", TranslateX = -Width / 2, TranslateY = -Height / 2, Easing = EasingType.SinOut });
            await OnlineStatusBox2.Animate(new ScaleToAnimation() { Delay = 0, Duration = "1200", Scale = 0, Easing = EasingType.SinOut });
            _ = OnlineStatusBox2.Animate(new TranslateToAnimation() { Delay = 0, TranslateX = 0, TranslateY = 0 });
            _ = OnlineStatusBox2.Animate(new ScaleToAnimation() { Delay = 0, Scale = 1 });

        }

    }

    public class BaseModel : ContentPage, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
