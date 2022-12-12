using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{    
    public enum AIType { Patrol, Chase, Guard };
    public AIType type;

    [Header("AI Properties")]
    public float activeRange = 10f;
    public float moveSpeed;
    public float turnSpeed;
    [Header("Attack Properties")]
    public float attackRange = 1.0f;

    public Transform groundCheck;
    Player player;
    int direction = 1;
    void Start()
    {
        player = Player.Instance;
    }

    void Update()
    {
        Think();
    }
    void Think()
    {
        if (type == AIType.Patrol)
        {
            MoveEnemy();

            RaycastHit hit;
            Physics.Raycast(groundCheck.position, Vector3.down, out hit, 1f, LayerMask.GetMask("Ground"));

            if (hit.collider == null)
            {
                TurnEnemy();
            }
            else
            {
               //MoveEnemy();
            }

        }
        else if (type == AIType.Chase)
        {

        }
        else if (type == AIType.Guard)
        {

        }
    }
    void MoveEnemy()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * direction);
    }
    void TurnEnemy()
    {
        direction *= -1;
    }
}
