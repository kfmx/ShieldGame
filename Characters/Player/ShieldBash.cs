#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBash : MonoBehaviour
{
    public float bashForceIn = 25f;
    private float originalForceIn_;
    [SerializeField]
    private Transform shield_;
    [SerializeField]
    private LayerMask layerMask_;   //layers affected by bash
    [SerializeField]
    private LayerMask receiveForceMask_; //layers that apply a force to player
    [SerializeField]
    private GameObject shieldBashSprite_;
    private Rigidbody2D rb_;
    private Vector2[] rayPositions_;
    private bool bash_;
    private int numberOfRays = 10;
    private float bashDuration_ = 0.1f;
    private bool isBashing_;
    [SerializeField]
    private GameObject bashParticles;
    
    private void Awake()
    {
        originalForceIn_ = bashForceIn;
        rb_ = GetComponent<Rigidbody2D>();
    }

    private void SetRayPositions()
    {
        var pointA = transform.position + (shield_.right * 0.5f);
        var pointB = transform.position - (shield_.right * 0.5f);
        float fraction = (1f / numberOfRays);
        rayPositions_ = new Vector2[numberOfRays + 1];

        for (int i = 0; i < numberOfRays + 1; i++)
            rayPositions_[i] = Vector2.Lerp(pointA, pointB, fraction * i);
    }

    public void Bash()
    {
        if (!isBashing_)
            bash_ = true;
    }

    private void FixedUpdate()
    {
        if (bash_)
            StartCoroutine(BashCO(bashDuration_));
    }

    public void ResetForceIn()
    {
        bashForceIn = originalForceIn_;
    }

    private IEnumerator BashCO(float duration)
    {
        bash_ = false;
        isBashing_ = true;
        shieldBashSprite_.SetActive(true);
        ResetForceIn();
        Collider2D[] collidersHit;
        bool addForce = false;

        while(true)
        {
            collidersHit = Physics2D.OverlapCircleAll(shieldBashSprite_.transform.position, 
            (shieldBashSprite_.transform.localScale.x/2f), layerMask_);

            if (collidersHit.Length > 0)
            {
                //Test if anything we hit shall give us force
                for (int i = 0; i < collidersHit.Length; i++)
                {
                    if (MyUtility.IsInLayerMask(collidersHit[i].gameObject.layer, receiveForceMask_))
                    {
                        addForce = true;
                        i = collidersHit.Length;    //break for loop
                    }
                }

                //Test if we shall give anything we hit force (test for IBashable)
                for (int i = 0; i < collidersHit.Length; i++)
                {
                    if (collidersHit[i].GetComponent<IBashable>() != null)
                        collidersHit[i].GetComponent<IBashable>().Bashed(transform);
                }

                //Produce particle effect
                if (bashParticles != null)
                    Instantiate(bashParticles, transform.position + (shield_.up * 0.7f), shield_.rotation);

                break;
            }

            if (duration > 0)
                duration -= Time.deltaTime;
            else
                break;

            yield return new WaitForFixedUpdate();
        }

        if (addForce)
        {
            rb_.velocity = Vector2.zero;
            rb_.AddForce(-shield_.up.normalized * bashForceIn, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(duration);
        shieldBashSprite_.SetActive(false);
        isBashing_ = false;
    }

}
