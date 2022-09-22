using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

using DevExpress.Mvvm;

namespace Wpf.DevGridTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private ObservableCollection<ItemModel> items;

        public ObservableCollection<ItemModel> Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new ObservableCollection<ItemModel>();
                }

                return this.items;
            }
            set
            {
                this.items = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<ItemModel> selectItems;

        public ObservableCollection<ItemModel> SelectItems
        {
            get
            {
                if (this.selectItems == null)
                {
                    this.selectItems = new ObservableCollection<ItemModel>();
                }

                return this.selectItems;
            }
            set
            {
                this.selectItems = value;
                OnPropertyChanged();
            }
        }

        private ItemModel currentItem;

        public ItemModel CurrentItem
        {
            get
            {
                return this.currentItem;
            }
            set
            {
                this.currentItem = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> dynamicitems;

        public ObservableCollection<object> Dynamicitems
        {
            get
            {
                if (this.dynamicitems == null)
                {
                    this.dynamicitems = new ObservableCollection<object>();
                }

                return this.dynamicitems;
            }
            set
            {
                this.dynamicitems = value;
                OnPropertyChanged();
            }
        }

        private DateTime fromDate;

        public DateTime FromDate
        {
            get => this.fromDate;
            set
            {
                this.fromDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime toDate;

        public DateTime ToDate
        {
            get => this.toDate;
            set
            {
                this.toDate = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// 새 리드그룹 추가 커맨드
        /// </summary>
        public ICommand CurrentChangedCommand
        {
            get
            {
                if (currentChangedCommand == null)
                {
                    currentChangedCommand = new DelegateCommand<ItemModel>((p) => OnCurrentChangedCommand(p));
                }
                return currentChangedCommand;
            }
        }


        private IDelegateCommand currentChangedCommand;

        public MainViewModel()
        {
            // Cell Color
            this.Items.Add(new ItemModel() { CellColor = new SolidColorBrush(System.Windows.Media.Colors.Blue), Name = "홍길동", Age = 45 });
            this.Items.Add(new ItemModel() { CellColor = new SolidColorBrush(System.Windows.Media.Colors.Yellow), Name = "유관순", Age = 57 });
            this.Items.Add(new ItemModel() { CellColor = new SolidColorBrush(System.Windows.Media.Colors.Green), Name = "이순신", Age = 60 });
            this.Items.Add(new ItemModel() { CellColor = new SolidColorBrush(System.Windows.Media.Colors.Red), Name = "강감찬", Age = 22 });
            this.Items.Add(new ItemModel() { CellColor = new SolidColorBrush(System.Windows.Media.Colors.Purple), Name = "윤봉길", Age = 15 });

            // DateEdit
            FromDate = DateTime.Now.AddDays(-10);
            ToDate = DateTime.Now;

            // ExpanoObject
            List<(int ID, string NAME)> datas = new List<(int, string)>() { (1, "A"), (2, "B"), (3, "C") };

            foreach (var data in datas)
            {
                dynamic expando = new ExpandoObject();

                AddProperty(expando, "ID", data.ID);
                AddProperty(expando, "Name", data.NAME);

                Dynamicitems.Add(expando);
            }
        }

        private void OnCurrentChangedCommand(ItemModel changeItem)
        {
            if (SelectItems.Contains(changeItem))
            {
                SelectItems.Remove(changeItem);
            }
            else
            {
                SelectItems.Add(changeItem);
            }
        }

        private void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            var expandoDic = expando as IDictionary<string, object>;

            if (expandoDic.ContainsKey(propertyName))
            {
                expandoDic[propertyName] = propertyValue;
            }
            else
            {
                expandoDic.Add(propertyName, propertyValue);
            }
        }
    }
}