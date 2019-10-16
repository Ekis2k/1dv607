using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace _1dv607.model
{
    class UserModel
    {
        private string name;
        private int _date;
        private int _ID;
        public List<BoatModel> Boats = new List<BoatModel>();
        Database db = new Database();
        public string FullName
        {
            get { return name; }
            set { name = value; }
        }
        public int Birthday
        {
            get { return _date; }
            set { _date = value; }
        }
        public int UserID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public void AddUser(string name, int date)
        {
            var xmlDoc = db.GetDocument();
            int userId = ((from user in xmlDoc.Descendants("User")
                          select (int)user.Attribute("userId")).DefaultIfEmpty(0).Max()) + 1;

            xmlDoc.Descendants("Users")
                    .FirstOrDefault()
                    .Add(new XElement("User",
                    new XAttribute("userId", userId),
                    new XAttribute("name", name),
                    new XAttribute("birthday", date),
                    new XElement("Boats")));
            
            xmlDoc.Save(db.Path);
        }
        public void EditUser(int userId, string name = null, int date = 0)
        {
            var xmlDoc = db.GetDocument();

            if (name.Length > 1)
            {
                xmlDoc.Descendants("User")
                        .Where(x => (int)x.Attribute("userId") == userId)
                        .Single()
                        .SetAttributeValue("name", name);
            }
            if (date != 0)
            {
                xmlDoc.Descendants("User")
                        .Where(x => (int)x.Attribute("userId") == userId)
                        .Single()
                        .SetAttributeValue("birthday", date);
            }
            xmlDoc.Save(db.Path);
        }
        public void RemoveUser(int userId)
        {
            var xmlDoc = db.GetDocument();

            if (GetUser(userId) != null)
            {
                xmlDoc.Descendants("User")
                        .Where(x => (int)x.Attribute("userId") == userId)
                        .Remove();
                xmlDoc.Save(db.Path);
            }
        }
        public UserModel GetUser(int userId)
        {
            var xmlDoc = db.GetDocument();

            var singleUser = (from user in xmlDoc.Descendants("User").Where(x => (int)x.Attribute("userId") == userId)
                              select new UserModel
                              {
                                  FullName = (string)user.Attribute("name"),
                                  Birthday = (int)user.Attribute("birthday"),
                                  UserID = (int)user.Attribute("userId"),
                                  Boats = (from boat in user.Descendants("Boat")
                                            select new BoatModel
                                            {
                                                BoatId = (int)boat.Attribute("boatId"),
                                                BoatType = (string)boat.Attribute("type"),
                                                Length = (int)boat.Attribute("length")
                                            }).ToList()
                              }).Single();
            return singleUser;
        }
        public IEnumerable<UserModel> ShowAllUsers()
        {
            var xmlDoc = db.GetDocument();

            var users = (from user in xmlDoc.Descendants("User")
                              select new UserModel
                              {
                                  FullName = (string)user.Attribute("name"),
                                  Birthday = (int)user.Attribute("birthday"),
                                  UserID = (int)user.Attribute("userId"),
                                  Boats = (from boat in user.Descendants("Boat")
                                            select new BoatModel
                                            {
                                                BoatId = (int)boat.Attribute("boatId"),
                                                BoatType = (string)boat.Attribute("type"),
                                                Length = (int)boat.Attribute("length")
                                            }).ToList()
                              }).ToList();
            return users;
        }
    }
}
