using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private const int STRAIGHT_COST = 10;
    private const int DIAGONAL_COST = 14;

    public static Pathfinding Instance { get; private set; }

    private Grid<Node> m_grid;

    private List<Node> m_openList;
    private List<Node> m_closedList;

    private Vector3 m_origin;

    public Pathfinding(int width, int height, float cellSize, Vector3 origin)
    {
        if(Instance == null)
            Instance = this;
        m_grid = new Grid<Node>(width, height, cellSize, origin, (Grid<Node> grid, int x, int y) => new Node(grid, x, y));

        m_origin = origin;
    }

    public Grid<Node> GetGrid()
    {
        return m_grid;
    }

    public List<Vector3> FindPath(Vector3 startWorldPos, Vector3 endWorldPos)
    {
        m_grid.GetXY(startWorldPos, out int startX, out int startY);
        m_grid.GetXY(endWorldPos, out int endX, out int endY);

        if(startX == endX && startY == endY)
            return null;

        List<Node> path = FindPath(startX, startY, endX, endY);

        if (path == null)
            return null;
        else
        {
            List<Vector3> vectorPath = new List<Vector3>();

            foreach (Node node in path)
            {
                vectorPath.Add(new Vector3(node.x, node.y) * m_grid.GetCellSize() + new Vector3(0.5f, 0.5f, 0) * m_grid.GetCellSize() + m_origin);
            }
            return vectorPath;
        }
    }

    public List<Node> FindPath(int startX, int startY, int endX, int endY)
    {
        Node startNode = m_grid.GetNode(startX, startY);
        Node endNode = m_grid.GetNode(endX, endY);

        m_openList = new List<Node>() { startNode };
        m_closedList = new List<Node>();

        for (int x = 0; x < m_grid.GetWidth(); x++)
        {
            for (int y = 0; y < m_grid.GetHeight(); y++)
            {
                Node node = m_grid.GetNode(x, y);
                node.m_parentNode = null;
                node.m_gCost = int.MaxValue;
                node.CalculateFCost();
            }
        }

        startNode.m_gCost = 0;
        startNode.m_hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (m_openList.Count > 0)
        {
            Node currentNode = GetLowestFCostNode(m_openList);
            if(currentNode == endNode)
            {
                Debug.Log("Reached end node");
                return CalculatePath(endNode, startNode);
            }

            m_openList.Remove(currentNode);
            m_closedList.Add(currentNode);

            foreach (Node neighbourNode in GetNeighbours(currentNode))
            {
                if (m_closedList.Contains(neighbourNode)) continue;

                int newGCost = currentNode.m_gCost + CalculateDistanceCost(currentNode, neighbourNode);
                if(newGCost < neighbourNode.m_gCost)
                {
                    neighbourNode.m_parentNode = currentNode;
                    neighbourNode.m_gCost = newGCost;
                    neighbourNode.m_hCost = CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if(!m_openList.Contains(neighbourNode))
                    {
                        m_openList.Add(neighbourNode);
                    }
                }
            }
        }
        Debug.Log("Open list is out of nodes :<");
        return null;
    }

    private List<Node> GetNeighbours(Node currentNode)
    {
        List<Node> neighbours = new List<Node>();
        Node testNode;

        if(currentNode.x - 1 >= 0)
        {
            //Nodes to the left
            testNode = m_grid.GetNode(currentNode.x - 1, currentNode.y);
            if (testNode.GetIsTraversable())
                neighbours.Add(testNode);

            if (currentNode.y - 1 >= 0)
            { 
                testNode = m_grid.GetNode(currentNode.x - 1, currentNode.y - 1);
                if (testNode.GetIsTraversable())
                    neighbours.Add(testNode);
            }
            if (currentNode.y + 1 < m_grid.GetHeight())
            { 
                testNode = m_grid.GetNode(currentNode.x - 1, currentNode.y + 1);
                if (testNode.GetIsTraversable())
                    neighbours.Add(testNode);
            } 
        }
        if(currentNode.x + 1 < m_grid.GetWidth())
        {
            //Nodes to the right
            testNode = m_grid.GetNode(currentNode.x + 1, currentNode.y);
            if(testNode.GetIsTraversable())
                neighbours.Add(testNode);

            if (currentNode.y - 1 >= 0)
            {
                testNode = m_grid.GetNode(currentNode.x + 1, currentNode.y - 1);
                if (testNode.GetIsTraversable())
                    neighbours.Add(testNode);
            }
            if (currentNode.y + 1 < m_grid.GetHeight())
            { 
                testNode = m_grid.GetNode(currentNode.x + 1, currentNode.y + 1);
                if (testNode.GetIsTraversable())
                    neighbours.Add(testNode);
            } 
        }
        //Down and up node
        if (currentNode.y - 1 >= 0)
        { 
            testNode = m_grid.GetNode(currentNode.x, currentNode.y - 1);
            if (testNode.GetIsTraversable())
                neighbours.Add(testNode);
        }
        if (currentNode.y + 1 < m_grid.GetHeight())
        { 
            testNode = m_grid.GetNode(currentNode.x, currentNode.y + 1);
            if (testNode.GetIsTraversable())
                neighbours.Add(testNode);
        } 

        return neighbours;
    }

    private List<Node> CalculatePath(Node endNode, Node startNode)
    {
        List<Node> path = new List<Node>();

        Node currentNode = endNode;
        while (currentNode.m_parentNode != null)
        {
            path.Add(currentNode);
            currentNode = currentNode.m_parentNode;
        }
        path.Add(startNode);
        path.Reverse();
        return path;
    }

    private int CalculateDistanceCost(Node a, Node b)
    {
        int distanceX = Mathf.Abs(a.x - b.x);
        int distanceY = Mathf.Abs(a.y - b.y);
        int straight = Mathf.Abs(distanceX - distanceY);
        return DIAGONAL_COST * Mathf.Min(distanceX, distanceY) + STRAIGHT_COST * straight;
    }

    private Node GetLowestFCostNode(List<Node> nodeList)
    {
        Node lowestFCostNode = nodeList[0];
        for (int i = 1; i < nodeList.Count; i++)
        {
            if(nodeList[i].m_fCost < lowestFCostNode.m_fCost)
            {
                lowestFCostNode = nodeList[i];
            }
        }
        return lowestFCostNode;
    }
}
