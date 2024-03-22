using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Plot : MonoBehaviour {
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color howerColor;
    private GameObject tower;
    private Color startColor;

    private void Start() {
        startColor = sr.color;
        Debug.Log("Start");
    }

    private void OnMouseEnter() {
        sr.color = howerColor;
    }

    private void OnMouseExit() {
        sr.color = startColor;
    }

    private void OnMouseDown() {
        if (tower != null) {
            return;
        }

        Tower towerToBuild = BuildManager.main.GetSelectedTower();
        if (towerToBuild.cost > LevelManager.main.currency) {
            Debug.Log("not enough currency");
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);
        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
    }
}
