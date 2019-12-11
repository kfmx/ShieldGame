#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThrow : MonoBehaviour
{
    [SerializeField]
    private Transform shield_;
    [SerializeField]
    private Transform thrownShieldPrefab_;
    private ShieldManager shieldManager_;
    private List<Transform> thrownShields_;

    private void Awake()
    {
        shieldManager_ = GetComponent<ShieldManager>();
        thrownShields_ = new List<Transform>();
    }

    public void Throw()
    {
        if (shieldManager_.ThrowShield())
        {
            var thrownShield = Instantiate(thrownShieldPrefab_, transform.position, shield_.rotation);
            thrownShield.GetComponent<SpriteRenderer>().color = shield_.GetComponent<SpriteRenderer>().color;
            thrownShields_.Add(thrownShield);
            shieldManager_.NextShield();
        }
    }

    public void ReturnShields()
    {
        for (int i = 0; i < thrownShields_.Count; i++)
            Destroy(thrownShields_[i].gameObject);
        thrownShields_.Clear();
        shieldManager_.ReturnShields();
        SplatterCleaner.instance.CleanSplatter();
    }

}
