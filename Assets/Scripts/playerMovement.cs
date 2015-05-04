using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
    public float moveSpeed;
    public GameObject deathParticles;
    //public Collider checkPoint;

    private float maxSpeed = 5f;
    private Vector3 input;
    private Vector3 spawn;
    private Vector3 checkPoint;


	// Use this for initialization
	void Start () {
        spawn = transform.position;
        //checkPoint = GameObject.FindWithTag("Checkpoint").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if(rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(input * moveSpeed);
        }

        if (transform.position.y < -2)
        {
            Die();
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
        if (other.transform.tag == "Checkpoint")
        {
            checkPoint = GameObject.FindWithTag("Checkpoint").transform.position;
            spawn = checkPoint;
        }
        if (other.transform.tag == "Goal")
        {
            GameManager.CompleteLevel();
        }
    }

    void Die()
    {
		Instantiate(deathParticles, transform.position, Quaternion.identity);
        renderer.enabled = false;
        collider.enabled = false;
        rigidbody.useGravity = false;
		StartCoroutine (spawnDelay());
    }

	public IEnumerator spawnDelay()
	{
		yield return new WaitForSeconds(1);
        //this.transform.position = checkPoint.position;
        Application.LoadLevel(Application.loadedLevel);
		Debug.Log ("Waiting...");
	}
	
}
