using System.Timers;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    int life = 1;
    [SerializeField] int angle = 50;
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject killEffect = null;
    SpriteRenderer sp = null;
    Collider2D col = null;
    bool spin = false;

    private void Start()
    {
        int randValue = UnityEngine.Random.Range(0, 10);
        switch (randValue)
        {
            case 1:
                transform.localScale = new Vector3(0.5f, 1.25f, 1);
                life = 2;
                break;
            case 3:
                spin = true;
                life = 2;
                break;
            default:
                life = 2;
                break;
        }
        sp = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        StartCoroutine(AutoDestroy());
        if(spin)
        {
            StartCoroutine(Spin());
        }
    }
    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            life -= 1;
            if(life <= 0)
            {
                Point.Instance.PlusPoint();
                PlayerPrefs.SetInt("score", Point.Instance.point);
                GameObject e = Instantiate(killEffect, transform.position, Quaternion.identity);
                col.enabled = false;
                sp.enabled = false;
            } else {
                
            }
        }
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

    IEnumerator Spin()
    {
        int n = 0;
        while(true)
        {
            transform.rotation = Quaternion.Euler(0, 0, n);
            n += angle;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
