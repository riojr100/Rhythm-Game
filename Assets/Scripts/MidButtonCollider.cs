using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidButtonCollider : MonoBehaviour
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
        if (other.gameObject.tag == "Note" && buttonScipt.midPressed)
        {
            comboScript.AddCombo();
            scoreScript.AddScore();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "HoldNote" && buttonScipt.midHoldPressed)
        {
            comboScript.AddCombo();
            scoreScript.AddScore();
            inHoldCombo = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "EndHoldNote" && buttonScipt.midHoldPressed && inHoldCombo == true)
        {
            comboScript.AddCombo();
            scoreScript.AddScore();
            inHoldCombo = false;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "HoldNote" && buttonScipt.midHoldPressed == false && inHoldCombo == true)
        {
            comboScript.ResetCombo();
            Destroy(other.gameObject.transform.parent.gameObject);
            inHoldCombo = false;
        }


    }
}
