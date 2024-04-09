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
    public string placeholder = "placeholder stat";
    private void OnMouseEnter() {
        // Show the info panel and update the text
        UIManager.Instance.InfoText.text = placeholder;
        UIManager.Instance.InfoPanel.SetActive(true);
    }
}
