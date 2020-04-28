using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //Prefab for apple creation
    public GameObject applePrefab;

    //speed of tree
    public float speed = 1f;

    //distance from the screen edge
    public float leftAndRightEdge = 10f;

    //Chance to change direction by tree
    public float chanceToChangeDirections = 0.1f;

    //apple drop delay
    public float secondsBetweenAppleDrops = 1f;

    //apple falling speed
    public float gravityMultiplier = 4f;


    private void Awake() {
        Physics.gravity = new Vector3(0, -9.81f) ;
    }
    void Start()
    {
        Invoke("DropApple", 2f);
        //change gravity of apple to make it fall faster
        Physics.gravity *= gravityMultiplier;

    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;

        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //movement direction swap
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); //to the right
        }
        else if(pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); //to left

        }
        

    }

    private void FixedUpdate() {
        if (Random.value < chanceToChangeDirections) {
            speed *= -1; //change direction
        }
    }
}
