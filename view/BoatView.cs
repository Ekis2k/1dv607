using System;
using _1dv607.model;

namespace _1dv607.view
{
    class BoatView
    {
        BoatModel bm = new BoatModel();
        private enum MenuOptions
        {
            ExitBoatMenu = 0,
            AddBoat = 1,
            EditBoat = 2,
            RemoveBoat = 3,
        }
        public void AddBoat(BoatModel boat)
        {
            int userId;
            string type;
            int length;
            Console.Clear();
            Console.WriteLine("Add new Boat");
            Console.WriteLine("Enter Member Id");
            userId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("1: Sailboat , 2: Motorboat , 3: Kayak , 4: Other");
            type = Console.ReadLine();

            if (type == "1")
            {
                type = "Sailboat";
            }
            else if (type == "2")
            {
                type = "Motorboat";
            }
            else if (type == "3")
            {
                type = "Kayak";
            }
            else if (type == "4")
            {
                type = "Other";
            }
            else
            {
                Console.WriteLine("Not valid type of boat");
            }

            Console.WriteLine("Enter Length");
            length = Int32.Parse(Console.ReadLine());

            boat.AddBoat(userId, type, length);
            Console.WriteLine("Boat Added");
        }
        public void EditBoat(BoatModel boat)
        {
            int userId;
            string type;
            int length;
            int boatId;
            Console.Clear();
            Console.WriteLine("Edit Boat");
            Console.WriteLine("Enter Member Id");
            userId = Int32.Parse(Console.ReadLine());

            while(true)
            {
                try
                {
                    Console.WriteLine("Enter Boat Id");
                    boatId = Int32.Parse(Console.ReadLine());
                    try
                    {
                        boat.GetBoat(userId, boatId);
                    }
                    catch
                    {
                        Console.WriteLine("No matching boat id");
                        SafeExit();
                        return;
                    }
                    Console.WriteLine("Enter new type");
                    type = Console.ReadLine();

                    try
                    {
                        Console.WriteLine("Enter new Length");
                        length = Int32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        length = 0;
                    }
                    boat.EditBoat(userId, boatId, type, length);
                    Console.WriteLine("Boat Edited");
                }
                catch (Exception)
                {
                    Console.WriteLine("No Matching boat Id");
                }
                SafeExit();
                break;
            }
        }
        public void DeleteBoat(BoatModel boat)
        {
            int userId;
            int boatId;
            Console.Clear();
            Console.WriteLine("Delete Boat");
            Console.WriteLine("Enter Member Id");
            userId = Int32.Parse(Console.ReadLine());
            
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Boat Id");
                    boatId = Int32.Parse(Console.ReadLine());
                    try
                    {
                        boat.RemoveBoat(userId, boatId);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No Matching Boat id");
                        SafeExit();
                        return;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No Matching Boat id");
                    SafeExit();
                    return;
                }
            }
            Console.WriteLine("Boat Removed");
            SafeExit();
        }
        public void BoatMenu()
        {
            while (true)
            {
                int menuOptions = MainBoat();

                switch(menuOptions)
                {
                    case (int)MenuOptions.ExitBoatMenu:
                        return;
                    case (int)MenuOptions.AddBoat:
                        AddBoat(bm);
                        return;
                    case (int)MenuOptions.EditBoat:
                        EditBoat(bm);
                        return;
                    case (int)MenuOptions.RemoveBoat:
                        DeleteBoat(bm);
                        return;
                    default:
                        break;
                }
            }
        }
        public int MainBoat()
        {
            int index;

            do
            {
                Console.Clear();
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Add Boat");
                Console.WriteLine("2: Edit Boat");
                Console.WriteLine("3: Remove Boat");

                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 3)
                {
                    return index;
                }
                else
                {
                    Console.WriteLine("Enter number 0-3");
                    SafeExit();
                }
            }
            while(true);
        }
        private void SafeExit()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}
