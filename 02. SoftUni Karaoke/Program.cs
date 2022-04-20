using System;
using System.Collections.Generic;
using System.Linq;


namespace Problem_2.SoftUni_Karaoke
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ListOfValidParticipants = new List<string>();
            List<string> ListOfValidSongs = new List<string>();

            Dictionary<string, List<string>> validAwardWinnersList = new Dictionary<string, List<string>>();

            string[] getParticipants = Console.ReadLine().Split((", "), StringSplitOptions.RemoveEmptyEntries);

            if (getParticipants.Length == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            ListOfValidParticipants = addToList(getParticipants);

            string[] getSongList = Console.ReadLine().Split((", "), StringSplitOptions.RemoveEmptyEntries);

            if (getSongList.Length == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            ListOfValidSongs = addToList(getSongList);


            string input = Console.ReadLine();

            while (input != "dawn")
            {
                string[] inputArray = input.Split((", "), StringSplitOptions.None);

                if (inputArray.Length != 3)
                {
                    input = Console.ReadLine();
                    continue;
                }

                string participantName = inputArray[0];
                string musicNumber = inputArray[1];
                string award = inputArray[2];


                if (ListOfValidParticipants.Any(x => x == participantName) && ListOfValidSongs.Any(x => x == musicNumber))
                {
                    if (!validAwardWinnersList.ContainsKey(participantName))
                    {
                        validAwardWinnersList[participantName] = new List<string>();
                    }

                    validAwardWinnersList[participantName].Add(award);

                }

                input = Console.ReadLine();
            }

            
            if (validAwardWinnersList.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            foreach (var participant in validAwardWinnersList.OrderByDescending(x => x.Value.Distinct().Count()).ThenBy(x => x.Key).Distinct())
            {
                Console.WriteLine($"{participant.Key}: {participant.Value.Distinct().Count()} awards");

                foreach (var awards in participant.Value.OrderBy(x => x).Distinct())
                {
                    Console.WriteLine($"--{awards}");
                }

            }




        }

        private static List<string> addToList(string[] stuff)
        {
            List<string> justAList = new List<string>();

            foreach (var item in stuff)
            {
                justAList.Add(item);
            }
            return justAList;
        }


    }
}