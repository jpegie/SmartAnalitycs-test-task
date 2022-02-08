using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_manager.Data
{
    internal abstract class FieldPattern<T>
    {
        public abstract string Title
        { get; set; }
        public abstract Type DataType
        { get; set; }
        public abstract T Data
        { get; set; }

    }
    internal class IntField : FieldPattern<int>
    { 
        public IntField()
        {
            DataType = typeof(int);
            Title = "";
            Data = int.MaxValue;
        }
        override public string Title
        { get; set; }
        override public Type DataType
        { get; set; }
        override public int Data
        {get;set; }
    }
    internal class FloatField : FieldPattern<float>
    {
        public FloatField()
        {
            DataType = typeof(float);
            Title = "";
            Data = 6.66f;
        }
        override public string Title
        { get; set; }
        override public Type DataType
        { get; set; }
        override public float Data
        { get; set; }
    }
    internal class StringField : FieldPattern<string>
    {
        public StringField()
        {
            DataType = typeof(string);
            Title = "";
            Data = "empty data";
        }
        override public string Title
        { get; set; }
        override public Type DataType
        { get; set; }
        override public string Data
        { get; set; }
    }
    internal class DateTimeField : FieldPattern<DateTime>
    {
        public DateTimeField()
        { 
            DataType = typeof(DateTime);
            Title = "";
            Data = DateTime.Now;
        }
        override public string Title
        { get; set; }
        override public Type DataType
        { get; set; }
        override public DateTime Data
        { get; set; }
    }
}
