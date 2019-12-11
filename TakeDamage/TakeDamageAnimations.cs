#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageAnimations : MonoBehaviour
{
    [SerializeField]
    private float hitAnimationDuration_ = 0.2f;
    [SerializeField]
    private SpriteRenderer spriteToUse_;
    private Color32 startColor_;

    private void Awake()
    {
        startColor_ = spriteToUse_.color;
    }

    public void TakeDamage()
    {
        StartCoroutine(DamageAnimation(hitAnimationDuration_));
    }

    private IEnumerator DamageAnimation(float duration)
    {
        spriteToUse_.color = Color.red;
        float i = 0;
        float rate = 1 / duration;

        while(i < 1)
        {
            i += Time.deltaTime * rate;
            spriteToUse_.color = Color.Lerp(Color.red, startColor_, i);
            yield return null;
        }

        spriteToUse_.color = startColor_;
    }

}
