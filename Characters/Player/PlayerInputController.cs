#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private string bashButton_ = "RightBumper";
    [SerializeField]
    private string throwButton_ = "LeftBumper";
    private Vector2 rightJoystick_ = Vector2.zero;
    private Vector2 leftJoystick_ = Vector2.zero;
    private CharacterMovement characterMovement_;
    private ShieldMovement shieldMovement_;
    private ShieldManager shieldManager_;
    private ShieldBash shieldBash_;
    private ShieldThrow shieldThrow_;
    private ShieldSelectionWheel shieldWheel_;
    private Collider2D collider_;
    [SerializeField]
    private StickyShield stickyShield_;
    private Health health_;

    private void Awake()
    {
        characterMovement_ = GetComponent<CharacterMovement>();
        shieldMovement_ = GetComponent<ShieldMovement>();
        shieldManager_ = GetComponent<ShieldManager>();
        shieldBash_ = GetComponent<ShieldBash>();
        shieldThrow_ = GetComponent<ShieldThrow>();
        shieldWheel_ = transform.GetChild(2).GetComponent<ShieldSelectionWheel>();
        collider_ = GetComponent<Collider2D>();
        health_ = GetComponent<Health>();
    }

    private void Update()
    {
        rightJoystick_ = new Vector2(Input.GetAxis("RStickHorizontal"), Input.GetAxis("RStickVertical"));
        leftJoystick_ = new Vector2(Input.GetAxis("LStickHorizontal"), Input.GetAxis("LStickVertical"));

        if (InputExtensions.AxisToButtonDown("RightTrigger"))
            shieldManager_.NextShield();

        if (InputExtensions.AxisToButtonDown("LeftTrigger"))
            shieldManager_.PrevShield();

        if (Input.GetButtonDown(throwButton_))
            shieldThrow_.Throw();

        if (Input.GetButtonDown(bashButton_))
            shieldBash_.Bash();

        if (InputExtensions.AxisToButtonDownInt("DPadVertical") < 0)
            shieldThrow_.ReturnShields();

        if (leftJoystick_.magnitude > 0)
            shieldWheel_.ActivateWheel(true);
        else
            shieldWheel_.ActivateWheel(false);
        
        //Reload scene
        if (Input.GetButtonDown("StartButton"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //Exit game
        if (Input.GetButtonDown("SelectButton"))
            Application.Quit();
    }

    private void FixedUpdate()
    {
        //Temporary code for sticky shield testing, relocate later
        if (!stickyShield_.joint)
            shieldMovement_.Move(rightJoystick_);
        else
            shieldMovement_.StickyMove(rightJoystick_);
    }
}