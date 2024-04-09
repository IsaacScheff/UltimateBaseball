using UnityEngine;
using TMPro; 

public class DisplayStats : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _infoText; // Assign in inspector
    [SerializeField] private GameObject _infoPanel; // The panel to show/hide

    private void Awake() {
        // Initially hide the panel
        _infoPanel.SetActive(false);
    }

    public void OnMouseOverCharacter(string characterInfo) {
        _infoText.text = characterInfo;
        _infoPanel.SetActive(true);
    }

    public void OnMouseExitCharacter() {
        _infoPanel.SetActive(false);
    }
}
