using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI PlayerInfoText; 
    public GameObject PlayerInfoPanel; 
    public Button ButtonPrefab;
    public Transform ButtonPanel;
    public TextMeshProUGUI GameInfoText; 
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        } else if (Instance != this) {
            Destroy(gameObject); 
        }
        PlayerInfoPanel.SetActive(false);
        PlayBall();
    }
    public void OnMouseOverCharacter(string characterInfo) {
        PlayerInfoText.text = characterInfo;
        PlayerInfoPanel.SetActive(true);
    }
    public void OnMouseExitCharacter() {
        PlayerInfoPanel.SetActive(false);
    }
    public void PlayBall() {
        GameInfoText.text = "Play Ball!";
        Button playBallButton = Instantiate(ButtonPrefab, ButtonPanel);
        playBallButton.transform.localPosition = Vector3.zero;
        playBallButton.GetComponentInChildren<TextMeshProUGUI>().text = "Play Ball!";
        playBallButton.onClick.AddListener(_playBallClicked);
    }
    private void _playBallClicked() {
        Debug.Log("Let the game begin!");
        DestroyButtons();
    }
    public void DestroyButtons() {
        foreach (Transform child in ButtonPanel) {
            Destroy(child.gameObject);
        }
    }
}
