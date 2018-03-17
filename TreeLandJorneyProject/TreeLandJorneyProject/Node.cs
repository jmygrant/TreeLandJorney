using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLandJorneyProject
{
    public class Node
    {
		public int Name { get; set; }
		private List<int> roadList;

		public Node()
		{
			roadList = new List<int>();
		}

		public List<int> RoadList
		{
			get { return roadList; }
		}

		public int RoadListCount()
		{
			return roadList.Count;
		}

		public void AddNewRoadToRoadList(int newRoad)
		{
			if(newRoad == Name)
			{
				return;
			}

			if(newRoad < 0)
			{
				return;
			}

			if(!roadList.Contains(newRoad))
			{
				roadList.Add(newRoad);
			}
		}
    }
}
