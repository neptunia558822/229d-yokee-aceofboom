﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class cat_controller : MonoBehaviour
{
    public float speed;
    int jump;
    float x, sx;
    bool ks;
    Animator am;
    Rigidbody2D rb;

    /*public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 5f;*/

    public Transform shootPoint;
    public GameObject target;
    public Rigidbody2D bullet;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        am.SetBool("jump", false);
        jump = 0;
    }

    float Abs(float x)
    {
        return x >= 0f ? x : -x;
    }

    Vector2 CalculateProjectile(Vector2 origin, Vector2 targetPoint, float time)
    {
        Vector2 distance = targetPoint - origin;

        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 projectileVelocity = new Vector2(velocityX, velocityY);
        return projectileVelocity;
    }

    /*void Shoot()
    {
        Vector2 targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 projectileVelocity = CalculateProjectile(firePoint.position, targetPoint, 1f);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = projectileVelocity * bulletSpeed;
        Destroy(bullet, 2f); // ทำให้กระสุนหายไปหลังจาก 2 วินาที
    }*/

    // Start is called before the first frame update
    void Start()
    {
        jump = 0;
        am = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sx = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        am.SetFloat("speed", Abs(x));

        if (Input.GetButtonDown("Jump") && jump < 2)
        {
            jump++;
            am.SetBool("jump", true);
            rb.velocity = new Vector2(rb.velocity.x, 5f);
        }

        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (x > 0)
        {
            transform.localScale = new Vector3(sx, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-sx, transform.localScale.y, transform.localScale.z);
        }

        /*if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }*/

        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5, Color.yellow, 5);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log("Hit point : " + hit.point);

                Vector2 projectileV = CalculateProjectile(shootPoint.position, hit.point, 1);

                Rigidbody2D spawnBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
                spawnBullet.velocity = projectileV;

                Destroy(spawnBullet.gameObject, 2f);
            }
        }
    }
}
