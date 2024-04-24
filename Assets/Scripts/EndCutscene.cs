using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class EndCutscene : MonoBehaviour
{
    bool entitiesSpawned = false;

    PlayableDirector director;

    [SerializeField]
    Sprite defaultPlayerSprite;

    [SerializeField]
    SpriteRenderer playerSprite;

    [SerializeField]
    Sprite alternatePlayerSprite;

    [SerializeField]
    Transform blueBackground;

    [SerializeField]
    GameObject enemyPrefab;
    GameObject enemy;

    [SerializeField]
    GameObject playerPrefab;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
        StartAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        if (director.time > 3.85f && entitiesSpawned == false){
            SpawnEntities();
            entitiesSpawned = true;
        }
        if (Input.GetKeyDown(KeyCode.C)){
            StartAnimation();
        }
    }

    void SpawnEntities(){
        Vector3 playerLocation = new(0, 3.5f, 0);
        player = Instantiate(playerPrefab, playerLocation, quaternion.identity);
        Vector3 enemyLocation = new(0, -3.5f, 0);
        enemy = Instantiate(enemyPrefab, enemyLocation, quaternion.identity);
    }

    void StartAnimation(){
        CullEntities();
        int randomNumber = UnityEngine.Random.Range(0, 5);
        if (randomNumber > 4){
            playerSprite.sprite = defaultPlayerSprite;
            Debug.Log("Default Player Sprite");
        }
        else{
            playerSprite.sprite = alternatePlayerSprite;
            Debug.Log("Alternate Player Sprite");
        }
        director.time = 0;
        director.Play();
    }

    void CullEntities(){
        if (!player.IsDestroyed()){
            Destroy(player);
        }
        if (!enemy.IsDestroyed()){
            Destroy(enemy);
        }
        entitiesSpawned = false;
    }
}