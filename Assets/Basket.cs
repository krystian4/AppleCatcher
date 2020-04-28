using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;

    private void Start() {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        //Set starting score to 0
        scoreGT.text = "0";
    }
    void Update()
    {
        //get the cursor position
        Vector3 mousePos2D = Input.mousePosition;

        //get how fasr main camera is from point 0
        mousePos2D.z = -Camera.main.transform.position.z;
        //convert from 2d to 3d world
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //x mouse pos to basket x pos
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }


    private void OnCollisionEnter(Collision collision) {
        GameObject collidedWith = collision.gameObject;
        if(collidedWith.tag == "Apple") {
            Destroy(collidedWith);
        }

        int score = int.Parse(scoreGT.text);
        score += 100;
        scoreGT.text = score.ToString();

        if(score > HighScore.score) {
            HighScore.score = score;
        }
    }
}
