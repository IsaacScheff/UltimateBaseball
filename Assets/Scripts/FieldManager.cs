using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldManager : MonoBehaviour {
    public static FieldManager Instance { get; private set; }
    [SerializeField] private BaseAthlete _activePitcher;
    [SerializeField] private BaseAthlete _activeCatcher;
    [SerializeField] private BaseAthlete _activeFirstBase;
    [SerializeField] private BaseAthlete _activeSecondBase;
    [SerializeField] private BaseAthlete _activeThirdBase;
    [SerializeField] private BaseAthlete _activeShortstop;
    [SerializeField] private BaseAthlete _activeLeftField;
    [SerializeField] private BaseAthlete _activeCenterField;
    [SerializeField] private BaseAthlete _activeRightField;
    [SerializeField] private BaseAthlete _batter;
    [SerializeField] private BaseAthlete _whosOnFirst;
    [SerializeField] private BaseAthlete _whosOnSecond;
    [SerializeField] private BaseAthlete _whosOnThird;
    [SerializeField] private bool _playerBatting;
    [SerializeField] private int _inning;
    [SerializeField] private int _outs;
    [SerializeField] private int _strikes;
    [SerializeField] private int _balls;
    [SerializeField] private GameObject FirstBaseman;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        } else if (Instance != this) {
            Destroy(gameObject); 
        }
    }
    void Start() {
        setFirstBaseman();
    }

    private void setFirstBaseman() {
        Instantiate(_whosOnFirst, FirstBaseman.transform.position, Quaternion.identity);
    }
}


