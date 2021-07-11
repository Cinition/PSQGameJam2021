using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PathfindingManager : MonoBehaviour
{
    Pathfinding m_pathfinding;

    //[SerializeField] private GameObject m_player;

    [SerializeField] private Texture2D m_texture;

    [SerializeField] private Vector3 m_origin = new Vector3(-10, -10, 0);
    [SerializeField] private float m_cellSize = 1;

    [SerializeField] private int m_mapWidth = 20;
    [SerializeField] private int m_mapHeight = 20;

    [SerializeField] private bool m_showDebug = true;

    [SerializeField] private SavePath m_savePath = SavePath.Slot0;

    public enum SavePath
    {
        Slot0 = 0,
        Slot1, 
        SLot2, 
        Slot3, 
        Slot4
    }

    private string[] m_savePathStrings = 
    { 
        "/../Assets/Code/Enemy/Pathfinding/MapSlot0.png", 
        "/../Assets/Code/Enemy/Pathfinding/MapSlot1.png", 
        "/../Assets/Code/Enemy/Pathfinding/MapSlot2.png", 
        "/../Assets/Code/Enemy/Pathfinding/MapSlot3.png", 
        "/../Assets/Code/Enemy/Pathfinding/MapSlot4.png", 
    };

    //[SerializeField] private Terrain[] m_map;


    void Start()
    {
        m_pathfinding = new Pathfinding(m_mapWidth, m_mapHeight, m_cellSize, m_origin);
        m_pathfinding.GetGrid().SetShowDebug(true);

        if (Directory.Exists(Application.dataPath + m_savePathStrings[(int)m_savePath]))
        {
            LoadTexture();

            for (int x = 0; x < m_pathfinding.GetGrid().GetWidth(); x++)
            {
                for (int y = 0; y < m_pathfinding.GetGrid().GetHeight(); y++)
                {
                    Node.TRAVERSE_TYPE type = m_texture.GetPixel(x, y) == Color.black ? Node.TRAVERSE_TYPE.TRAVERSABLE : Node.TRAVERSE_TYPE.OBSTACLE;
                    m_pathfinding.GetGrid().GetNode(x, y).SetTraverseType(type);
                }
            }
        }
    }

    void Update()
    {
        if(m_showDebug)
        {
            //Only runtime obstacles for now
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = -Camera.main.transform.position.z;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                m_pathfinding.GetGrid().GetXY(mousePos, out int x, out int y);

                if (m_pathfinding.GetGrid().GetNode(x, y).GetIsTraversable())
                    m_pathfinding.GetGrid().GetNode(x, y).SetTraverseType(Node.TRAVERSE_TYPE.OBSTACLE);
                else
                    m_pathfinding.GetGrid().GetNode(x, y).SetTraverseType(Node.TRAVERSE_TYPE.TRAVERSABLE);
            }

            if(Input.GetKeyDown(KeyCode.P))
            {
                SaveTexture();
            }
            if(Input.GetKeyDown(KeyCode.L))
            {
                LoadTexture();
            }
        }
    }

    void SaveTexture()
    {
        m_texture = new Texture2D(m_mapWidth, m_mapHeight, TextureFormat.R8, false);

        Sprite sprite = Sprite.Create(m_texture, new Rect(transform.position, new Vector2(m_mapWidth, m_mapHeight)), new Vector2(5, 5));
        GetComponent<SpriteRenderer>().sprite = sprite;
        //GetComponent<Renderer>().material.mainTexture = m_texture;

        for (int y = 0; y < m_texture.height; y++)
        {
            for (int x = 0; x < m_texture.width; x++)
            {
                Color color = m_pathfinding.GetGrid().GetNode(x, y).GetIsTraversable() ? new Color(0, 0, 0) : new Color(8, 0, 0);
                m_texture.SetPixel(x, y, color);
            }
        }
        m_texture.Apply();

        byte[] bytes = m_texture.EncodeToPNG();

        File.WriteAllBytes(Application.dataPath + m_savePathStrings[(int)m_savePath], bytes);
    }

    void LoadTexture()
    {
        byte[] bytes = File.ReadAllBytes(Application.dataPath + m_savePathStrings[(int)m_savePath]);

        m_texture = new Texture2D(m_mapWidth, m_mapHeight, TextureFormat.R8, false);

        m_texture.LoadImage(bytes);

        Sprite sprite = Sprite.Create(m_texture, new Rect(transform.position, new Vector2(m_mapWidth, m_mapHeight)), new Vector2(5, 5));
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
