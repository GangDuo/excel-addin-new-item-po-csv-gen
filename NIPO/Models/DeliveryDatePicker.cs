
using System;
using System.ComponentModel.DataAnnotations;

namespace NIPO.Models
{
    public class DeliveryDatePicker
    {
        [Display(Name = "納期", Description = "重複を排除した納期。", Order = 1)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        [UIHint("Calendar")]
        public DateTime? Value { get; private set; }

        [Display(Name = "有効", Description = "チェック済みをCSV生成対象にする。", Order = 2)]
        [UIHint("CheckBox")]
        public bool IsEnabled { get; set; }

        public DeliveryDatePicker(DateTime? value, bool isEnabled)
        {
            Value = value;
            this.IsEnabled = isEnabled;
        }
    }
}
