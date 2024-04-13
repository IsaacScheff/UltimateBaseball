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
    public GameObject ScoreboardPanel;
    public TextMeshProUGUI ScoreboardText;
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
        //SetScoreboardText();
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
        DriveButton.onClick.AddListener(delegate {BatOptionSelect(BattingManager.BatOption.Drive); });

        Button BuntButton = Instantiate(ButtonPrefab, ButtonPanel);
        BuntButton.GetComponentInChildren<TextMeshProUGUI>().text = "Bunt";
        BuntButton.onClick.AddListener(delegate {BatOptionSelect(BattingManager.BatOption.Bunt); });
    }
    public void ShowDirectionSelect() {
        Button RightButton = Instantiate(ButtonPrefab, ButtonPanel);
        RightButton.GetComponentInChildren<TextMeshProUGUI>().text = "Right";
        RightButton.onClick.AddListener(delegate {DirectionAimSelect(BattingManager.BatDirection.Right); });

        Button CenterButton = Instantiate(ButtonPrefab, ButtonPanel);
        CenterButton.GetComponentInChildren<TextMeshProUGUI>().text = "Center";
        CenterButton.onClick.AddListener(delegate {DirectionAimSelect(BattingManager.BatDirection.Center); });
        
        Button LeftButton = Instantiate(ButtonPrefab, ButtonPanel);
        LeftButton.GetComponentInChildren<TextMeshProUGUI>().text = "Left";
        LeftButton.onClick.AddListener(delegate {DirectionAimSelect(BattingManager.BatDirection.Left); });
    }
    public void BatOptionSelect(BattingManager.BatOption batOption) {
        BattingManager.Instance.BatOptionPick = batOption;
        DestroyButtons();
        ShowDirectionSelect();
    }
    public void DirectionAimSelect(BattingManager.BatDirection directionAimed) {
        BattingManager.Instance.DirectionAimed = directionAimed;
        DestroyButtons();

        BattingManager.Instance.CalculateHit(FieldManager.Instance.ActivePitcher, FieldManager.Instance.ActiveBatter);
    }

    public void SetScoreboardText() {
        ScoreboardText.text = $"Home: {FieldManager.Instance.HomeScore}  -  Visitors: {FieldManager.Instance.AwayScore}\n\n";
        ScoreboardText.text += $"Inning: {(FieldManager.Instance.TopOfInning ? "T" : "B")}{FieldManager.Instance.InningNumber}\n\n";
        ScoreboardText.text += $"Ball: {FieldManager.Instance.Balls} Strike: {FieldManager.Instance.Strikes} Out: {FieldManager.Instance.Outs}";
    }
}
