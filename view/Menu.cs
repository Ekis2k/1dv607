using System;
using _1dv607.model;

namespace _1dv607.view
{
    class Menu
    {
        UserModel um = new UserModel();
        BoatModel bm = new BoatModel();
        UserView uv = new UserView();
        BoatView bv = new BoatView();
        private enum MenuOptions
        {
            Exit = 0,
            Add = 1,
            Change = 2,
            Delete = 3,
            Show = 4,
            Compact = 5,
            Verbose = 6,
            Boats = 7, 
        }
        public void Init ()
        {
            while(true)
            {
                int menuOptions = MainMenu();
                switch (menuOptions)
                {
                    case (int)MenuOptions.Exit:
                        Environment.Exit(0);
                        return;
                    case (int)MenuOptions.Add:
                        uv.AddMember(um);
                        return;
                    case (int)MenuOptions.Change:
                        uv.EditMember(um);
                        return;
                    case (int)MenuOptions.Delete:
                        uv.DeleteMember(um);
                        return;
                    case (int)MenuOptions.Show:
                        uv.ShowSingleMember(um);
                        return;
                    case (int)MenuOptions.Compact:
                        uv.CompactList(um, bm);
                        return;
                    case (int)MenuOptions.Verbose:
                        uv.VerboseList(um, bm);
                        return;
                    case (int)MenuOptions.Boats:
                        bv.BoatMenu();
                        return;
                    default:
                        break;
                }
            }
        }
        private int MainMenu()
        {
            int index;
            do
            {
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Add Member");
                Console.WriteLine("2: Change Member Information");
                Console.WriteLine("3: Delete Member");
                Console.WriteLine("4: Look at specific member information");
                Console.WriteLine("5: View Compact List");
                Console.WriteLine("6: View Verbose List");
                Console.WriteLine("7: Manage Boats");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 7)
                {
                    return index;
                }
                else
                {
                    Console.WriteLine("Enter number 0-7");
                    SafeExit();
                }
            } while (true);
        }
        private void SafeExit()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}
