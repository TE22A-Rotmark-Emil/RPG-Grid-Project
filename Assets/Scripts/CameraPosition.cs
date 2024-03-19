using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraPosition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject center;

    Vector3 movement = new();

    bool isOutOfBounds = false;

    void Start()
    {
    }

    void Update()
    {
        if (player.transform.position.x > center.transform.position.x + 2 ||
            player.transform.position.x < center.transform.position.x - 2 ||
            player.transform.position.y > center.transform.position.y ||
            player.transform.position.y < center.transform.position.y){
            isOutOfBounds = true;
        }
        Vector3 targetPosition = player.transform.position;
        targetPosition.z = -10;
        if (isOutOfBounds){
            if (Vector3.Distance(center.transform.position, player.transform.position) > 10.05){
                transform.position = Vector3.Lerp(transform.position, targetPosition, 2f * Time.deltaTime);
                movement = Vector3.zero;
                movement = new();
            }
            else if (Vector3.Distance(center.transform.position, player.transform.position) < 10.0001){
                transform.position = targetPosition;
                isOutOfBounds = false;
            }
            else{
                Centre();
            }
        }
    }

    void Centre(){
        Vector3 targetPosition = player.transform.position;
        targetPosition.z = -10;
        transform.position = Vector3.Lerp(transform.position, targetPosition, 15f * Time.deltaTime);
    }
}
