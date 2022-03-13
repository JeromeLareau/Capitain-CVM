using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdVision : MonoBehaviour
{
    private BirdPatrol _bird;
    // Start is called before the first frame update
    void Start()
    {
        _bird = this.transform.parent.gameObject.GetComponent<BirdPatrol>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
            _bird.Cible = collider.transform;
    }
}
