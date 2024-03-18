using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rd;
    private Rigidbody2D rd2;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;
    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
        rd2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (UnityEngine.Vector2.Distance(target.position, transform.position) < 0.1f)
        {
            pathIndex++;


            if (pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }

            target = LevelManager.main.path[pathIndex];
        }
    }

    private void FixedUpdate()
    {
        UnityEngine.Vector2 direction = (target.position - transform.position).normalized;
        rd2.velocity = direction * moveSpeed;
        // rd.velocity = direction * moveSpeed;
    }

}
