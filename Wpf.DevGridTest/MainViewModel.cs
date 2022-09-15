using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace Wpf.DevGridTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private ObservableCollection<ItemModel> items;

        public ObservableCollection<ItemModel> Items
        {
            get => this.items;
            set
            {
                this.items = value;
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

        public MainViewModel()
        {
            // Cell Color - 확인필요
            items = new ObservableCollection<ItemModel>();
            items.Add(new ItemModel() { CellColor = new System.Drawing.SolidBrush(Color.Blue), Name = "홍길동", Age = 45 });
            items.Add(new ItemModel() { CellColor = new System.Drawing.SolidBrush(Color.Yellow), Name = "유관순", Age = 57 });
            items.Add(new ItemModel() { CellColor = new System.Drawing.SolidBrush(Color.Green), Name = "이순신", Age = 60 });
            items.Add(new ItemModel() { CellColor = new System.Drawing.SolidBrush(Color.Red), Name = "강감찬", Age = 22 });
            items.Add(new ItemModel() { CellColor = new System.Drawing.SolidBrush(Color.Purple), Name = "윤봉길", Age = 15 });

            this.Items = items;

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
