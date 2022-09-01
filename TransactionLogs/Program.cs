using System;
using System.Collections.Generic;
using System.Linq;

namespace TransactionLogs
{
    //A log file is provided as a string array when each entry represents a transaction to service. The values are separated by
    //a space. For example, "sender_user_id  recipient_user_id  amount_of_transaction". Users that perform an excessive amount
    //of transactions might be abusing the service so you have been tasked to identify the users that have a number of
    //transactions over a threshold. The list of users Ids should be ordered in ascendic numeric value.
    //Example:
    //logs = ["88 99 20", "88 99 300", "99 32 100", "12 12 15"]
    //threshold = 2
    //
    //The transactions count for each user, regardless of role are:
    // ID   Transactions
    // 99   3
    // 88   2
    // 12   1
    // 32   1
    //
    //There are two users with at least threshold = 2 transactions: 99 and 88. In ascending order the return array is ['88', '99']
    //
    //Note: In the last long entry, user 12 was on both sides of the transaction. This counts as only 1 transaction for user 12.

    class Program
    {        
        static void Main(string[] args)
        {            
            List<string> lst1 = ProcessLogs(new List<string>() { "88 99 200", "88 99 300", "99 32 100", "12 12 15" }, 2);//Expected: ["88", "99"]
            List<string> lst2 = ProcessLogs(new List<string>() { "1 2 50", "1 7 70", "1 3 20", "2 2 17" }, 2);//Expected: ["1", "2"]
            List<string> lst3 = ProcessLogs(new List<string>() { "9 7 50", "22 7 20", "33 7 50", "22 7 30" }, 2);//Expected: ["7", "22"]
            List<string> lst4 = ProcessLogs(new List<string>() { "88 99 200", "88 99 300", "99 32 100", "12 12 15" }, 3);//Expected: ["99"]
            List<string> lst5 = ProcessLogs(new List<string>() { "1 2 50", "1 7 70", "1 3 20", "2 2 17" }, 3);//Expected: ["1"]
            List<string> lst6 = ProcessLogs(new List<string>() { "9 7 50", "22 7 20", "33 7 50", "22 7 30" }, 3);//Expected: ["7"]

            lst1.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            lst2.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            lst3.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            lst4.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            lst5.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            lst6.ForEach(x => Console.WriteLine(x));
            Console.ReadLine();
        }

        public static List<string> ProcessLogs(List<string> logs, int threshold) {

            Dictionary<string, int> HMap = new Dictionary<string, int>();

            foreach (var item in logs) {

                string[] arr = item.Split(' ');
                for (int i = 1; i < arr.Length - 1; i++) {
                    if (arr[i - 1] == arr[i]) {
                        if (HMap.ContainsKey(arr[i])) {
                            HMap[arr[i]]++;
                        } else {
                            HMap[arr[i]] = 1;
                        }
                    } else {
                        if (HMap.ContainsKey(arr[i - 1])) {
                            HMap[arr[i - 1]]++;
                        } else {
                            HMap[arr[i - 1]] = 1;
                        }

                        if (HMap.ContainsKey(arr[i])) {
                            HMap[arr[i]]++;
                        } else {
                            HMap[arr[i]] = 1;
                        }
                    }
                }

            }

            return HMap.Where(x => x.Value >= threshold).Select(x => x.Key).ToList();
        }

        public static List<string> ProcessLogs2(List<string> logs, int threshold)
        {
            List<string> result = new List<string>();
            Dictionary<string, int> hMap = new Dictionary<string, int>();

            foreach (var log in logs)
            {
                string[] items = log.Split(' ');
                int count;
                hMap.TryGetValue(items[0], out count);
                count++;
                hMap[items[0]] = count;

                if (items[0] != items[1])
                {
                    int count2;
                    hMap.TryGetValue(items[1], out count2);
                    count2++;
                    hMap[items[1]] = count2;
                }
            }

            foreach (var item in hMap)
            {
                if (item.Value >= threshold )
                {
                    result.Add(item.Key);
                }
            }

            //userIds.Sort();

            //userIds.Sort((a, b) => a.CompareTo(b)); //ascending order
            //userIds.Sort((a, b) => b.CompareTo(a)); //descending order

            //userIds.Reverse();

            //userIds.OrderByDescending(x => x).ToList();

            //var result = (from x in userIds
            //             orderby x descending
            //             select x)
            //             .ToList();            

            return result;
        }

        //public static List<string> ProcessLogsLinq(List<string> logs, int threshold)
        //{
        //    List<string> userIds = new List<string>();
        //    Dictionary<string, int> map = new Dictionary<string, int>();

        //    var result = logs.Select(x => x.Split(' ').Take(2)).GroupBy(x => x).Select(c => new { Key = c.Key, total = c.Count() });
              

        //    return userIds;
        //}
    }
}
