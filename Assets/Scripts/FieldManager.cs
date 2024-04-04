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
    [SerializeField] private GameObject _firstBaseman;
    [SerializeField] private GameObject _secondBaseman;
    [SerializeField] private GameObject _thirdBaseman;
    [SerializeField] private GameObject _shortstop;
    [SerializeField] private GameObject _pitcher;
    [SerializeField] private GameObject _catcher;
    [SerializeField] private GameObject _leftField;
    [SerializeField] private GameObject _centerField;
    [SerializeField] private GameObject _rightField;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        } else if (Instance != this) {
            Destroy(gameObject); 
        }
    }
    void Start() {
        setDefense();
    }

    private void setDefense() {
        Instantiate(_activeFirstBase, _firstBaseman.transform.position, Quaternion.identity);
        Instantiate(_activeSecondBase, _secondBaseman.transform.position, Quaternion.identity);
        Instantiate(_activeThirdBase, _thirdBaseman.transform.position, Quaternion.identity);
        Instantiate(_activeShortstop, _shortstop.transform.position, Quaternion.identity);
        Instantiate(_activePitcher, _pitcher.transform.position, Quaternion.identity);
        Instantiate(_activeCatcher, _catcher.transform.position, Quaternion.identity);
        Instantiate(_activeLeftField, _leftField.transform.position, Quaternion.identity);
        Instantiate(_activeCenterField, _centerField.transform.position, Quaternion.identity);
        Instantiate(_activeRightField, _rightField.transform.position, Quaternion.identity);
    }
}


