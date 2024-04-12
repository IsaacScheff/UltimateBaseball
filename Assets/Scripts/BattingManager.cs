using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattingManager : MonoBehaviour {
    //handles game logic during batting phase
    public static BattingManager Instance { get; private set; }
    public BatOption BatOptionPick;
    public BatDirection DirectionAimed;
      private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        } else if (Instance != this) {
            Destroy(gameObject); 
        }
    }
    //private int d6Roll = Random.Range (1, 7);
    public void CalculateHit(BaseAthlete pitcher, BaseAthlete batter) {
        int rollOne = Random.Range (1, 7);
        int rollTwo = Random.Range (1, 7);
        int totalRoll = rollOne + rollTwo;
        Debug.Log($"Rolled: {rollOne} and {rollTwo} for a total of {totalRoll}");
        totalRoll = totalRoll + pitcher.BasePitching - batter.BaseBatAccuracy;
        Debug.Log($"with stats: {totalRoll}");
        if(totalRoll > 7) { //a hit later in development will result in change to run mode, for now just give the base
            FieldManager.Instance.WalkBatter();
        }
        UIManager.Instance.ShowBatterOptions();
    }
    public void PlayerBatter(BaseAthlete batter, BaseAthlete pitcher) {

    }
    public void ComputerBatter(BaseAthlete batter, BaseAthlete pitcher) {

    }

    public enum BatOption {
        Smash,
        Drive,
        Bunt
    }

    public enum BatDirection {
        Right,
        Center,
        Left
    }
}
