using System;
using System.Windows;
using System.Windows.Controls;

namespace Wpf.CompositeTest.Controls
{
    /// <summary>
    /// InboundMessageBubble.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InboundMessageBubble : UserControl
    {
        public InboundMessageBubble()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TextMessageProperty = DependencyProperty.Register("TextMessage", typeof(string), typeof(InboundMessageBubble), new UIPropertyMetadata(string.Empty));
        public string TextMessage
        {
            get { return (string)GetValue(TextMessageProperty); }
            set { SetValue(TextMessageProperty, value); }
        }

        public static readonly DependencyProperty TimeStampProperty = DependencyProperty.Register("TimeStamp", typeof(string), typeof(InboundMessageBubble), new UIPropertyMetadata(string.Empty));
        public string TimeStamp
        {
            get { return (string)GetValue(TimeStampProperty); }
            set { SetValue(TimeStampProperty, value); }
        }

        public static readonly DependencyProperty InboundMessageBubbleFontSizeProperty = DependencyProperty.Register("InboundMessageBubbleFontSize", typeof(string), typeof(InboundMessageBubble), new PropertyMetadata("", InboundMessageBubbleFontSizeChanged));

        public string InboundMessageBubbleFontSize
        {
            get { return (string)GetValue(InboundMessageBubbleFontSizeProperty); }
            set
            {
                SetValue(InboundMessageBubbleFontSizeProperty, value);
            }
        }

        private static void InboundMessageBubbleFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InboundMessageBubble instance)
            {
                instance.lblTimeStamp.Height = (Convert.ToDouble(instance.InboundMessageBubbleFontSize) / 3) + 4;
                instance.lblTimeStamp.FontSize = (Convert.ToDouble(instance.InboundMessageBubbleFontSize) / 3) + 2;
            }
        }
    }
}
