using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAthlete : MonoBehaviour {
    [SerializeField] private int _baseHealth;
    [SerializeField] private int _baseSpeed;
    [SerializeField] private int _baseBatAccuracy;
    [SerializeField] private int _baseBatPower;
    [SerializeField] private int _basePitching;
    [SerializeField] private int _baseCatching;
    [SerializeField] private int _baseFielding;
    [SerializeField] private int _baseStamina;
    public string StatBlock;
    void Start() {
        StatBlock = $"Health: {_baseHealth}\n";
        StatBlock += $"Stamina: {_baseStamina}\n";
        StatBlock += $"Speed: {_baseSpeed}\n";
        StatBlock += $"Bat Accuracy: {_baseBatAccuracy}\n";
        StatBlock += $"Bat Power: {_baseBatPower}\n";
        StatBlock += $"Pitching: {_basePitching}\n";
        StatBlock += $"Catching: {_baseCatching}\n";
        StatBlock += $"Fielding: {_baseFielding}\n";
    }
    private void OnMouseEnter() {
        // Show the info panel and update the text
        UIManager.Instance.PlayerInfoText.text = StatBlock;
        UIManager.Instance.PlayerInfoPanel.SetActive(true);
    }
    private void OnMouseExit() {
        // Hide the info panel
        UIManager.Instance.PlayerInfoPanel.SetActive(false);
    }
}
