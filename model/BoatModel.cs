using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace model
{
    class BoatModel
    {
        private int _boatID;
        private string _boatType;
        private int _length;
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
        
        public void AddBoat(int memberId, int boatId, string type = null, int length = 0)
        {
            Console.WriteLine("Added Boat!");
        }
        public void EditBoat(int memberId, string type, int length)
        {
            Console.WriteLine("Editing Boat!");
        }
        public void RemoveBoat(int memberId, int boatId)
        {
            Console.WriteLine("Remove World!");
        }
    }
}