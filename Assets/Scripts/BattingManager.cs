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
