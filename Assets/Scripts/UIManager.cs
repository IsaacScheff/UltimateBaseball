using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI InfoText; 
    public GameObject InfoPanel; 
    public Button ButtonPrefab;
    public Transform ButtonPanel; 
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
