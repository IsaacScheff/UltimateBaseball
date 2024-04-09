using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI InfoText; // Assign in inspector
    public GameObject InfoPanel; // The panel to show/hide
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        } else if (Instance != this) {
            Destroy(gameObject); 
        }
        InfoPanel.SetActive(false);
    }
    public void OnMouseOverCharacter(string characterInfo) {
        InfoText.text = characterInfo;
        InfoPanel.SetActive(true);
    }
    public void OnMouseExitCharacter() {
        InfoPanel.SetActive(false);
    }
}
