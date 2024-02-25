using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeDestroyer : MonoBehaviour
{
    public float Time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, Time);
    }

	// Called when the collider of this object enters another collider
	void OnTriggerEnter(Collider other)
	{
		// Check if the other object has the tag "Enemy"
		if (other.CompareTag("Enemy"))
		{
			// Destroy this object when it collides with an enemy
			Destroy(this.gameObject);
		}
	}


}
