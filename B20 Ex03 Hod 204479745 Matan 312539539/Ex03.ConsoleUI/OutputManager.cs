﻿namespace Ex03.ConsoleUI
{
    using System;
    using System.Text;
    using System.Threading;
    using Ex03.GarageLogic;

    static class OutputManager
    {
        public static void ShowWelcomeMessage()
        {
            ShowMessage("Welcome!");
            Thread.Sleep(1000);
        }

        public static void ShowMainMenuScreen()
        {
            StringBuilder stringToPrint = new StringBuilder();

            stringToPrint.Append(@"Please enter the number of which option you wish to perform:
1. Enter a new vehicle to the garage.
2. Showcase the stored vehicles ID with a filter option.
3. Change a vehicle state.
4. Inflate all vehicle's wheels to maximum capacity.
5. Refuel a vehicle by engine type.
6. Display a vehicle's full detail.
7. Exit.");
            clearScreenAndPrint(stringToPrint);
        }

        public static void ShowScreen<T>(string i_MessageBeforeEnum)
        {
            StringBuilder stringToPrint = new StringBuilder();

            stringToPrint.AppendLine(i_MessageBeforeEnum);
            stringToPrint.Append(getAppropriateEnumMenu<T>());
            clearScreenAndPrint(stringToPrint);
        }

        public static void ShowFilterByVehicleStateScreen()
        {
            StringBuilder stringToPrint = new StringBuilder();
            int           enumLength;

            enumLength = Enum.GetNames(typeof(StoredVehicle.eVehicleState)).Length;
            stringToPrint.AppendLine("Please enter the number of the desired filter:");
            stringToPrint.Append(getAppropriateEnumMenu<StoredVehicle.eVehicleState>());
            stringToPrint.AppendLine();
            stringToPrint.AppendFormat("{0}. No Filter.", (enumLength + 1));
            clearScreenAndPrint(stringToPrint);
        }

        public static void ShowDisplayVehicleDetailsScreen()
        {

        }

        private static void clearScreenAndPrint(StringBuilder i_StringToPrint)
        {
            Console.Clear();
            Console.WriteLine(i_StringToPrint);
        }

        public static void ShowMessage(string i_StringToShow)
        {
            Console.Clear();
            Console.WriteLine(i_StringToShow);
        }
        
        public static void ShowErrorMessage(string i_StringToShow)
        {
            Console.WriteLine(i_StringToShow);
            Thread.Sleep(1000);
        }

        private static StringBuilder getAppropriateEnumMenu<T>()
        {
            int menuIndex = 1;
            StringBuilder stringToPrint = new StringBuilder();

            foreach (string enumMember in Enum.GetNames(typeof(T)))
            {
                stringToPrint.AppendFormat("{0}. {1}", menuIndex, enumMember);
                menuIndex++;
            }

            return stringToPrint;
        }
    }
}
