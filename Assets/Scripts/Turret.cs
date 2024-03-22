using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Transform turretRotation;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float bps = 1f; // bullets Per Second


    private Transform target;
    private float timeUntilFire;

    private void Update() {
        if (target == null) {
            findTarget();
            return;
        }

        RotateTowardsTarget();

        if (!CheckTargetIsInRange()) {
            target = null;
        }
        else {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire > 1f / bps) {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    // private void OnDrawGizmosSelected() {
    //     Handles.color = Color.cyan;
    //     Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    // }

    private bool CheckTargetIsInRange() {
        return Vector2.Distance(target.position, transform.position) < targetingRange;
    }

    private void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }

    private void findTarget() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(
            transform.position,
            targetingRange,
            (Vector2)transform.position,
            0f,
            enemyMask
        );

        if (hits.Length > 0) {
            target = hits[0].transform;
        }
    }

    private void RotateTowardsTarget() {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotation.rotation = Quaternion.RotateTowards(turretRotation.rotation, targetRotation, rotationSpeed * Time.deltaTime);// targetRotation;
    }

}
