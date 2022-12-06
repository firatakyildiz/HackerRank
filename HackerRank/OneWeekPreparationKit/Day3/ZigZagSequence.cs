using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.OneWeekPreparationKit.Day3
{
    /// <summary>
    /// Link : https://www.hackerrank.com/challenges/one-week-preparation-kit-zig-zag-sequence/problem
    /// Difficulty : Easy
    /// Solution : The question is broken. It asks you to modify 3 lines, but there is no initial code for C#.
    /// So even if your code is correct, system rejects it since you modified more than 3 lines.
    /// Java has initial code, so I used that to pass.
    /// </summary>
    public static class ZigZagSequence
    {
        public static void Solve()
        {
            var numberOfTestCases = int.Parse(Console.ReadLine());
            for (var i = 0; i < numberOfTestCases; i++)
            {
                var length = int.Parse(Console.ReadLine());
                var arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                // sort array, so that the first half is in place
                Array.Sort(arr);

                // swap middle and last elements
                var mid = (length + 1) / 2 - 1;
                var temp = arr[mid];
                arr[mid] = arr[length - 1];
                arr[length - 1] = temp;

                // reverse right half of the array
                var start = mid + 1;
                var end = length - 2;
                while (start <= end)
                {
                    temp = arr[start];
                    arr[start] = arr[end];
                    arr[end] = temp;
                    start++;
                    end--;
                }
                Console.WriteLine(string.Join(" ", arr));
            }
        }
        /*
            Existing java code, which I modified 3 lines to pass
            Modified lines : 
                - Initial value of mid variable
                - Initial value of ed variable
                - Reassignment of ed variable in while loop

            import java.util.*;
            import java.lang.*;
            import java.io.*;
            import java.math.*;
            public class Main 
            {

                public static void main (String[] args) throws java.lang.Exception {
                    Scanner kb = new Scanner(System.in);
                    int test_cases = kb.nextInt();
                    for(int cs = 1; cs <= test_cases; cs++){
                    int n = kb.nextInt();
                    int a[] = new int[n];
                    for(int i = 0; i < n; i++){
                        a[i] = kb.nextInt();
                    }
                    findZigZagSequence(a, n);
                    }
                }

                public static void findZigZagSequence(int [] a, int n){
                    Arrays.sort(a);
                    int mid = (n + 1)/2 - 1;
                    int temp = a[mid];
                    a[mid] = a[n - 1];
                    a[n - 1] = temp;

                    int st = mid + 1;
                    int ed = n - 2;
                    while(st <= ed){
                        temp = a[st];
                        a[st] = a[ed];
                        a[ed] = temp;
                        st = st + 1;
                        ed = ed - 1;
                    }
                    for(int i = 0; i < n; i++){
                        if(i > 0) System.out.print(" ");
                        System.out.print(a[i]);
                    }
                    System.out.println();
                }
            }
         */
    }
}
