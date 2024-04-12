using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldManager : MonoBehaviour {
    public static FieldManager Instance { get; private set; }
    public StateOfPlay stateOfPlay;
    [SerializeField] private BaseAthlete _activePitcher;
    [SerializeField] private BaseAthlete _activeCatcher;
    [SerializeField] private BaseAthlete _activeFirstBase;
    [SerializeField] private BaseAthlete _activeSecondBase;
    [SerializeField] private BaseAthlete _activeThirdBase;
    [SerializeField] private BaseAthlete _activeShortstop;
    [SerializeField] private BaseAthlete _activeLeftField;
    [SerializeField] private BaseAthlete _activeCenterField;
    [SerializeField] private BaseAthlete _activeRightField;
    [SerializeField] private BaseAthlete _activeBatter;
    [SerializeField] private BaseAthlete _whosOnFirst;
    [SerializeField] private BaseAthlete _whosOnSecond;
    [SerializeField] private BaseAthlete _whosOnThird;
    public BaseAthlete ActivePitcher { get { return _activePitcher; } }
    public BaseAthlete ActiveCatcher { get { return _activeCatcher; } }
    public BaseAthlete ActiveFirstBase { get { return _activeFirstBase; } }
    public BaseAthlete ActiveSecondBase { get { return _activeSecondBase; } }
    public BaseAthlete ActiveThirdBase { get { return _activeThirdBase; } }
    public BaseAthlete ActiveShortstop { get { return _activeShortstop; } }
    public BaseAthlete ActiveLeftField { get { return _activeLeftField; } }
    public BaseAthlete ActiveCenterField { get { return _activeCenterField; } }
    public BaseAthlete ActiveRightField { get { return _activeRightField; } }
    public BaseAthlete ActiveBatter { get { return _activeBatter; } }
    public BaseAthlete WhosOnFirst { get { return _whosOnFirst; } }
    public BaseAthlete WhosOnSecond { get { return _whosOnSecond; } }
    public BaseAthlete WhosOnThird { get { return _whosOnThird; } }
    [SerializeField] private bool _playerBatting;
    //[SerializeField] private int _inningNumber;
    //[SerializeField] private bool _topOfInning = true;
    [SerializeField] private bool _playerHomeTeam; //true if player is the home team
    [SerializeField] private int _outs;
    [SerializeField] private int _strikes;
    [SerializeField] private int _balls;
    [SerializeField] private int _homeScore;
    [SerializeField] private int _awayScore;
    public int HomeScore { get { return _homeScore;} }
    public int AwayScore { get { return _awayScore;} }
    [SerializeField] private int _playerChaAtBat = 0;
    [SerializeField] private int _computerChaAtBat = 0;
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
    void Start() {
        StartGame();
    }
    private void StartGame() {
        //_inningNumber = 1;
        if(_playerHomeTeam){
            _playerBatting = false;
            ChangeStateOfPlay(StateOfPlay.ComputerBatting);
        } else {
            _playerBatting = true;
            ChangeStateOfPlay(StateOfPlay.PlayerBatting);
        }
        SetDefense();
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
        if (_activeBatter != null) {
            Instantiate(_activeBatter, _batting.transform.position, Quaternion.identity);
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
    public void ChangeStateOfPlay(StateOfPlay newState) {
        stateOfPlay = newState;
        switch(newState) {
            case StateOfPlay.PlayerBatting:
                _activeBatter = TeamManager.Instance.PlayerLineUp[_playerChaAtBat];
                _playerChaAtBat++; //maybe should change this after hit/out instead of here
                SetOffense();
                break;
            case StateOfPlay.ComputerBatting:
                _activeBatter = TeamManager.Instance.ComputerLineUp[_computerChaAtBat];
                _computerChaAtBat++; //maybe should change this after hit/out instead of here
                SetOffense();
                break;
            case StateOfPlay.PlayerRunning:
                break;
            case StateOfPlay.ComputerRunning:
                break;
        }
    }
    // public void WalkBatter(){ //batter goes to first
    //     if(_whosOnFirst == null) {
    //         _whosOnFirst = _activeBatter;
    //     } else if(_whosOnSecond == null) {
    //             _whosOnSecond = _whosOnFirst;
    //             _whosOnFirst = _activeBatter;
    //     } else if(_whosOnThird == null ) {
    //         _whosOnThird = _whosOnSecond;
    //         _whosOnSecond = _whosOnFirst;
    //         _whosOnFirst = _activeBatter;
    //     } else {
    //         _whosOnThird = _whosOnSecond;
    //         _whosOnSecond = _whosOnFirst;
    //         _whosOnFirst = _activeBatter;
    //         //check for home team or away
    //         if(_whosOnThird != null)
    //             _homeScore++;
    //     }
    // } 
    public void WalkBatter(){ //batter goes to first
        if(_whosOnFirst != null) {
            if(_whosOnSecond == null) {
                _whosOnSecond = _whosOnFirst;
            } else {
                if(_whosOnThird != null)
                    _homeScore++; //later will check for which team
                _whosOnThird = _whosOnSecond;
                _whosOnSecond = _whosOnFirst;
            } 
        }
        _whosOnFirst = _activeBatter;
        if(_playerChaAtBat < 13) //TODO: replace these with an increment batting order function
            _playerChaAtBat++;
        else
            _playerChaAtBat = 0;
        _activeBatter = TeamManager.Instance.PlayerLineUp[_playerChaAtBat];
        SetOffense();
    } 
    public enum StateOfPlay {
        PlayerBatting,
        ComputerBatting,
        PlayerRunning,
        ComputerRunning
    }
}


