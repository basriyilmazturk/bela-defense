using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour {
    [Header("References")]
    [SerializeField] private TextMeshProUGUI currencyUI;
    [SerializeField] private Animator anim;

    private bool isMenuOpen = false;

    public void ToggleMenu() {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("isMenuOpen", isMenuOpen);
    }

    private void OnGUI() {
        currencyUI.text = LevelManager.main.currency.ToString();
    }


}
