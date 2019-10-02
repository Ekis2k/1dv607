using System;
using System.Collections.Generic;
using _1dv607.model;

namespace _1dv607.view
{
    class UserView
    {
        public void AddMember(UserModel user)
        {
            Console.WriteLine("Added Member");
        }
        public void EditMember(UserModel user)
        {
            Console.WriteLine("Edit Member");
        }
        public void DeleteMember(UserModel user)
        {
            Console.WriteLine("Delete Member");
        }
        public void ShowSingleMember(UserModel user)
        {
            Console.WriteLine("Show single Member");
        }
        public void CompactList(UserModel user, BoatModel boat)
        {
            Console.WriteLine("Compact List");
        }
        public void VerboseList(UserModel user, BoatModel boat)
        {
            Console.WriteLine("Verbose List");
        }
    }
}
