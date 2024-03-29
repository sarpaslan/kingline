﻿using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NodeBehaviour : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_damageTextTemplate;

    [SerializeField]
    private Sprite[] m_sprites;

    private int m_click;
    private int m_clickAddition;
    private float m_health;

    private int m_mineIndex;

    private ParticleSystem m_particleSystem;

    private SpriteRenderer m_spriteRenderer;
    private float max_health;

    [NonSerialized]
    public UnityEvent OnClick = new();

    [NonSerialized]
    public UnityEvent OnComplete = new();
    

    [NonSerialized]
    public UnityEvent OnDestroy = new();

    public bool IsDead => m_health <= 0;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        OnClick?.Invoke();
    }

    public void SetHealth(float health)
    {
        m_health = health;
        max_health = health;
    }

    public void Damage(float damage)
    {
        if (m_health <= 0)
            return;

        if (m_spriteRenderer == null)
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
            m_particleSystem = transform.GetChild(0).GetComponent<ParticleSystem>();
        }

        transform.DOPunchPosition(Vector3.one * 0.03f, 0.3f);

        m_health -= damage;

        var damageText = Instantiate(m_damageTextTemplate);
        damageText.gameObject.SetActive(true);
        damageText.text = "-" + damage;
        damageText.transform.position = transform.position;
        damageText.transform.DOMoveY(transform.position.y + 5, 1f);
        damageText.DOColor(Color.clear, 0.5f).SetDelay(0.5f);
        Destroy(damageText.gameObject, 1.3f);

        if (m_health <= 0)
        {
            OnComplete?.Invoke();
            m_mineIndex++;
            m_particleSystem.Play();
            
            if (m_mineIndex >= m_sprites.Length)
            {
                m_spriteRenderer.DOColor(Color.clear, 0.1f);
                OnDestroy?.Invoke();
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(gameObject, 1f);
            }
            else
            {
                m_spriteRenderer.sprite = m_sprites[m_mineIndex];
                m_health = max_health;
            }
        }
    }
}