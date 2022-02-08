using database_manager.Data;
using System;
using System.Collections.Generic;

interface IField
{
    //int Index { get; set; }
    //bool IsKey { get; set; }
    string Title { get; set; }
    FieldDataType DataType { get; set; }
    object Data { get; set; }
}
interface IIntField : IField
{
    new int Data { get; set; }
}
interface IFloatField : IField
{
    new float Data { get; set; }
}
interface IStringField : IField
{
    new string Data { get; set; }
}
interface IDateTimeField : IField
{
    new DateTime Data { get; set; }
}

interface ITable
{
    string Title { get; set; }
    List<Item> Columns { get; set; }
    string KeyColumnTitle { get; set; }
    bool AddItem(Item item);
    bool RemoveColumnByTitle(string columnTitle);
    bool RemoveItemByKeyField(IField keyField);
    bool AddColumn(Item column);

}