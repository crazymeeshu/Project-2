using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
    public float moveSpeed;
    public GameObject deathParticles;

    private float maxSpeed = 5f;
    private Vector3 input;
    private Vector3 spawn;


	// Use this for initialization
	void Start () {
        spawn = transform.position;
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
			//StartCoroutine (spawnDelay());
            Die();
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
			//StartCoroutine (spawnDelay ());
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
        if (other.transform.tag == "Goal")
        {
            GameManager.CompleteLevel();
        }
    }

    void Die()
    {
		//StartCoroutine (spawnDelay());
        //Instantiate(deathParticles, transform.position, Quaternion.identity);
		Instantiate(deathParticles, transform.position, Quaternion.identity);
		//StartCoroutine (spawnDelay());
        transform.position = spawn;
		//StartCoroutine (spawnDelay());
    }

	public IEnumerator spawnDelay()
	{
		yield return new WaitForSeconds(1);
		//Instantiate(deathParticles, transform.position, Quaternion.identity);
		//transform.position = spawn;
		Debug.Log ("Waiting...");
	}
	
}
