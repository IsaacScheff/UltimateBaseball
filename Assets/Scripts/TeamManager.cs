using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {
    public static TeamManager Instance { get; private set; }
    public BaseAthlete[] PlayerLineUp = new BaseAthlete[13];
    public BaseAthlete[] ComputerLineUp = new BaseAthlete[13];
    public BaseAthlete elfmanPrefab;
    public BaseAthlete bluemanPrefab;
    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        } else if (Instance != this) {
            Destroy(gameObject); 
        }
        Vector3 offScreenPosition = new Vector3(-1000, -1000, 0);
        //temporary auto lineups
        for(int i = 0; i < 12; i++){
            PlayerLineUp[i] = Instantiate(bluemanPrefab, offScreenPosition, Quaternion.identity);
            ComputerLineUp[i] = Instantiate(elfmanPrefab, offScreenPosition, Quaternion.identity);
        }
        
    }

    void Start() {
        //FieldManager.Instance.SetOffense();
        //FieldManager.Instance.SetDefense();
    }
}
