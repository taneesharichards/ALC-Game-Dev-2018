﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Speed;
    public Rigidbody2D PC;
    public GameObject EnemyDeath;
    public GameObject ProjectileParticle;
    public int PointsForKill;

	// Use this for initialization
	void Start () {
        // PC = FindObjectOfType<Rigidbody2D>();
        if (PC.transform.localScale.x < 0)
            Speed = -Speed;
	}

    // Update is called once per frame
    void Update()
    {
        if (PC.transform.localScale.x < 0)
            //Speed = -Speed;
            GetComponent<Rigidbody2D>

        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            ScoreManager.AddPoints(PointsForKill);
        }

        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        Destroy(gameObject);

        }
	}
