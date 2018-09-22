using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class HouseArea
    {
        public static void GetHouseArea()
        {
            var rooms = GetUserInput();
            var results = CalculateHouseArea(rooms);
            ReturnHouseArea(results);
        }
        static string[] GetUserInput()
        {
            Console.WriteLine("Please enter a comma delimited list of the rooms in the house.");
            return Console.ReadLine().Split(',');
        }

        private static (Dictionary<string, double>, double) CalculateHouseArea(string[] rooms)
        {
            double totalArea = 0;

            var roomsAndAreas = new Dictionary<string, double>();

            foreach (var room in rooms)
            {
                Console.WriteLine($"Please enter the length of the {room} in meters");
                var roomLength = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"Please enter the width of the {room} in meters");
                var roomWidth = Convert.ToDouble(Console.ReadLine());

                var roomArea = roomLength * roomWidth;

                roomsAndAreas.Add(room, roomArea);

                totalArea = totalArea + roomArea;
            }
            return (roomsAndAreas, totalArea);
        }

        static void ReturnHouseArea((Dictionary<string, double> roomsAndAreas, double totalArea) results)
        {
            Console.WriteLine($"Room \t Size(m^2)");

            foreach (var roomAndArea in results.roomsAndAreas)
            {
                Console.WriteLine($"{roomAndArea.Key}\t{roomAndArea.Value}");
            }
            Console.WriteLine($"Total \t {results.totalArea}");

            Console.WriteLine("Press return to exit");
            Console.ReadLine();
        }
    }
}
