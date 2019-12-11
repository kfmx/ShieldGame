#pragma warning disable 0649    //disables SerializeField + private warning
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryTurret : MonoBehaviour
{
    [Range(0f, 20f)]
    public float range = 10f;
    [Range(0.1f, 10f)]
    public float shotsPerSecond;
    public float bulletSpeed = 10f;
    [Range(0f,1f)]
    public float startupTime = 1f;
    public bool showRange;
    public bool alwaysActive = false;
    [SerializeField]
    private LayerMask playerMask_;
    [SerializeField]
    private Transform bullet_;
    private bool active_ = false;
    private float time_;
    private float curStartupTime_;
    private Vector3 bulletSpawnPos_;
    private SpriteRenderer lightRend_;
    private Color lightDefaultColor_;

    private void Awake()
    {
        bulletSpawnPos_ = transform.GetChild(1).position;
        lightRend_ = transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>();
        curStartupTime_ = startupTime;
        lightDefaultColor_ = lightRend_.color;
    }

    private void Update()
    {
        active_ = CheckIfInRange() ? true : false;

        if (active_ || alwaysActive)
        {
            LightGlow(true);
            TryToFireBullet();
        }
        else
        {
            LightGlow(false);
            curStartupTime_ = startupTime;
            time_ = 0;
        }
    }

    private void LightGlow(bool glow)
    {
        lightRend_.color = glow ? Color.red : lightDefaultColor_;
    }

    private void TryToFireBullet()
    {
        if (curStartupTime_ > 0)
            curStartupTime_ -= Time.deltaTime;
        else
        {
            if (time_ > 0)
                time_ -= Time.deltaTime;
            else
            {
                FireBullet();
                time_ = 1f / shotsPerSecond;
            }
        }
    }

    private void FireBullet()
    {
        var bullet = Instantiate(bullet_.gameObject, bulletSpawnPos_, Quaternion.identity);
        var dir = transform.up;
        bullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed, ForceMode2D.Impulse);
    }

    private bool CheckIfInRange()
    {
        
        var hit = Physics2D.Raycast(transform.position, transform.up, range, playerMask_);
        if (hit)
            return true;
        return false;
    }

    private void OnDrawGizmos()
    {
        if (showRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.up * range);
        }
    }
}
