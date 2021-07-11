using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class enemyspwaner : MonoBehaviour
{

    public float timer = 5f;
    private float timercount = 0f;

    public float distance = 5f;

    public int sadmulti = 3;

    public float saddistance = 1f;

    public GameObject happy;
    public GameObject angry;
    public GameObject exited;
    public GameObject scared;
    public GameObject sad;

    public GameObject player;
    Transform playerTransform;

    public Tilemap tilemap;
    BoundsInt size;
    TileBase[] allTiles;

    int max = 3;
    int min = 1;

    void Start()
    {
        timercount = timer;
        playerTransform = player.transform;

        size = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(size);

    }

    void Update()
    {

        timercount -= 1 * Time.deltaTime;
        if (timercount < 0)
        {
            timercount = timer;

            //decides position
            float x = 0f;
            float y = 0f;
            if (Random.Range(min, max) == 1)
            {
                if (Random.Range(min, max) == 1)
                {
                    y = distance;
                }
                else
                {
                    y = -distance;
                }
                x = Random.Range(-distance, distance);
            }
            else
            {
                if (Random.Range(min, max) == 1)
                {
                    x = distance;
                }
                else
                {
                    x = -distance;
                }
                y = Random.Range(-distance, distance);
            }
            x = x + playerTransform.position.x;
            y = y + playerTransform.position.y;
            int a = 6;

            //cheks sad
            if (UIStatic.Instance.GetComponent<UIStatic>().sadValue >= 100)
            {
                //decides enemy to spawn
                switch (Random.Range(min, a))
                {
                    case 1:
                        for (int i = 0; i < sadmulti; i++)
                        {
                            EnemyInstantiate(happy, new Vector3(x, y, 0));
                            if (Random.Range(min, max) == 1)
                            {
                                x = x + saddistance;
                            }
                            else
                            {
                                y = y + saddistance;
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < sadmulti; i++)
                        {
                            EnemyInstantiate(angry, new Vector3(x, y, 0));
                            if (Random.Range(min, max) == 1)
                            {
                                x = x + saddistance;
                            }
                            else
                            {
                                y = y + saddistance;
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < sadmulti; i++)
                        {
                            EnemyInstantiate(exited, new Vector3(x, y, 0));
                            if (Random.Range(min, max) == 1)
                            {
                                x = x + saddistance;
                            }
                            else
                            {
                                y = y + saddistance;
                            }
                        }
                        break;
                    case 4:
                        for (int i = 0; i < sadmulti; i++)
                        {
                            EnemyInstantiate(scared, new Vector3(x, y, 0));
                            if (Random.Range(min, max) == 1)
                            {
                                x = x + saddistance;
                            }
                            else
                            {
                                y = y + saddistance;
                            }
                        }
                        break;
                    case 5:
                        for (int i = 0; i < sadmulti; i++)
                        {
                            EnemyInstantiate(sad, new Vector3(x, y, 0));
                            if (Random.Range(min, max) == 1)
                            {
                                x = x + saddistance;
                            }
                            else
                            {
                                y = y + saddistance;
                            }
                        }
                        break;
                }
            }
            else
            {
                //decides enemy to spawn
                switch (Random.Range(min, a))
                {
                    case 1:
                        EnemyInstantiate(happy, new Vector3(x, y, 0));
                        break;
                    case 2:
                        EnemyInstantiate(angry, new Vector3(x, y, 0));
                        break;
                    case 3:
                        EnemyInstantiate(exited, new Vector3(x, y, 0));
                        break;
                    case 4:
                        EnemyInstantiate(scared, new Vector3(x, y, 0));
                        break;
                    case 5:
                        for (int i = 0; i < sadmulti; i++)
                        {
                            EnemyInstantiate(sad, new Vector3(x, y, 0));
                            if (Random.Range(min, max) == 1)
                            {
                                x = x + saddistance;
                            }
                            else
                            {
                                y = y + saddistance;
                            }
                        }
                        break;
                }
            }
        }
    }

    void EnemyInstantiate(GameObject enemy, Vector3 spawnPosition)
    {
        Vector3Int localPlace = new Vector3Int(Random.Range(size.xMin, size.xMax), Random.Range(size.yMin, size.yMax), (int)tilemap.transform.position.y);
        Vector3 place = tilemap.CellToWorld(localPlace);

        while (!tilemap.HasTile(localPlace))
        {
            localPlace = new Vector3Int(Random.Range(size.xMin, size.xMax), Random.Range(size.yMin, size.yMax), (int)tilemap.transform.position.y);
            place = tilemap.CellToWorld(localPlace);
        }

        Instantiate(enemy, place, Quaternion.identity);
    }
}
