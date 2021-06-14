using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming_Assignment_2_Summer_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 2, 5, 1, 3, 4, 7 };
            int[] nums2 = { 2, 1, 4, 7 };
            Intersection(nums1, nums2);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
                Console.WriteLine("Lucky Integer for given array {0}", Lnum);

            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximum Sum contiguous subarray {0}", Ma);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minimum cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        //Given two integer arrays nums1 and nums2, return an array of their intersection.
        //Each element in the result must be unique and you may return the result in any order.
        //Example 1:
        //Input: nums1 = [1,2,2,1], nums2 = [2,2]
        //Output: [2]
        //Example 2:
        //Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        //Output: [9,4]
        //
        /// </summary>

        public static void Intersection(int[] nums1, int[] nums2)
        {
            try
            {
                // Sorting the arrays first to get them in correct order
                Array.Sort(nums1);
                Array.Sort(nums2);
                //list created to store the values that are intersections
                var myList = new List<int>();
                int i = 0, j = 0, sameVal = 0;
                while (i < nums1.Length && j < nums2.Length)
                {
                    // if they are same number add to list
                    if (nums1[i] == nums2[j])
                    {
                        myList.Add(nums2[j]);
                        sameVal = nums2[j];
                        i++;
                        j++;
                        while (i < nums1.Length && j < nums2.Length && nums1[i] == sameVal && nums2[j] == sameVal)
                        {
                            i++;
                            j++;
                        }
                    }// if first array number is bigger than second array number, second array moves onto next value)
                    else if (nums1[i] > nums2[j])
                    {
                        j++;
                    }
                    // if second array number is bigger then the first array goes onto next number
                    else
                    {
                        i++;
                    }
                }
               myList.ToArray();
                foreach (var item in myList)
                {
                    Console.Write(item.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 2:
        /// <summary>
        //Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.
        //Note: You must write an algorithm with O(log n) runtime complexity.
        //Example 1:
        //Input: nums = [1, 3, 5, 6], target = 5
        //Output: 2
        //Example 2:
        //Input: nums = [1, 3, 5, 6], target = 2
        //Output: 1
        //Example 3:
        //Input: nums = [1, 3, 5, 6], target = 7
        //Output: 4
        //Example 4:
        //Input: nums = [1, 3, 5, 6], target = 0
        //Output: 0
        /// </summary>

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {// Creating three indexes, low is the first index which evaluates left side
                // the upper index is the second and evaluate the right side
                // the mid index is used to identify the middle or turning point (increment to decrement) between
                // the two indexes
                int low = 0;
                int upper = nums.Length - 1;
                int mid;

                while (low <= upper)
                {

                    mid = low + (upper - low) / 2;

                    if (target == nums[mid]) 
                    { // index return of the target
                        return mid; 
                    } 
                   else if (target > nums[mid]) 
                    { 
                        low = mid + 1; 
                    } 
                    else 
                    { 
                        upper = mid - 1; 
                    }
                }

                return low;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Question 3
        /// <summary>
        //Given an array of integers arr, a lucky integer is an integer which has a frequency in the array equal to its value.
        //Return a lucky integer in the array. If there are multiple lucky integers return the largest of them. If there is no lucky integer return -1.
        //Example 1:
        //Input: arr = [2, 2, 3, 4]
        //Output: 2
        //Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        /// </summary>

        private static int LuckyNumber(int[] nums)
        {
            try
            { //Sorting the given input array for easier processing and comparison set default count value
                Array.Sort(nums);
                int count = 1;
                //counting the occurences of elements in the array, counter increments up
                //if first and second number in element match.
                for (int i = nums.Length - 2; i > -1; i--)
                {
                    if (nums[i] == nums[i + 1]) count++;
                    else
                    {
                        if (nums[i + 1] == count) return count;
                        count = 1;
                    }
                }

                if (count == nums[0]) return count;

                return -1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4:
        /// <summary>
        //You are given an integer n.An array nums of length n + 1 is generated in the following way:
        //•	nums[0] = 0
        //•	nums[1] = 1
        //•	nums[2 * i] = nums[i]  when 2 <= 2 * i <= n
        //•	nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n
        // Return the maximum integer in the array nums.

        //Example 1:
        //Input: n = 7
        //Output: 3
        //Explanation: According to the given rules:
        //nums[0] = 0
        //nums[1] = 1
        //nums[(1 * 2) = 2] = nums[1] = 1
        //nums[(1 * 2) + 1 = 3] = nums[1] + nums[2] = 1 + 1 = 2
        //nums[(2 * 2) = 4] = nums[2] = 1
        //nums[(2 * 2) + 1 = 5] = nums[2] + nums[3] = 1 + 2 = 3
        //nums[(3 * 2) = 6] = nums[3] = 2
        //nums[(3 * 2) + 1 = 7] = nums[3] + nums[4] = 2 + 1 = 3
        //Hence, nums = [0, 1, 1, 2, 1, 3, 2, 3], and the maximum is 3.

        /// </summary>
        private static int GenerateNums(int n)
        {
            try
            { //This is the condition for the default case
                if (n <= 0)
                    return 0;

                int length = n + 1;
                int[] nums = new int[length];

                nums[0] = 0;//1st index
                nums[1] = 1;// the second index

                if (length == 2)
                    return 1;

                int max = 1;// default maximum value

                for (int i = 2; i < length; i++)
                {
                    nums[i] = nums[i / 2];

                    if (i % 2 != 0)
                        nums[i] += nums[1 + (i / 2)];

                    if (nums[i] > max)
                        max = nums[i]; //changes maximum value if element is found bigger than max
                }

                return max;
               
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Question 5
        /// <summary>
        //You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi.Return the destination city, that is, the city without any path outgoing to another city.
        //It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        //Example 1:
        //Input: paths = [["London", "New York"], ["New York","Lima"], ["Lima","Sao Paulo"]]
        //Output: "Sao Paulo" 
        //Explanation: Starting at "London" city you will reach "Sao Paulo" city which is the destination city.Your trip consist of: "London" -> "New York" -> "Lima" -> "Sao Paulo".
        /// </summary>
        public static string DestCity(List<List<string>> paths)
        {
            try
            {
                ISet<string> TravelSet = new HashSet<string>();
            foreach (var p in paths)
            {
                TravelSet.Add(p[0]); // adds each location to Hashset
            }

            foreach (var p in paths)
            {
                if (!TravelSet.Contains(p[1]))
                {
                    return p[1];// compares location to see if its repeated and returns as destination if not
                }
            }

            return "";
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 6:
        /// <summary>
        //Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        //Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers.Length.
        //You may not use the same element twice, there will be only one solution for a given array
        //Example 1:
        //Input: numbers = [2,7,11,15], target = 9
        //Output: [1,2]
        //Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

        /// </summary>
        private static void targetSum(int[] nums, int target)
        {
            try
            {
                int[] answer = new int[2];
                bool exitvar = false;
                int tempo = 0;
                
                for (int i=0; i< nums.Length; i++)
                {
                    tempo = nums[i];
                    for (int x= i+1; x<nums.Length; x++)
                    {
                        tempo = nums[i] + nums[x];

                        //recording the indices because target has been found
                        if (tempo==target)
                        {
                            answer[0] = i + 1;
                            answer[1] = x + 1;
                            exitvar = true;
                            break;
                        }
                        // condition in which a target cant be reached, break that iteration of loop move onto another index
                        if( tempo> target)
                        {
                            break;
                        }
                    }
                    //when the target has been found, loop is ended
                    if(exitvar)
                    {
                        break;
                    }

                }
                //write result of iterations and the answer
                Console.WriteLine(answer[0] + "," + answer[1]);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] items)
        {
            try
            {
                //Creating dictionary to store the values of StudentID and Score, using an artificial iterator
                var dict = new SortedDictionary<int, List<int>>();
                for (int iterator = 0; iterator < items.Length/2; iterator ++)
                {
                    var studentId = items[iterator,0];
                    var score = items[iterator,1];
                    if (dict.ContainsKey(studentId))
                    {
                        dict[studentId].Add(score);
                    }
                    else
                    {
                        dict[studentId] = new List<int>();
                        dict[studentId].Add(score);
                    }
                   
                }

                
                
                // Storing key info in variable ans and walking through the keys
                var keys = dict.Keys;
                var ans = new int[keys.Count][];
                int i = 0;

                foreach (var student in dict)
                {
                    ans[i] = new int[2];
                    ans[i][0] = student.Key;
                    var sum = 0;
                    // Sorting the scores and getting the top 5 values, using decrement to input the item and work backwards
                    var temp = student.Value.ToArray();
                    Array.Sort(temp);
                    var k = 5;
                    for (int j = temp.Length - 1; j >= 0 && k > 0; j--)
                    {
                        
                        sum += temp[j];
                        k--;
                    }
                    ans[i][1] = sum / 5;
                    Console.WriteLine("[{0},{1}]", student.Key, ans[i][1]);
                    i++;
                
                }
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Question 8
        /// <summary>
        //Given an array, rotate the array to the right by k steps, where k is non-negative.
        //Print the Final array after rotation.
        //Example 1:
        //Input: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
        //Output: [5,6,7,1,2,3,4]
        //Explanation:
        //rotate 1 steps to the right: [7,1,2,3,4,5,6]
        //rotate 2 steps to the right: [6,7,1,2,3,4,5]
        //rotate 3 steps to the right: [5,6,7,1,2,3,4]
        //Example 2:
        //Input: nums = [-1,-100,3,99], k = 2
        //Output: [3,99,-1,-100]
        //Explanation: 
        //rotate 1 steps to the right: [99,-1,-100,3]
        //rotate 2 steps to the right: [3,99,-1,-100]
        /// </summary>

        private static void RotateArray(int[] arr, int n)
        {
            try
            {
                bool exitvar = false;
                int[] resultarr = new int[arr.Length];
                int idxstart = 0;
                int idxend= n; //index where the rotated array will be filled from

                while (!exitvar)
                {
                    resultarr[idxend] = arr[idxstart];
                    idxstart++;

                    //Starting the new index to place items at, when the length of the array is exceeded
                    //it begins to wrap
                    idxend = (idxend + 1) % arr.Length;

                    //identifying the rotating point, and rotating the whole array
                    if (idxend == n)
                    {
                        exitvar = true;
                    }

                }
                // printing the  rotated array
                foreach (var item in resultarr)
                {
                    Console.Write(item.ToString() + ", ");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 9
        /// <summary>
        //Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum
        //Example 1:
        //Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        //Output: 6
        //Explanation: [4,-1,2,1] has the largest sum = 6.
        //Example 2:
        //Input: nums = [1]
        //Output: 1
        // Example 3:
        // Input: nums = [5,4,-1,7,8]
        //Output: 23
        /// </summary>

        private static int MaximumSum(int[] arr)
        {
            try
            {
                 
                int currMax = arr[0]; //This tracks current maximum sum from given set
                int topMax = arr[0]; //This tracks the highest sum combination possible
                for (int i = 1; i < arr.Length; ++i)
                {
                    currMax = Math.Max(arr[i], arr[i] + currMax);
                    topMax = Math.Max(currMax, topMax);//Compares current Top Max Sum combo to new current max combo
                }

                return topMax;// after all iterations the highest max sum is returned.

                
            
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        /// <summary>
        //You are given an integer array cost where cost[i] is the cost of ith step on a staircase.Once you pay the cost, you can either climb one or two steps.
        //You can either start from the step with index 0, or the step with index 1.
        //Return the minimum cost to reach the top of the floor.
        //Example 1:
        //Input: cost = [10, 15, 20]
        //Output: 15
        //Explanation: Cheapest is: start on cost[1], pay that cost, and go to the top.

        /// </summary>

        private static int MinCostToClimb(int[] costs)
        {
            try
            {
                if (costs.Length == 1)
                {
                    //The default case for the steps
                    return 0;
                }

                int[] stepcost = new int[costs.Length + 1];
                stepcost[0] = costs[0];
                stepcost[1] = costs[1];

                for (int i = 2; i < stepcost.Length; i++)// iterator starting at 2 which will be used as a starting place to count down to compare stepcost[1] and stepcost[0]
                {   //Calculates the min cost for each step
                    stepcost[i] = Math.Min(stepcost[i - 1], stepcost[i - 2]) + ((i == costs.Length) ? 0 : costs[i]);
                    
                }

                return stepcost[costs.Length];

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


/* Although I feel as though I understand the basics of c# a little bit more than in assignment 1 especially with
 * dictionary and array data structures. I still feel as though the instruction in this course has
 * been minimal in helping me achieve this basic level of understanding which I have gained from
 * resources such as W3schools. This assignment took me all weekend to do which I'm sure was not the desired
 * length of time for this assignment, and I feel like I will only continue to struggle as we move forward.
 * I heavily disagree with the structure of this course.*/