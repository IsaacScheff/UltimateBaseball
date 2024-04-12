using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
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
        playBallButton.GetComponentInChildren<TextMeshProUGUI>().text = "Play Ball!";
        playBallButton.onClick.AddListener(_playBallClicked);
    }
    private void _playBallClicked() {
        Debug.Log("Let the game begin!");
        DestroyButtons();
        ShowBatterOptions();
    }
    public void DestroyButtons() {
        foreach (Transform child in ButtonPanel) {
            Destroy(child.gameObject);
        }
    }
    public void ShowBatterOptions() {
        //should I have a make button function? I repeat this logic a few times in this class already
        Button SmashButton = Instantiate(ButtonPrefab, ButtonPanel);
        SmashButton.GetComponentInChildren<TextMeshProUGUI>().text = "Smash!";
        SmashButton.onClick.AddListener(delegate {BatOptionSelect(BattingManager.BatOption.Smash); });
        Button DriveButton = Instantiate(ButtonPrefab, ButtonPanel);
        DriveButton.GetComponentInChildren<TextMeshProUGUI>().text = "Drive";
        Button BuntButton = Instantiate(ButtonPrefab, ButtonPanel);
        BuntButton.GetComponentInChildren<TextMeshProUGUI>().text = "Bunt";
    }
    public void ShowDirectionSelect() {
        Debug.Log("Show direction options");
    }
    public void BatOptionSelect(BattingManager.BatOption BatOption) {
        BattingManager.Instance.BatOptionPick = BatOption;
        DestroyButtons();
        ShowDirectionSelect();
    }
}
