﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
[Header("Rigidbody")]
public Rigidbody2D rb;
[Header("Default Down Speed")]
public float downSpeed = 20f;
[Header("Default Movement Speed")]
public float movementSpeed = 10f;
[Header("Default Directional Movement Speed")]
public float movement = 0f;

[Header("Score Text")]
public Text scoreText;
private float topScore = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    rb =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
    movement = Input.GetAxis("Horizontal") * movementSpeed;
    if (movement < 0){
        this.GetComponent<SpriteRenderer>().flipX = false;
    }
    else
    {
        this.GetComponent<SpriteRenderer>().flipX = true;
    }
    if (rb.linearVelocity.y > 0 && transform.position.y > topScore)
    {
        topScore = transform.position.y;
    }
    scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }
    void FixedUpdate(){
        Vector2 velocity = rb.linearVelocity;
        velocity.x = movement;
        rb.linearVelocity = velocity;
    }
    void OnCollisionEnter2D(Collision2D collision){
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, downSpeed, 0);
    }
}
