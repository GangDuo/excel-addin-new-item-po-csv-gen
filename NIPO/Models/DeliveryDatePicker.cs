
namespace NIPO.Models
{
    public class DeliveryDatePicker
    {
        public string Value { get; private set; }
        public bool IsEnabled { get; set; }

        public DeliveryDatePicker(string value, bool isEnabled)
        {
            Value = value;
            this.IsEnabled = isEnabled;
        }
    }
}
