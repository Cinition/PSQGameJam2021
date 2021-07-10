using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingManager : MonoBehaviour
{
    Pathfinding m_pathfinding;

    //[SerializeField] private GameObject m_player;

    [SerializeField] private Vector3 m_origin = new Vector3(-10, -10, 0);
    [SerializeField] private float m_cellSize = 1;

    [SerializeField] private int m_mapWidth = 20;
    [SerializeField] private int m_mapHeight = 20;

    void Start()
    {
        m_pathfinding = new Pathfinding(m_mapWidth, m_mapHeight, m_cellSize, m_origin);
    }

    void Update()
    {
        //Only runtime obstacles for now
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            m_pathfinding.GetGrid().GetXY(mousePos, out int x, out int y);

            if (m_pathfinding.GetGrid().GetNode(x, y).GetIsTraversable())
                m_pathfinding.GetGrid().GetNode(x, y).SetTraverseType(Node.TRAVERSE_TYPE.OBSTACLE);
            else
                m_pathfinding.GetGrid().GetNode(x, y).SetTraverseType(Node.TRAVERSE_TYPE.TRAVERSABLE);
        }
    }
}
