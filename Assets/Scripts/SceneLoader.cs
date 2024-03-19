using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    GameObject coolPillar;

    void Start()
    {
        Instantiate(coolPillar);
    }

    void Update(){
        
    }
}
