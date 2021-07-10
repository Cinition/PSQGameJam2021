using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public enum TRAVERSE_TYPE
    {
        TRAVERSABLE = 0,
        OBSTACLE
    }

    private Grid<Node> m_grid; 

    public int x;
    public int y;

    public int m_gCost;
    public int m_hCost;
    public int m_fCost;

    public Node m_parentNode;

    private TRAVERSE_TYPE m_traverseType = TRAVERSE_TYPE.TRAVERSABLE;

    public Node(Grid<Node> grid, int x, int y)
    {
        m_grid = grid;

        this.x = x;
        this.y = y;
    }

    public void CalculateFCost()
    {
        m_fCost = m_gCost + m_hCost;
    }

    public bool GetIsTraversable()
    {
        if (m_traverseType == TRAVERSE_TYPE.TRAVERSABLE)
            return true;
        return false;
    }

    public void SetTraverseType(TRAVERSE_TYPE type)
    {
        m_traverseType = type;

        Debug.Log("Node: " + x + ", " + y);

        if(type == TRAVERSE_TYPE.OBSTACLE)
        {
            Vector3 pos = m_grid.GetWorldPos(x, y);
            Vector3 pos2 = m_grid.GetWorldPos(x + 1, y + 1);
            Debug.DrawLine(pos, pos2, Color.red, 100f);
        }
        else
        {
            Vector3 pos = m_grid.GetWorldPos(x, y);
            Vector3 pos2 = m_grid.GetWorldPos(x + 1, y + 1);
            Debug.DrawLine(pos, pos2, Color.green, 100f);
        }
    }
}
