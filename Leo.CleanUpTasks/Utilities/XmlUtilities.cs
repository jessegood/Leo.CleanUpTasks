namespace Leo.CleanUpTasks.Utilities
{
    using Models;
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Xml.Serialization;

    public static class XmlUtilities
    {
        public static ConversionItemList Deserialize(string openPath)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(openPath));
            Contract.Ensures(Contract.Result<ConversionItemList>() != null);

            XmlSerializer deserializer = new XmlSerializer(typeof(ConversionItemList));

            using (TextReader reader = new StreamReader(openPath))
            {
                object obj = deserializer.Deserialize(reader);
                return (ConversionItemList)obj;
            }
        }

        public static void Serialize(ConversionItemList list, string savePath)
        {
            Contract.Requires<ArgumentNullException>(list != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(savePath));
            Contract.Requires<ArgumentException>(list.Items.Count > 0);

            XmlSerializer serializer = new XmlSerializer(typeof(ConversionItemList));

            using (TextWriter writer = new StreamWriter(savePath))
            {
                serializer.Serialize(writer, list);
            }
        }
    }
}