#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    private Shield currentShield_;
    [SerializeField]
    private ShieldList shieldList_;
    private List<Shield> allShields_;
    [SerializeField]
    private SpriteRenderer playerShieldRend_;
    private int currentShieldIndex_ = 0;

    private void Awake()
    {
        InitializeAvailableShields();
        currentShield_ = allShields_[currentShieldIndex_];
    }

    public void InitializeAvailableShields()
    {
        allShields_ = new List<Shield>();

        for (int i = 0; i < shieldList_.list.Length; i++)
        {
            allShields_.Add(new Shield(shieldList_.list[i].name, shieldList_.list[i].active,
            shieldList_.list[i].color, shieldList_.list[i].colorAlt));
        }
    }

    private void Update()
    {
        if (playerShieldRend_.color != currentShield_.color)
            playerShieldRend_.color = currentShield_.color;
    }

    ///<summary>
    ///Activates or deactivates given shield
    ///</summary>
    public void ActivateShield(int index, bool boolean)
    {
        index = Mathf.Clamp(index, 0, shieldList_.list.Length - 1);

        shieldList_.list[index].active = boolean;
        InitializeAvailableShields();
    }

    public void NextShield()
    {
        if (currentShieldIndex_ < allShields_.Count - 1)
        {
            currentShield_ = allShields_[currentShieldIndex_ + 1];
            currentShieldIndex_++;
        }
        else
        {
            currentShield_ = allShields_[0];
            currentShieldIndex_ = 0;
        }

        if (currentShield_.thrown || !currentShield_.active)
            NextShield();
    }

    public void PrevShield()
    {
        if (currentShieldIndex_ > 0)
        {
            currentShield_ = allShields_[currentShieldIndex_ - 1];
            currentShieldIndex_--;
        }
        else
        {
            currentShield_ = allShields_[allShields_.Count - 1];
            currentShieldIndex_ = allShields_.Count - 1;
        }

        if (currentShield_.thrown || !currentShield_.active)
            PrevShield();
    }

    public void GoToShield(int index)
    {
        index = Mathf.Clamp(index, 0, shieldList_.list.Length - 1);

        currentShield_ = allShields_[index];
        currentShieldIndex_ = index;
    }

    ///<summary>
    ///Attempts to throw shield. Returns true if successful
    ///</summary>
    public bool ThrowShield()
    {
        int notThrownShields = 0;
        for (int i = 0; i < allShields_.Count; i++)
        {
            if (!allShields_[i].thrown)
                notThrownShields++;
        }

        if (notThrownShields <= 1)
        {
            Debug.Log("Cannot throw last shield");
            return false;
        }
        else
        {
            currentShield_.thrown = true;
            return true;
        }
    }

    public void ReturnShields()
    {
        for (int i = 0; i < allShields_.Count; i++)
        {
            if (allShields_[i].thrown)
                allShields_[i].thrown = false;
        }
        Debug.Log("Shields returned");
    }
}
