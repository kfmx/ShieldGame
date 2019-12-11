#pragma warning disable 0649    //disables SerializeField + private warning
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSelectionWheel : MonoBehaviour
{
    private Vector2 joystick_ = Vector2.zero;
    [SerializeField]
    private Transform cursor_;
    [SerializeField]
    private Color baseColor_;
    [SerializeField]
    private Color selectColor_;
    [SerializeField]
    private SpriteRenderer slice0Rend_;
    [SerializeField]
    private SpriteRenderer slice1Rend_;
    [SerializeField]
    private SpriteRenderer slice2Rend_;
    [SerializeField]
    private SpriteRenderer slice3Rend_;
    [SerializeField]
    private SpriteRenderer slice4Rend_;
    [SerializeField]
    private SpriteRenderer slice5Rend_;
    [SerializeField]
    private SpriteRenderer slice6Rend_;
    [SerializeField]
    private SpriteRenderer slice7Rend_;
    [SerializeField]
    private SpriteRenderer slice8Rend_;
    [SerializeField]
    private SpriteRenderer slice9Rend_;
    private List<SpriteRenderer> sliceRends_ = new List<SpriteRenderer>();
    
    private void Awake()
    {
        InitializeSliceRends();
        gameObject.SetActive(false);
    }

    private void InitializeSliceRends()
    {
        sliceRends_.Add(slice0Rend_);
        sliceRends_.Add(slice1Rend_);
        sliceRends_.Add(slice2Rend_);
        sliceRends_.Add(slice3Rend_);
        sliceRends_.Add(slice4Rend_);
        sliceRends_.Add(slice5Rend_);
        sliceRends_.Add(slice6Rend_);
        sliceRends_.Add(slice7Rend_);
        sliceRends_.Add(slice8Rend_);
        sliceRends_.Add(slice9Rend_);
    }

    public void ActivateWheel(bool boolean)
    {
        gameObject.SetActive(boolean);
    }
    private void Update()
    {
        //Move to PlayerInputManager script
        joystick_ = new Vector2(Input.GetAxis("LStickHorizontal"), Input.GetAxis("LStickVertical"));
        cursor_.position = (Vector2)transform.position + joystick_;

        ResetSliceColor();
        SelectSlice(cursor_.position);
    }

    private void ResetSliceColor()
    {
        for (int i = 0; i < sliceRends_.Count; i++)
            sliceRends_[i].gameObject.SetActive(true);
    }

    private void SelectSlice(Vector2 cursorPos)
    {
        if (joystick_.magnitude < 0.5f)
        {
            slice0Rend_.gameObject.SetActive(false);
        }
        else if (IsCursorInAngle(cursorPos, 0f, 40f))
        {
            slice1Rend_.gameObject.SetActive(false);
        }
        else if (IsCursorInAngle(cursorPos, 40f, 80f))
        {
            slice9Rend_.gameObject.SetActive(false);
        }
        else if (IsCursorInAngle(cursorPos, 80f, 120f))
        {
            slice8Rend_.gameObject.SetActive(false);
        }
        else if (IsCursorInAngle(cursorPos, 120f, 160f))
        {
            slice7Rend_.gameObject.SetActive(false);
        }
        else if (IsCursorInAngle(cursorPos, 160f, 200f))
        {
            slice6Rend_.gameObject.SetActive(false);
        }
        else if (IsCursorInAngle(cursorPos, 200f, 240f))
        {
            slice5Rend_.gameObject.SetActive(false);
        }
        else if (IsCursorInAngle(cursorPos, 240f, 280f))
        {
            slice4Rend_.gameObject.SetActive(false);
        }
        else if (IsCursorInAngle(cursorPos, 280f, 320f))
        {
            slice3Rend_.gameObject.SetActive(false);
        }
        else if (IsCursorInAngle(cursorPos, 320f, 360f))
        {
            slice2Rend_.gameObject.SetActive(false);
        }
    }

    private bool IsCursorInAngle(Vector2 cursorPos, float startAngle, float endAngle)
    {
        var dirToCursor = (cursor_.position - transform.position).normalized;
        if (Vector3.Angle(MyUtility.DirFromAngle(startAngle), dirToCursor) < 
            Vector3.Angle(MyUtility.DirFromAngle(startAngle), MyUtility.DirFromAngle(endAngle)) && 
            Vector3.Angle(MyUtility.DirFromAngle(endAngle), dirToCursor) < 
            Vector3.Angle(MyUtility.DirFromAngle(endAngle), MyUtility.DirFromAngle(startAngle)))
        {
            return true;
        }
        return false;
    }

}
