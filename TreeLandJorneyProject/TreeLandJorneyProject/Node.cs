using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLandJorneyProject
{
    public class Node
    {
		public int Name { get; set; }
		private List<Node> _nodePath;

		public Node()
		{
			_nodePath = new List<Node>();
			Name = 0;
		}

		public List<Node> RoadList
		{
			get { return _nodePath; }
		}

		public int RoadListCount()
		{
			return _nodePath.Count;
		}

		public void AddNewRoadToRoadList(Node newRoad)
		{
			if(newRoad.Name == Name)
			{
				return;
			}

			if(newRoad == null && Name < 0)
			{
				return;
			}

			if(!_nodePath.Contains(newRoad))
			{
				_nodePath.Add(newRoad);
			}
		}
    }
}
