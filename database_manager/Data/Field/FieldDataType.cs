using System.Runtime.Serialization;

enum FieldDataType
{
    [EnumMember(Value = "Int")]
    Int,
    [EnumMember(Value = "Float")]
    Float,
    [EnumMember(Value = "String")]
    String,
    [EnumMember(Value = "DateTime")]
    DateTime
}