using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DataGrid_ListBox.Model;
namespace DataGrid_ListBox.ViewModel
{
    class ViewModel_t
    {
        private ObservableCollection<Column_t> _ocColumn;
        public ObservableCollection<Column_t> ocColumn
        {
            get { return _ocColumn; }
            private set
            {
                if (_ocColumn != value)
                    this._ocColumn = value;
            }
        }
        private ObservableCollection<string> _ocRowHeader;
        public ObservableCollection<string> ocRowHeader
        {
            get { return _ocRowHeader; }
            private set
            {
                if (_ocRowHeader != value)
                {
                    _ocRowHeader = value;
                }
            }
        }
        public ViewModel_t()
        {
            int row = 5;
            int column = 10;

            var strs = (from i in Enumerable.Range(0, row+1)
                        select "Row " + i).ToList();
            this.ocRowHeader = new ObservableCollection<string>(strs);
            double[][] modelValue = new double[row][];
            for (int i = 0; i < row; i++)
            {
                modelValue[i] = new double[column];
                for (int j = 0; j < column; j++)
                {
                    modelValue[i][j] = i * 100 + j;
                }
            }
            var oc = new ObservableCollection<Column_t>();
            for (int i = 0; i < column; i++)
            {
                oc.Add(new Column_t(row, column, i, modelValue));
            }
            this.ocColumn = oc;
        }

    }

}
