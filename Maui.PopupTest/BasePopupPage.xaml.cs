using System.Windows.Input;

namespace Maui.PopupTest;

public partial class BasePopupPage : ContentPage
{
	public BasePopupPage()
	{
		InitializeComponent();

        this.BindingContext = this;
	}

    /// <summary>
    /// �˾��� �ݽ��ϴ�.
    /// </summary>
    public ICommand PopModelCommand => new Command(async () =>
    {
        await App.Current.MainPage.Navigation.PopModalAsync();
    });

    /// <summary>
    /// �˾��� ������������ ǥ�õ� View
    /// </summary>
    public View PopupContent
    {
        get => (View)GetValue(PopupContentProperty);
        set { SetValue(PopupContentProperty, value); }
    }

    public static readonly BindableProperty PopupContentProperty = BindableProperty.Create(
      propertyName: nameof(PopupContent),
      returnType: typeof(View),
      declaringType: typeof(BasePopupPage),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay,
      propertyChanged: PopupContentPropertyChanged);

    private static void PopupContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (BasePopupPage)bindable;

        if (newValue != null)
        {
            controls.ContentView.Content = (View)newValue;
        }
    }
}