#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleTurret : MonoBehaviour
{
    [Range(0f, 20f)]
    public float range = 10f;
    [Range(0, 360)]
    public int angleTop = 90;
    [Range(0, 360)]
    public int angleBottom = 270;
    [Range(0.1f, 10f)]
    public float shotsPerSecond;
    public float bulletSpeed = 10f;
    [Range(0f,1f)]
    public float startupTime = 1f;
    public bool showAngle;
    [SerializeField]
    private LayerMask playerMask_;
    [SerializeField]
    private LayerMask raycastMask_;
    [SerializeField]
    private Transform bullet_;
    private bool active_ = false;
    private float time_;
    private float curStartupTime_;
    [SerializeField]
    private Transform bulletSpawnTransform_;
    private SpriteRenderer lightRend_;
    private Color lightDefaultColor_;

    private void Awake()
    {
        lightRend_ = transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>();
        curStartupTime_ = startupTime;
        lightDefaultColor_ = lightRend_.color;
    }

    private void Update()
    {
        active_ = CheckIfInRange(out Vector3 targetPos) ? true : false;

        if (active_)
        {
            LightGlow(true);
            RotateTurret(targetPos);
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

    private void RotateTurret(Vector3 targetPos)
    {
        var dir = targetPos - transform.position;
        var angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
        var bullet = Instantiate(bullet_.gameObject, bulletSpawnTransform_.position, Quaternion.identity);
        var dir = transform.up;
        bullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed, ForceMode2D.Impulse);
    }

    private bool CheckIfInRange(out Vector3 targetPos)
    {
        targetPos = Vector3.zero;
        Collider2D circleHit = Physics2D.OverlapCircle(transform.position, range, playerMask_);
        if (circleHit == null)
            return false;

        Transform target = circleHit.transform;
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        if (Vector3.Angle(MyUtility.DirFromAngle(angleTop), dirToTarget) < 
            Vector3.Angle(MyUtility.DirFromAngle(angleTop), MyUtility.DirFromAngle(angleBottom)) && 
            Vector3.Angle(MyUtility.DirFromAngle(angleBottom), dirToTarget) < 
            Vector3.Angle(MyUtility.DirFromAngle(angleBottom), MyUtility.DirFromAngle(angleTop)))
        {
            var dir =  (target.position - bulletSpawnTransform_.position).normalized;
            var hit = Physics2D.Raycast(bulletSpawnTransform_.position, dir, range, raycastMask_);
            if (hit.transform.tag == "Player")
            {
                targetPos = target.position;
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        if (showAngle)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, (MyUtility.DirFromAngle(angleTop) * range) + transform.position);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, (MyUtility.DirFromAngle(angleBottom) * range) + transform.position);
        }
    }
}
