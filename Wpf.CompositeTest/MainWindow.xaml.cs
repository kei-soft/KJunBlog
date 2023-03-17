using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

using Wpf.CompositeTest.Models;

namespace Wpf.CompositeTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CompositeCollection compositeCollection = new CompositeCollection();

        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<InboundMessage> inboundMessages = new ObservableCollection<InboundMessage>();

            inboundMessages.Add(new InboundMessage { MessageId = 1, Message = "오늘 약속 장소는", ReceivedTime = new DateTime(2023, 12, 10, 12, 50, 12).ToString("yyyy-MM-dd HH:mm:ss") });
            inboundMessages.Add(new InboundMessage { MessageId = 2, Message = "강남역 10번 출구야", ReceivedTime = new DateTime(2023, 12, 10, 12, 50, 15).ToString("yyyy-MM-dd HH:mm:ss") });

            ObservableCollection<OutboundMessage> outboundMessages = new ObservableCollection<OutboundMessage>();

            outboundMessages.Add(new OutboundMessage { MessageId = 1, Message = "그래 알았어", SentTime = new DateTime(2023, 12, 10, 12, 51, 30).ToString("yyyy-MM-dd HH:mm:ss") });
            outboundMessages.Add(new OutboundMessage { MessageId = 2, Message = "몇 시쯤 볼까?", SentTime = new DateTime(2023, 12, 10, 12, 51, 45).ToString("yyyy-MM-dd HH:mm:ss") });

            this.compositeCollection.Add(new CollectionContainer() { Collection = inboundMessages });
            this.compositeCollection.Add(new CollectionContainer() { Collection = outboundMessages });
            ;
            this.compositeCollection.Add(new InboundMessage { MessageId = 1, Message = "7시", ReceivedTime = new DateTime(2023, 12, 10, 12, 53, 02).ToString("yyyy-MM-dd HH:mm:ss") });
            this.compositeCollection.Add(new OutboundMessage { MessageId = 1, Message = "ㅇㅇ", SentTime = new DateTime(2023, 12, 10, 12, 54, 55).ToString("yyyy-MM-dd HH:mm:ss") });

            conversationList.ItemsSource = compositeCollection;
        }
    }
}
