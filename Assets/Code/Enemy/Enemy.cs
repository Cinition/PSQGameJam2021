using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] public GameObject m_player;
    [SerializeField] private GameObject m_visual;

    [HideInInspector] public UnityEvent m_deathEvent = new UnityEvent();

    private Rigidbody2D m_rb;

    [Space]

    [Tooltip("The distance from the player the enemy needs to be to trigger death")]
    [SerializeField] private float m_distanceToTriggerDeath = 1.0f;

    [SerializeField] private float m_moveSpeed = 1.0f;
    [SerializeField] private int m_health = 5;
    [SerializeField] private int m_damageToPlayer = 1;


    [SerializeField] private float m_updatePathCooldown = 1f;
    private float m_currentUpdatePathCooldown;

    private List<Vector3> m_path;
    private int m_currentPathIndex = 0;

    [SerializeField] private Vector3 m_movementModifier = Vector3.zero;
    private Vector3 m_moveDir;


    [HideInInspector] public bool m_dead = false;
    private bool m_useDefaultDestroy = true;

    [Header("Audio")]
    public AudioSource m_deathSound;

    [Header("Scoring")]
    [SerializeField] private int m_baseScore = 20;

    void Start()
    {
        UpdatePath();

        m_rb = GetComponent<Rigidbody2D>();
        m_player = GameObject.FindWithTag("Player");
    }

    void Awake()
    {
        m_player = GameObject.FindWithTag("Player");
        UpdatePath();
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!m_dead)
        {
            if(m_path != null)
            {
                if(m_currentPathIndex < m_path.Count)
                {
                    Vector3 vecToNextPos = m_path[m_currentPathIndex] - transform.position;

                    Vector3 newPos = (vecToNextPos.normalized) * m_moveSpeed;

                    m_moveDir = newPos.normalized;

                    newPos += m_movementModifier;
                    transform.position += newPos * Time.deltaTime;

                    //Vector3 force = vecToNextPos.normalized * m_moveSpeed * Time.deltaTime;
                    //m_rb.MovePosition(transform.position + force);

                    if(vecToNextPos.sqrMagnitude <= 0.1f)
                    {
                        m_currentPathIndex++;
                    }
                }
                else
                {

                }
            }

            //if(m_player)
            //{
            //    Vector3 vecToPlayer = m_player.transform.position - transform.position;
            //    if (vecToPlayer.sqrMagnitude <= m_distanceToTriggerDeath)
            //    {
            //        OnDeath();
            //        DamagePlayer();
            //    }
            //}

            //Simple movement. Before pathfinding is a thing
            //if(m_player)
            //{
            //    Vector3 vecToPlayer = m_player.transform.position - transform.position;
            //    Vector3 dirToPlayer = vecToPlayer.normalized;
            //    transform.position += dirToPlayer * m_moveSpeed * Time.deltaTime;

            //    if (vecToPlayer.sqrMagnitude <= m_distanceToTriggerDeath)
            //    {
            //        OnDeath();
            //    }
            //}

            if (m_health <= 0)
            {
                OnDeath();
            }

            if(m_currentUpdatePathCooldown > 0.0f)
            {
                m_currentUpdatePathCooldown -= Time.deltaTime;
            }
            else
            {
                UpdatePath();
            }
        }

        //Destroy object
        if(m_useDefaultDestroy)
        {
            if (m_dead && !m_deathSound.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && !m_dead)
        {
            DamagePlayer();
            OnDeath();
        }
    }
    private void DamagePlayer()
    {
        UIStatic.Instance.HPValue -= m_damageToPlayer;
    }

    public void AddMovement(Vector3 movement, bool resetMovement)
    {
        if(resetMovement)
        {
            m_movementModifier = movement;
        }
        else
        {
            m_movementModifier += movement;
        }
    }

    public Vector3 GetMoveDir()
    {
        return m_moveDir;
    }

    public void TakeDamage(int amount)
    {
        m_health -= amount;
    }

    void OnSpawn()
    {

    }

    void OnDeath()
    {
        m_dead = true;
        if(!m_deathSound.isPlaying)
            m_deathSound.Play();

        m_deathEvent.Invoke();

        m_visual.SetActive(false);

        //add to the player's score
    }

    public void SetUseDefaultDeath(bool state)
    {
        m_useDefaultDestroy = state;
    }

    private void UpdatePath()
    {
        if(Pathfinding.Instance != null)
        {
            m_currentUpdatePathCooldown = m_updatePathCooldown;
            m_path = Pathfinding.Instance.FindPath(transform.position, m_player.transform.position);
            m_currentPathIndex = 1;

            if (m_path != null)
            {
                for (int i = 0; i < m_path.Count; i++)
                {
                    if (i + 1 < m_path.Count)
                        Debug.DrawLine(m_path[i], m_path[i + 1], Color.blue, m_updatePathCooldown);
                }
            }
        }
    }
}
