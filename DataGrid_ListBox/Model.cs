using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace DataGrid_ListBox.Model
{
    class Column_t : INotifyPropertyChanged
    {
        private ObservableCollection<Cell_t> _ocCell;
        public ObservableCollection<Cell_t> ocCells
        {
            get { return _ocCell; }
            set
            {
                if (_ocCell != value)
                {
                    this._ocCell = value;
                    RaisePropertyChanged("ocCells");
                }
            }
        }
        public Column_t(int row, int column, int setColumn, double[][] model)
        {
            var oc = new ObservableCollection<Cell_t>();
            for (int i = 0; i < row; i++)
            {
                oc.Add(new Cell_t(i, setColumn, model));
            }
            this.ocCells = oc;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    class Cell_t : INotifyPropertyChanged
    {
        internal int Column = 0;
        internal int Row = 0;
        private double[][] modelValue;
        public Cell_t(int row, int column, double[][] modelValue)
        {
            this.Row = row;
            this.Column = column;
            this.modelValue = modelValue;
        }
        public string TextContent
        {
            get { return modelValue[Row][Column].ToString(); }
            set
            {
                if (double.TryParse(value, out double d))
                {
                    if (d != modelValue[Row][Column])
                    {
                        modelValue[Row][Column] = d;
                        RaisePropertyChanged("TextContent");
                        Console.WriteLine("row:{0}, column:{1}, value:{2}", Row, Column, d);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
