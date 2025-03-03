﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnnemyBehaviour : MonoBehaviour
{
    /// <summary>
    /// Point de vie du personnage
    /// </summary>
    [SerializeField]
    private int _pv = 2;
    /// <summary>
    /// Angle de tolérange pour le calcul du saut sur la tête
    /// </summary>
    [SerializeField]
    private float _toleranceAngle = 1.5f;
    /// <summary>
    /// Décrit la durée de l'invulnaribilité
    /// </summary>
    public const float DelaisInvulnerabilite = 1f;
    /// <summary>
    /// Décrit si l'entité est invulnérable
    /// </summary>
    private bool _invulnerable = false;
    /// <summary>
    /// Réfère à l'animator du GO
    /// </summary>
    private Animator _animator;
    /// <summary>
    /// Représente le moment où l'invulnaribilité a commencé
    /// </summary>
    private float _tempsDebutInvulnerabilite;
    /// <summary>
    /// Nombre de points octroyer lors de la destruction
    /// </summary>
    [SerializeField]
    private int _pointDestruction = 5;
    /// <summary>
    /// Défini si l'objet est en cours de destruction
    /// </summary>
    private bool _destructionEnCours = false;

    private void Start()
    {
        _animator = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (this._pv <= 0 && !this._destructionEnCours)
        {
            _animator.SetTrigger("Destruction");
            GameManager.Instance.PlayerData.IncrScore(this._pointDestruction);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            if (this.gameObject.GetComponent<EnnemyPatrol>() != null)
                this.gameObject.GetComponent<EnnemyPatrol>().enabled = false;
            if (this.gameObject.GetComponent<BirdPatrol>() != null)
                this.gameObject.GetComponent<BirdPatrol>().enabled = false;
            GameObject.Destroy(this.transform.parent.gameObject, 0.5f);
            this._destructionEnCours = true;
        }

        if (Time.fixedTime > _tempsDebutInvulnerabilite + DelaisInvulnerabilite)
            _invulnerable = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && !_invulnerable)
        {
            PlayerBehaviour pb = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (pb != null)
                pb.CallEnnemyCollision();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (!_invulnerable)
            {
                this._pv--;
                _animator.SetTrigger("DegatActif");
                _tempsDebutInvulnerabilite = Time.fixedTime;
                _invulnerable = true;
            }
        }
    }
}
