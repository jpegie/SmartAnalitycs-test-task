using System.Windows;
using System.Windows.Controls;

namespace database_manager.Data
{
    internal class TypeSelector : DataTemplateSelector
    {
        public DataTemplate TextBoxTemplate
        { get; set; }
        public DataTemplate DateTimeTemplate
        { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FieldBase columnData = item as FieldBase;
            if (columnData.UiType == UiFieldType.TextBox)
            {
                return TextBoxTemplate;
            }
            else if (columnData.UiType == UiFieldType.DateTime)
            {
                return DateTimeTemplate;
            }
            else
            {
                return base.SelectTemplate(item, container);
            }
        }
    }
}
