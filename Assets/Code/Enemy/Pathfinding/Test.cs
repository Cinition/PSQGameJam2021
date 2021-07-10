using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Pathfinding m_pathfinding;

    [SerializeField] private GameObject m_player;

    [SerializeField] private Vector3 m_origin;
    [SerializeField] private float m_cellSize;

    void Start()
    {
        m_pathfinding = new Pathfinding(10, 10, m_cellSize, m_origin);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            m_pathfinding.GetGrid().GetXY(mousePos, out int x, out int y);

            List<Node> path = m_pathfinding.FindPath(0, 0, x, y);

            if(path != null)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    if (i + 1 < path.Count)
                        Debug.DrawLine( m_pathfinding.GetGrid().GetWorldPos(path[i].x, path[i].y)           + new Vector3(0.5f, 0.5f, 0f) * m_cellSize, 
                                        m_pathfinding.GetGrid().GetWorldPos(path[i + 1].x, path[i + 1].y)   + new Vector3(0.5f, 0.5f, 0f) * m_cellSize, Color.blue, 5f);
                }
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            m_pathfinding.GetGrid().GetXY(mousePos, out int x, out int y);

            if(m_pathfinding.GetGrid().GetNode(x, y).GetIsTraversable())
                m_pathfinding.GetGrid().GetNode(x, y).SetTraverseType(Node.TRAVERSE_TYPE.OBSTACLE);
            else
                m_pathfinding.GetGrid().GetNode(x, y).SetTraverseType(Node.TRAVERSE_TYPE.TRAVERSABLE);
        }
    }
}
