using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float rotSpeed = 90f;
    public float moveSpeed = 3f;
    public float viewDistance = 10f;

    private Transform player;
    private bool isChasing = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isChasing)
        {
            //rotate to search
            transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);

            //continue to raycast for player
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, viewDistance);

            if (hit.collider != null)
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);

                if (hit.collider.CompareTag("Player"))
                {
                    player = hit.collider.transform;
                    isChasing = true;
                }
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + transform.right * viewDistance, Color.green);
            }
        }
        else
        {
            //check if player is still visible
            if (player != null)
            {
                Vector2 directionToPlayer = (player.position - transform.position).normalized;
                RaycastHit2D lineOfSight = Physics2D.Raycast(transform.position, directionToPlayer, viewDistance);

                if (lineOfSight.collider != null)
                {
                    if (!lineOfSight.collider.CompareTag("Player"))
                    {
                        //view is blocked
                        isChasing = false;
                        return;
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isChasing && player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 newPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
