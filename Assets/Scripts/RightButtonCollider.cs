using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonCollider : MonoBehaviour
{
    public ButtonScript buttonScipt;
    public ComboScript comboScript;
    public ScoreScript scoreScript;
    private bool inHoldCombo = false;

    private void Start()
    {
        buttonScipt = transform.parent.gameObject.GetComponent<ButtonScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Note" && buttonScipt.rightPressed)
        {
            comboScript.AddCombo();
            scoreScript.AddScore();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "HoldNote" && buttonScipt.rightHoldPressed)
        {
            comboScript.AddCombo();
            scoreScript.AddScore();
            inHoldCombo = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "EndHoldNote" && buttonScipt.rightHoldPressed && inHoldCombo == true)
        {
            comboScript.AddCombo();
            scoreScript.AddScore();
            inHoldCombo = false;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "HoldNote" && buttonScipt.rightHoldPressed == false && inHoldCombo == true)
        {
            comboScript.ResetCombo();
            Destroy(other.gameObject.transform.parent.gameObject);
            inHoldCombo = false;
        }
    }
}
