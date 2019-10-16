using System;
using System.Xml;
using System.Xml.Linq;

namespace _1dv607
{
    class Database
    {
        private string _filePath = "BoatClub.xml";
        XDocument xmlDoc;

        public string Path { get => _filePath; set => _filePath = value; }

        public XDocument GetDocument()
        {
            xmlDoc = XDocument.Load(Path);
            return xmlDoc;
        }
    }
}
