using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
    public float moveSpeed;
    public GameObject deathParticles;

    private float maxSpeed = 5f;
    private Vector3 input;
    private Vector3 spawn;
    private Vector3 checkPoint;
	private Vector3 bossPosition;
	private bool checkPointControl;


	// Use this for initialization
	void Start () {
        spawn = transform.position;
		checkPoint = spawn;
		checkPointControl = false;
		if (!(GameObject.FindWithTag ("Boss") == null)) {
			bossPosition = GameObject.FindWithTag ("Boss").transform.position;
		}
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
		if (other.transform.tag == "Enemy" || other.transform.tag == "Boss")
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
		if (other.transform.tag == "Enemy" || other.transform.tag == "Boss")
        {
            Die();
        }
        if (other.transform.tag == "Checkpoint" && !checkPointControl)
        {
            checkPoint = GameObject.FindWithTag("Checkpoint").transform.position;
			GameObject.FindWithTag("Checkpoint").renderer.enabled = true;
            if (!(GameObject.FindWithTag("Boss") == null))
            {
                bossPosition = GameObject.FindWithTag("Boss").transform.position;
            }
			checkPointControl = true;
            Debug.Log("Checkpoint reached");
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
        Debug.Log("Respawning...");
		yield return new WaitForSeconds(1);
		renderer.enabled = true;
		collider.enabled = true;
		rigidbody.useGravity = true;
		transform.position = checkPoint;
		if (!(GameObject.FindWithTag ("Boss") == null)) {
			GameObject.FindWithTag ("Boss").transform.position = bossPosition;
		}
	}
}
