using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStatHandler : MonoBehaviour
{
    private int _trueLevel;
    private int _level {get; set;}
    private int _hpMax {get; set;}
    public int CurrentHp;
    public int Damage {get; set;} = 1;
    
    [SerializeField]
    public string Name;

    [SerializeField]
    public bool IsShielding;
    private float cooldown;

    void Start(){
        _level = Convert.ToInt32(_trueLevel);
        if (Name == "Player"){
            _hpMax = _hpMax+(2*_level);
            CurrentHp = _hpMax;
            Damage = Damage+Convert.ToInt32(0.25*_level);
        }
        else if (Name == "WeakEnemy"){
            _hpMax = 3;
            CurrentHp = _hpMax;
            Damage = 1;
        }
    }

    void Update(){
        Defend("stop");
        if (cooldown > 0){
            cooldown -= 1*Time.deltaTime;
        }
        else if (cooldown < 0){
            cooldown = 0;
        }

        if (Input.GetKeyDown(KeyCode.Return)){
            Defend("defend");
        }
    }

    void Defend(string action){
        if (cooldown == 0 && action == "defend" && IsShielding == false){
            IsShielding = true;
            cooldown = 5;
        }
        else if (IsShielding = true && cooldown == 0 && action == "stop"){
            IsShielding = false;
        }
    }
}
