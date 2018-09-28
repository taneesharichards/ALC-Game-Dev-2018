using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject CurrentCheckPoint;
    private Rigidbody2D PC;

    // Particles
    public GameObject DeathParticle;
    public GameObject RespawnParticle;

    // Respawn Delay
    public float RespawnDelay;

    // Point Pentaly on Death
    public int PointPenaltyOnDeath;

    //Store Gravity Value
    private float GravityStore;


	// Use this for initialization
	void Start () {
        PC = FindObjectOfType<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPC(){
        StartCoroutine("RespawnPCCo");
    }

    public IEnumerator RespawnPCCo(){
        //Generate Death Particle
        Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation)
        //Hide Player
        PC.enabled = false;
        PC.GetComponent<Renderer>().enabled = false;

        // Gravity Reset
        GravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
        PC.GetComponent<Rigidbody2D>(.gravityScale) = 0f;
        PC.GetComponent<Rigidbody2D>(.velocity) = Vector2.zero;

        //Point Penalty
        ScoreManager.AddPoints(-PointPanaltyOnDeath);

        // Debug Message
        Debug.Log("Player Respawn");

        // Respawn Delay
        yield return new WaitForSeconds(respawnDelay);

    }
}
