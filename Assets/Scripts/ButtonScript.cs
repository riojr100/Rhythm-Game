using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [Header("Buttons Object")]
    [SerializeField] GameObject leftButt;
    [SerializeField] GameObject midButt;
    [SerializeField] GameObject rightButt;

    // Button Animators
    private Animator leftAnim;
    private Animator midAnim;
    private Animator rightAnim;

    // Press Detection
    public bool leftPressed = false;
    public bool midPressed = false;
    public bool rightPressed = false;

    public bool leftHoldPressed = false;
    public bool midHoldPressed = false;
    public bool rightHoldPressed = false;

    private void Start()
    {
        leftAnim = leftButt.gameObject.GetComponent<Animator>();
        midAnim = midButt.gameObject.GetComponent<Animator>();
        rightAnim = rightButt.gameObject.GetComponent<Animator>();
    }
    IEnumerator leftNotePress;
    IEnumerator midNotePress;
    IEnumerator rightNotePress;
    private void Update()
    {

        if (rightButt.gameObject.tag == "RightButt" && Input.GetKeyDown(KeyCode.D))
        {
            rightNotePress = RightNotePress(0.05f);
            rightAnim.SetBool("isPressed", true);
            StartCoroutine(rightNotePress);
        }
        else if (rightButt.gameObject.tag == "RightButt" && Input.GetKeyUp(KeyCode.D))
        {
            rightAnim.SetBool("isPressed", false);
            StopCoroutine(rightNotePress);
            rightPressed = false;
            rightHoldPressed = false;
        }

        if (midButt.gameObject.tag == "MidButt" && Input.GetKeyDown(KeyCode.S))
        {
            midNotePress = MidNotePress(0.05f);
            midAnim.SetBool("isPressed", true);
            StartCoroutine(midNotePress);

        }
        else if (midButt.gameObject.tag == "MidButt" && Input.GetKeyUp(KeyCode.S))
        {
            midAnim.SetBool("isPressed", false);
            StopCoroutine(midNotePress);
            midPressed = false;
            midHoldPressed = false;
        }

        if (leftButt.gameObject.tag == "LeftButt" && Input.GetKeyDown(KeyCode.A))
        {
            leftNotePress = LeftNotePress(0.05f);
            leftAnim.SetBool("isPressed", true);
            StartCoroutine(leftNotePress);
        }
        else if (leftButt.gameObject.tag == "LeftButt" && Input.GetKeyUp(KeyCode.A))
        {
            leftAnim.SetBool("isPressed", false);
            StopCoroutine(leftNotePress);
            leftPressed = false;
            leftHoldPressed = false;
        }
    }

    private IEnumerator LeftNotePress(float waitTime)
    {
        leftPressed = true;
        leftHoldPressed = true;
        yield return new WaitForSeconds(waitTime);
        leftPressed = false;
    }

    private IEnumerator MidNotePress(float waitTime)
    {
        midPressed = true;
        midHoldPressed = true;
        yield return new WaitForSeconds(waitTime);
        midPressed = false;
    }

    private IEnumerator RightNotePress(float waitTime)
    {
        rightPressed = true;
        rightHoldPressed = true;
        yield return new WaitForSeconds(waitTime);
        rightPressed = false;
    }

    // private IEnumerator LeftHoldRelease(float waitTIme)
    // {
    //     yield return new WaitForSeconds(waitTIme);
    //     leftHoldPressed = false;
    // }

    // private IEnumerator MidHoldRelease(float waitTIme)
    // {
    //     yield return new WaitForSeconds(waitTIme);
    //     midHoldPressed = false;
    // }

    // private IEnumerator RightHoldRelease(float waitTIme)
    // {
    //     yield return new WaitForSeconds(waitTIme);
    //     rightHoldPressed = false;
    // }
}
