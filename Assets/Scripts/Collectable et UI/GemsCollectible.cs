using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsCollectible : MonoBehaviour
{
    [SerializeField]
    private string gemName;

    [SerializeField]
    private int _gainPoint = 10;

    [SerializeField]
    private AudioClip _clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.AudioManager
                .PlayClipAtPoint(_clip, this.transform.position);
            GameManager.Instance
                .PlayerData.IncrScore(this._gainPoint);
            GameManager.Instance
                .PlayerData.CollectGem(this.gemName);
            GameObject.Destroy(this.gameObject);
        }
    }
}
