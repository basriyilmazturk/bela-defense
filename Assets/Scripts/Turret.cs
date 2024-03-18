using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotation;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;

    private void OnDrawGizmosSelected() {
        Debug.Log("Gizmo Selected");
    }
}
