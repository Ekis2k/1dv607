using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace _1dv607.model
{
    class BoatModel
    {
        private int _boatID;
        private string _boatType;
        private int _length;
        Database db = new Database();
        public int BoatId
        {
            get { return _boatID; }
            set { _boatID = value; }
        }
        public string BoatType
        {
            get { return _boatType; }
            set { _boatType = value; }
        }
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }
        
        public void AddBoat(int userId, string type, int length)
        {
            var xmlDoc = db.GetDocument();

            var boatId = ((from user in xmlDoc.Descendants("Boat")
                            select (int)user.Attribute("boatId")).DefaultIfEmpty(0).Max()) + 1;

            xmlDoc.Descendants("User")
                    .Where(x => (int)x.Attribute("userId") == userId).FirstOrDefault()
                    .Descendants("Boats")
                    .FirstOrDefault()
                    .Add(new XElement("Boat",
                    new XAttribute("boatId", boatId),
                    new XAttribute("type", type),
                    new XAttribute("length", length)));
            
            xmlDoc.Save(db.Path);
    
        }
        public void EditBoat(int userId, int boatId, string type = null, int length = 0)
        {
            var xmlDoc = db.GetDocument();

            if (type.Length > 1)
            {
                xmlDoc.Descendants("User")
                        .Where(x => (int)x.Attribute("userId") == userId)
                        .Descendants("Boat")
                        .Where(x => (int)x.Attribute("boatId") == boatId)
                        .Single()
                        .SetAttributeValue("type", type);
            }
            if (length != 0)
            {
                xmlDoc.Descendants("User")
                        .Where(x => (int)x.Attribute("userId") == userId)
                        .Descendants("Boat")
                        .Where(x => (int)x.Attribute("boatId") == boatId)
                        .Single()
                        .SetAttributeValue("length", length);
            }
            xmlDoc.Save(db.Path);
        }
        public void RemoveBoat(int userId, int boatId)
        {
            var xmlDoc = db.GetDocument();

            if (GetBoat(userId, boatId) != null)
            {
                xmlDoc.Descendants("Boat")
                        .Where(x => (int)x.Attribute("boatId") == boatId)
                        .Remove();
                xmlDoc.Save(db.Path);
            }
        }
        public BoatModel GetBoat(int userId, int boatId)
        {
            var xmlDoc = db.GetDocument();

            var singleBoat = (from boat in xmlDoc.Descendants("User").Where(x => (int)x.Attribute("userId") == userId)
                                                 .Descendants("Boat").Where(x => (int)x.Attribute("boatId") == boatId)
                              select new BoatModel
                              {
                                  BoatType = (string)boat.Attribute("type"),
                                  Length = (int)boat.Attribute("length"),
                                  BoatId = (int)boat.Attribute("boatId")
                              }).Single();

            return singleBoat;      
        }
    }
}