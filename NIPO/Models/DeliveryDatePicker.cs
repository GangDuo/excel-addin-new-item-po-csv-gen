
using System;

namespace NIPO.Models
{
    public class DeliveryDatePicker
    {
        public DateTime? Value { get; private set; }
        public bool IsEnabled { get; set; }

        public DeliveryDatePicker(DateTime? value, bool isEnabled)
        {
            Value = value;
            this.IsEnabled = isEnabled;
        }
    }
}
