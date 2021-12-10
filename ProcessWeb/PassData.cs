using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessWeb
{
    public class PassData
    {
        private int _number;
        public int increment
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                NotifyDataChanged();
            }
        }
        public Employee emp { get; set; }



        public event Action OnChange;

        private void NotifyDataChanged() => OnChange?.Invoke();
    }
}
