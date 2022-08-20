using System;

namespace TimeConversion {
    //Given a time in 12-hour AM/PM format, convert it to military (24-hour) time.
    //Note: - 12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock.
    //- 12:00:00PM on a 12-hour clock is 12:00:00 on a 24-hour clock.
    //Input: "12:01:00PM" Output: "12:01:00", "12:01:00AM" Output: "00:01:00"
    //Input: "07:05:45PM" Output: "19:05:45"
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(timeConversion("12:00:00AM")); //Expected: 00:00:00
            Console.WriteLine(timeConversion("12:00:00PM")); //Expected: 12:00:00
            Console.WriteLine(timeConversion("12:01:00PM")); //Expected: 12:01:00
            Console.WriteLine(timeConversion("12:01:00AM")); //Expected: 00:01:00
            Console.WriteLine(timeConversion("07:05:45PM")); //Expected: 19:05:45
            Console.WriteLine(timeConversion("12:45:55PM")); //Expected: 12:45:55
            Console.WriteLine(timeConversion("12:40:22AM")); //Expected: 00:40:22
        }

        public static string timeConversion(string s) {
            string result = string.Empty;
            string time = s.Substring(0, 8);
            string hh = s.Substring(0, 2);
            string ampm = s.Substring(8, 2);

            if (ampm == "AM") {
                if (hh == "12") {
                    time = "00" + time.Substring(2);
                }
                return time;
            }

            if (ampm == "PM") {
                if (hh == "12") {
                    return time;
                } else {
                    return (int.Parse(hh) + 12) + time.Substring(2);
                }
            }

            return result;
        }
        

        public static string timeConversion2(string s) {
            string result = string.Empty;

            bool isTime = DateTime.TryParse(s, out DateTime time);

            if (isTime) {
                return time.ToString("HH:mm:ss");
            }

            return result;
        }

        public static string timeConversion3(string s) {
            string[] arr = s.Split(':');
            string hh = arr[0];
            string mm = arr[1];
            string ss = arr[2].Substring(0, 2);
            string ampm = arr[2].Substring(2, 2);

            if (ampm == "AM") {
                if (hh == "12") {
                    return (12 - int.Parse(hh)).ToString("00") + ":" + mm + ":" + ss;
                }
                return hh + ":" + mm + ":" + ss;
            }

            if (ampm == "PM") {
                if (hh == "12") {
                    return hh + ":" + mm + ":" + ss;
                }
                return (12 + int.Parse(hh)).ToString("00") + ":" + mm + ":" + ss;
            }

            return s.Substring(0, 8);
        }

    }
}
