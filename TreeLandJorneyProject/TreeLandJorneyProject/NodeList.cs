using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLandJorneyProject
{
    public class NodeList
    {
		public Node HeadNode { get; set; }
		public Node TailNode { get; set; }

		public List<Node> NodePath { get; set; }
		public List<Node> KnownPath { get; set; }

		private List<Node> _listOfNodes;
		public List<Node> ListOfNodes
		{
			get { return _listOfNodes; }
		}

		private int _numberOfNodes;

		public NodeList()
		{
			HeadNode = null;
			TailNode = null;
			NodePath = new List<Node>();
			KnownPath = new List<Node>();
			_listOfNodes = new List<Node>();
			_numberOfNodes = 0;
		}

		public NodeList(int numberOfNodes)
		{
			HeadNode = null;
			TailNode = null;
			NodePath = new List<Node>();
			KnownPath = new List<Node>();
			_listOfNodes = new List<Node>();
			_numberOfNodes = numberOfNodes;
			CreateListOfNodes();
		}

		public void CreateListOfNodes()
		{
			for(int count =0; count < _numberOfNodes; count++)
			{
				//Create a new Node off of the index.
				var newNode = new Node();
				newNode.Name = count+1;
				_listOfNodes.Add(newNode);
			}
		}

		public void CreatePaths( List<string> pathList)
		{
			//Recurse through the shorter path list to hook up the nodes.
			for (int index = 0; index < pathList.Count; index++)
			{
				var strCopy = pathList[index];
				string[] splitStr = strCopy.Split(" ");

				int nodeIndex = Convert.ToInt32(splitStr[0])-1;
				int nextNodeIndex = Convert.ToInt32(splitStr[1])-1;

				_listOfNodes[nodeIndex].RoadList.Add(_listOfNodes[nextNodeIndex]);
				//_listOfNodes[nextNodeIndex].RoadList.Add(_listOfNodes[nodeIndex]);

			}
		}
    }
}
