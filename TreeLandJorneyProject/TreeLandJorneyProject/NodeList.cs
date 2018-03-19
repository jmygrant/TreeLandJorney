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

		public int FindPath(List<int> knownPath)
		{
			int foundPath = 0;
			List<int> visitPath = new List<int>();
			for(int index = 0; index < _numberOfNodes; index ++)
			{
				if(knownPath[index] >0)
				{
					VisitNode(GetNodeAtIndex(knownPath[index]), visitPath);
					if(visitPath.Count == _numberOfNodes)
					{
						foundPath++;
					}
				}
				for (int i = 0; i < visitPath.Count; i++)
				{
					Console.Write(string.Format("{0}, ", visitPath[i]));
				}
				Console.Write("\n");
			}
			//Returns the count of all routes that can be found.
			return foundPath;
		}

		public void VisitNode(Node node, List<int> visitPath)
		{
			if(visitPath.Count == _numberOfNodes)
			{
				return;
			}
			//Mark Node as visited
			if(!visitPath.Contains(node.Name))
			{
				visitPath.Add(node.Name);
			}

			if(node.RoadListCount() > 0)
			{
				for(int i=0; i<node.RoadListCount(); i++)
				{
					VisitNode(node.RoadList[i], visitPath);
				}
			}
			else
			{
				return;
			}
		}

		public Node GetNodeAtIndex(int index)
		{
			for(int counter = 0; counter < _listOfNodes.Count; counter++)
			{
				if(_listOfNodes[counter].Name == index)
				{
					return _listOfNodes[counter];
				}
			}
			return null;
		}
    }
}
