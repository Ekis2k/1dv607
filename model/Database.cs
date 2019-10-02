using System;
using System.Xml;
using System.Xml.Linq;

namespace model
{
    class Database
    {
        private string _filePath = "BoatClub.xml";
        XDocument xmlDocument;
        public string Path
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public XDocument GetDocument()
        {
            return xmlDocument;
        }
        public Database()
        {
            xmlDocument = XDocument.Load(Path);
        }
    }
}
