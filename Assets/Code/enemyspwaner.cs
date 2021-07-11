using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public Transform player;

    public GameObject uistatic;

    int max = 3;
    int min = 1;

    void Start()
    {
        timercount = timer;
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
            x = x + player.position.x;
            y = y + player.position.y;
            int a = 6;

            //cheks sad
            if (uistatic.GetComponent<UIStatic>().sadValue >= 100)
            {
                //decides enemy to spawn
                switch (Random.Range(min, a))
                {
                    case 1:
                        for (int i = 0; i < sadmulti; i++)
                        {
                            Instantiate(happy, new Vector3(x, y, 0), Quaternion.identity);
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
                            Instantiate(angry, new Vector3(x, y, 0), Quaternion.identity);
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
                            Instantiate(exited, new Vector3(x, y, 0), Quaternion.identity);
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
                            Instantiate(scared, new Vector3(x, y, 0), Quaternion.identity);
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
                            Instantiate(sad, new Vector3(x, y, 0), Quaternion.identity);
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
                        Instantiate(happy, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(angry, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(exited, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(scared, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    case 5:
                        for (int i = 0; i < sadmulti; i++)
                        {
                            Instantiate(sad, new Vector3(x, y, 0), Quaternion.identity);
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
}
