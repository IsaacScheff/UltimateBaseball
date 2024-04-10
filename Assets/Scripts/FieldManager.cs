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
    [SerializeField] private GameObject _batting;
    [SerializeField] private GameObject _firstBase;
    [SerializeField] private GameObject _secondBase;
    [SerializeField] private GameObject _thirdBase;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        } else if (Instance != this) {
            Destroy(gameObject); 
        }
    }
    public void SetDefense() {
        BaseAthlete[] lineup = _playerBatting ? TeamManager.Instance.ComputerLineUp : TeamManager.Instance.PlayerLineUp;
    
        // Assuming the lineup array is 0-indexed and the first 9 are the positions needed
        _activePitcher = lineup[0];
        _activeCatcher = lineup[1];
        _activeFirstBase = lineup[2];
        _activeSecondBase = lineup[3];
        _activeThirdBase = lineup[4];
        _activeShortstop = lineup[5];
        _activeLeftField = lineup[6];
        _activeCenterField = lineup[7];
        _activeRightField = lineup[8];

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

    public void SetOffense() {
        if (_batter != null) {
            Instantiate(_batter, _batting.transform.position, Quaternion.identity);
        }
        if (_whosOnFirst != null) {
            Instantiate(_whosOnFirst, _firstBase.transform.position, Quaternion.identity);
        }
        if (_whosOnSecond != null) {
            Instantiate(_whosOnSecond, _secondBase.transform.position, Quaternion.identity);
        }
        if (_whosOnThird != null) {
            Instantiate(_whosOnThird, _thirdBase.transform.position, Quaternion.identity);
        }
    }
}


