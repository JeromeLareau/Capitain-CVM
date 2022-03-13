using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BirdPatrol : MonoBehaviour
{
    /// <summary>
    /// Vitesse de l'objet en patrouille
    /// </summary>
    [SerializeField]
    private float _vitesse = 5f;
    /// <summary>
    /// Référence vers la cible actuelle de l'objet
    /// </summary>
    private Transform _cible = null;
    public Transform Cible { set { _cible = value; } }
    /// <summary>
    /// Référence vers le sprite Renderer
    /// </summary>
    private SpriteRenderer _sr;
    private float _timer;
    [SerializeField]
    private float targetChangeTime = 1;
    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        _sr = this.GetComponent<SpriteRenderer>();
        _timer = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_cible != null)
        {
            if (Time.fixedTime - _timer >= targetChangeTime)
            {
                _direction = _cible.position - this.transform.position;
                _timer = Time.fixedTime;
            }
            this.transform.Translate(_direction.normalized * _vitesse * Time.deltaTime, Space.World);

            if (_direction.x > 0 && !_sr.flipX) _sr.flipX = true;
            else if (_direction.x < 0 && _sr.flipX) _sr.flipX = false;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // Ligne entre l'ennemi et la cible
        if (_cible != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(this.transform.position, _cible.position);
        }
    }
#endif
}
