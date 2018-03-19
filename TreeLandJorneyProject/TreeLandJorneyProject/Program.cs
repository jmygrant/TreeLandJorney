using System;
using System.Collections.Generic;

namespace TreeLandJorneyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			//Create NodeList.
			var newNodeList = new NodeList(5);

			//Creating the PathList
			var newPathList = new List<string>();
			newPathList.Add("1 2");
			newPathList.Add("1 3");
			newPathList.Add("3 4");
			newPathList.Add("3 5");

			//Call the pathListfunction.
			newNodeList.CreatePaths(newPathList);

			var testList = new List<int>() { 1, 0, 0, 0, 0 };

			newNodeList.FindPath(testList);
        }
    }
}
