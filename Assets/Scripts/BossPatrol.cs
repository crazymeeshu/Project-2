using UnityEngine;
using System.Collections;

public class BossPatrol : MonoBehaviour {
    public Transform[] patrolPoints;
    public float moveSpeed;
    private int currentPoint;
	//private Vector3 aux;

	// Use this for initialization
	void Start () {
        transform.position = patrolPoints[0].position;
        currentPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ((transform.position.z == patrolPoints [0].position.z) && (transform.position.x < patrolPoints[1].position.x)) 
		{
			currentPoint = 1;
		}
		else if ((transform.position.x == patrolPoints [1].position.x) && (transform.position.z > patrolPoints[2].position.z))
		{
			currentPoint = 2;
		}
		else if ((transform.position.z == patrolPoints [2].position.z) && (transform.position.x > patrolPoints[3].position.x))
		{
			currentPoint = 3;
		}
		else if ((transform.position.x == patrolPoints [3].position.x) && (transform.position.z > patrolPoints[4].position.z))
		{
			currentPoint = 4;
		}
		else if ((transform.position.z == patrolPoints [4].position.z) && (transform.position.x < patrolPoints[5].position.x)) 
		{
			currentPoint = 5;
		}
		else if ((transform.position.x == patrolPoints [5].position.x) && (transform.position.z > patrolPoints[6].position.z))
		{
			currentPoint = 6;
		}
		else if ((transform.position.z == patrolPoints [6].position.z) && (transform.position.x < patrolPoints[7].position.x)) 
		{
			currentPoint = 7;
		}
		else if ((transform.position.x == patrolPoints [7].position.x) && (transform.position.z < patrolPoints[8].position.z)) 
		{
			currentPoint = 8;
		}
		transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
	}
}
