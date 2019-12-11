#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HoopScoreScreen : MonoBehaviour
{
    public int targetScore = 10;
    private int score_ = 0;
    [SerializeField]
    private TextMeshPro currentText_;
    [SerializeField]
    private TextMeshPro targetText_;
    [SerializeField]
    private GameObject door_;

    private void Awake()
    {
        targetText_.text = targetScore.ToString();
        currentText_.text = score_.ToString();
    }

    public void Score()
    {
        score_++;
        currentText_.text = score_.ToString();
        if (score_ >= targetScore)
            OpenDoor();
    }

    public void ResetScore()
    {
        score_ = 0;
        currentText_.text = score_.ToString();
    }

    private void OpenDoor()
    {
        door_.SetActive(false);
    }
}
