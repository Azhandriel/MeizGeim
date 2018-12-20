using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Members
    public float moveSpeed = 7.0f;
    private float passedTime = 0.0f;
    private float damage = 1.0f;

    private GameObject triggerEnemy;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        passedTime += 1 * Time.deltaTime;
        if(passedTime >= 5)
        {
            Destroy(this.gameObject);
        }
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            triggerEnemy = other.gameObject;
            triggerEnemy.GetComponent<Enemy>().health -= damage;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Wall")
        {
            this.gameObject.transform.Rotate(180, 0, 0, Space.World);
        }
    }
}
