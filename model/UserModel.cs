using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace model
{
    class UserModel
    {
        private string name;
        private int _date;
        private int _ID;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public int MemberId
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public void EditUser(string name, int date)
        {
            Console.WriteLine("Added Boat!");
        }
        public void RemoveUser(int memberId, string name = null, int date = 0)
        {
            Console.WriteLine("Added Boat!");
        }
    }
}
