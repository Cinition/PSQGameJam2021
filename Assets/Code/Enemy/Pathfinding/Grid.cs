using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Grid<TNode>
{
    private int m_width;
    private int m_height;
    private float m_cellSize;

    private Vector3 m_origin;

    private TNode[,] m_gridArray;

    private bool m_showDebug = true;

    public Grid(int width, int height, float cellSize, Vector3 origin, Func<Grid<TNode>, int, int, TNode> createNode)
    {
        m_width = width;
        m_height = height;
        m_cellSize = cellSize;
        m_origin = origin;

        m_gridArray = new TNode[width, height];

        for (int x = 0; x < m_gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < m_gridArray.GetLength(1); y++)
            {
                m_gridArray[x, y] = createNode(this, x, y);
            }
        }
        if(m_showDebug)
        {
            for (int x = 0; x < m_gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < m_gridArray.GetLength(1); y++)
                {
                    Debug.DrawLine(GetWorldPos(x, y), GetWorldPos(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPos(x, y), GetWorldPos(x + 1, y), Color.white, 100f);
                }
            }
        }
    }

    public void SetShowDebug(bool state)
    {
        m_showDebug = state;
    }
    public bool GetShowDebug()
    {
        return m_showDebug;
    }

    public TNode GetNode(int x, int y)
    {
        if (x < m_width && y < m_height && x >= 0 && y >= 0)
            return m_gridArray[x, y];
        else
            return default(TNode);
    }
    public TNode GetNode(Vector3 worldPos)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        return GetNode(x, y);
    }
    public void SetNode(int x, int y, TNode node)
    {
        if (x < m_width && y < m_height && x >= 0 && y >= 0)
            m_gridArray[x, y] = node;
    }
    public void SetNode(Vector3 worldPos, TNode node)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        SetNode(x, y, node);
    }

    public int GetWidth()
    {
        return m_width;
    }
    public int GetHeight()
    {
        return m_height;
    }
    public float GetCellSize()
    {
        return m_cellSize;
    }
    //Get the world position of a node
    public Vector3 GetWorldPos(int x, int y)
    {
        return new Vector3(x, y) * m_cellSize + m_origin;
    }
    public void GetXY(Vector3 worldPos, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPos - m_origin).x / m_cellSize);
        y = Mathf.FloorToInt((worldPos - m_origin).y / m_cellSize);
    }
}
