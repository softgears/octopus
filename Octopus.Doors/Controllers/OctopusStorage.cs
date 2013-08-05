// ============================================================
// 
// 	Octopus
// 	Octopus.Doors 
// 	OctopusStorage.cs
// 
// 	Created by: ykorshev 
// 	 at 29.07.2013 12:09
// 
// ============================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Octopus.Doors.Controllers
{
    /// <summary>
    /// Класс для сохранения данных в XML формате
    /// </summary>
    public class OctopusStorage
    {
        /// <summary>
        /// Массив данных в памяти
        /// </summary>
        public Dictionary<string, string> KeyValues { get; private set; }

        /// <summary>
        /// Сохраняет данные на Диск в XML формате
        /// </summary>
        public void SaveData()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "storage.xml");
            var storageElement = new XElement("Storage");
            var xDocument = new XDocument(new XDeclaration("1.0", "utf-8", "true"), storageElement);
            foreach (var pair in KeyValues)
            {
                storageElement.Add(new XElement(pair.Key)
                {
                    Value = pair.Value
                });
            }
            xDocument.Save(path);
        }

        /// <summary>
        /// Загружает данные из XML формата
        /// </summary>
        public void LoadData()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "storage.xml");
            if (!File.Exists(path))
            {
                return;
            }
            var xDocument = XDocument.Load(path);
            foreach (var element in xDocument.Element("Storage").Elements())
            {
                KeyValues[element.Name.LocalName] = element.Value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public OctopusStorage()
        {
            KeyValues = new Dictionary<string, string>();
            LoadData();
        }
    }
}