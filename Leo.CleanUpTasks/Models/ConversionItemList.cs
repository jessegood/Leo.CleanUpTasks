namespace Leo.CleanUpTasks.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Utilities;

    [XmlRoot("ConversionItems")]
    public class ConversionItemList
    {
        [XmlArray("Items"), XmlArrayItem(typeof(ConversionItem), ElementName = "Item")]
        public List<ConversionItem> Items { get; set; } = new List<ConversionItem>();
    }
}