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
        Debug.Log(isOutOfBounds);
        Vector3 targetPosition = player.transform.position;
        targetPosition.z = -10;
        if (isOutOfBounds){
            if (Vector3.Distance(center.transform.position, player.transform.position) > 10.05){
                transform.position = Vector3.Lerp(transform.position, targetPosition, 1f * Time.deltaTime);
                movement = Vector3.zero;
                movement = new();
                Debug.Log(Vector3.Distance(center.transform.position, player.transform.position));
            }
            else{
                transform.position = targetPosition;
                movement = Vector3.zero;
                Debug.Log("Perfect!! Everything worked as it should!!");
                isOutOfBounds = false;
            }
        }
    }
}
