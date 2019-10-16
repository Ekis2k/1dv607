using System;
using System.Collections.Generic;
using _1dv607.model;

namespace _1dv607.view
{
    class UserView
    {
        public void AddMember(UserModel user)
        {
            string name;
            int date;

            Console.Clear();
            Console.WriteLine("Enter Name");
            name = Console.ReadLine();
            while(true)
            {
                try
                {
                    Console.WriteLine("Enter Birthdate, 10 numbers");
                    date = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Birthday not entered correct.");
                }
            }
            user.AddUser(name, date);
            Console.WriteLine("User Saved");
            SafeExit();
        }
        public void EditMember(UserModel user)
        {
            string name;
            int date;
            int userId;

            Console.Clear();
            Console.WriteLine("EditMember");

            while(true)
            {
                try
                {
                    Console.WriteLine("Enter Member ID");
                    userId = Int32.Parse(Console.ReadLine());
                    try
                    {
                        user.GetUser(userId);
                    }
                    catch
                    {
                        Console.WriteLine("No user with that id");
                        SafeExit();
                        return;
                    }
                    Console.WriteLine("Enter a name");
                    name = Console.ReadLine();

                    try
                    {
                        Console.WriteLine("Enter your Birthday date, 10 numbers");
                        date = Int32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        date = 0;
                    }
                    user.EditUser(userId, name, date);
                    Console.WriteLine("Member Edited");
                }
                catch (Exception)
                {
                    Console.WriteLine("No matching member ID");
                }
                SafeExit();
                break;
            }
        }
        public void DeleteMember(UserModel user)
        {
            int userId;
            Console.Clear();
            Console.WriteLine("Delete Member");

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Member ID");
                    userId = Int32.Parse(Console.ReadLine());
                    try
                    {
                        user.RemoveUser(userId);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No matching Member ID");
                        SafeExit();
                        return;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No matching Member ID");
                    SafeExit();
                    return;
                }
            }
            Console.WriteLine("Member Removed");
            SafeExit();
        }
        public void ShowSingleMember(UserModel user)
        {
            int userId;
            Console.Clear();
            Console.WriteLine("Enter Member ID");
            userId = Int32.Parse(Console.ReadLine());

            IEnumerable<UserModel> users = user.ShowAllUsers();

            foreach (var u in users)
            {
                if (userId == u.UserID)
                {
                    Console.WriteLine("ID: {0}, Name: {1}, Birthday: {2}", u.UserID, u.FullName, u.Birthday);

                    foreach(var b in u.Boats)
                    {
                        Console.WriteLine("Boat ID: {0}", b.BoatId);
                        Console.WriteLine("Boat Type: {0}", b.BoatType);
                        Console.WriteLine("Boat Length: {0} ft", b.Length);
                    }
                }
            }
            SafeExit();
        }
        public void CompactList(UserModel user, BoatModel boat)
        {
            Console.Clear();
            IEnumerable<UserModel> users = user.ShowAllUsers();

            foreach (var u in users)
            {
                Console.WriteLine("ID: {0}, Name: {1}, Birthday: {2}", u.UserID, u.FullName, u.Birthday);
                Console.WriteLine("---------------------------------");
            }
            SafeExit();
        }
        public void VerboseList(UserModel user, BoatModel boat)
        {
            Console.Clear();
            IEnumerable<UserModel> users = user.ShowAllUsers();
            foreach(var u in users)
            {
                Console.WriteLine("ID: {0}, Name: {1}, Birthday: {2}", u.UserID, u.FullName, u.Birthday);

                    foreach(var b in u.Boats)
                    {
                        Console.WriteLine("Boat ID: {0}", b.BoatId);
                        Console.WriteLine("Boat Type: {0}", b.BoatType);
                        Console.WriteLine("Boat Length: {0} ft", b.Length);
                    }
                Console.WriteLine("----------------------");
            }
            SafeExit();
        }
        private void SafeExit()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}
