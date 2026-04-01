namespace GatelockVanLite.Views.Components
{
    public partial class InputField : ContentView
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(InputField), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(InputField), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty ErrorTextProperty =
            BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(InputField), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty ShowErrorProperty =
            BindableProperty.Create(nameof(ShowError), typeof(bool), typeof(InputField), default(bool), BindingMode.TwoWay);

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(InputField), Keyboard.Default, BindingMode.TwoWay);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public string ErrorText
        {
            get => (string)GetValue(ErrorTextProperty);
            set => SetValue(ErrorTextProperty, value);
        }

        public bool ShowError
        {
            get => (bool)GetValue(ShowErrorProperty);
            set => SetValue(ShowErrorProperty, value);
        }

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        public InputField()
        {
            InitializeComponent();
        }
    }
}
