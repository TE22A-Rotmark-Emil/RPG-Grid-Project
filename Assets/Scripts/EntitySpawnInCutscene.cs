using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawnInCutscene : MonoBehaviour
{
    [SerializeField]
    GameObject normalSprite;

    [SerializeField]
    GameObject alternateSprite;

    void Start()
    {
        int randomNumber = Random.Range(0, 5);
        if (0 <= randomNumber && randomNumber <= 4){
            Instantiate(normalSprite, transform);
            Debug.Log("Worked");
        }
        else{
            Instantiate(alternateSprite, transform);
            Debug.Log("Worked");
        }
        Debug.Log(randomNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
