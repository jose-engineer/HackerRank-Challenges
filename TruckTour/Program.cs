using System;
using System.Collections.Generic;

namespace TruckTour {
    //Suppose there is a circle. There are N petrol pumps on that circle. Petrol pumps are numbered 0 to (N - 1) (both inclusive).
    //You have two pieces of information corresponding to each of the petrol pump: (1) the amount of petrol that particular petrol
    //pump will give, and (2) the distance from that petrol pump to the next petrol pump.
    //Initially, you have a tank of infinite capacity carrying no petrol.You can start the tour at any of the petrol pumps.
    //Calculate the first point from where the truck will be able to complete the circle.
    //Consider that the truck will stop at each of the petrol pumps. The truck will move one kilometer for each litre of the petrol.
    //Output Format:
    //An integer which will be the smallest index of the petrol pump from which we can start the tour.

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(truckTour(new List<List<int>>() { 
                                            new List<int> { 1, 5 }, 
                                            new List<int> { 10, 3 }, 
                                            new List<int> { 3, 4 } })); //Expected: 1
        }

        public static int truckTour(List<List<int>> petrolpumps) {
            int petrol = 0;
            int start = 0;

            for (int i = 0; i < petrolpumps.Count - 1; i++) {
                List<int> item = petrolpumps[i];
                //petrolRemaining = petrolGivenByPump - distance    
                petrol += item[0] - item[1];// -4 = 0 + 1 - 5         // petrol += petrolpumps[i][0] - petrolpumps[i][1]                               
                                            // 7 = 0 + 10 - 3
                                            // 6 = 7 + 3 - 4
                if (petrol < 0) { //If petrol < 0 we are anticipating that the next item will be the start that we are looking for
                    start = i + 1; //start = 1
                    petrol = 0;
                }
            }

            return start;
        }

    }
}
