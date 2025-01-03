using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class LeftButtonCollider : MonoBehaviour
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
        if (other.gameObject.tag == "Note" && buttonScipt.leftPressed)
        {
            comboScript.AddCombo();
            scoreScript.AddScore();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "HoldNote" && buttonScipt.leftHoldPressed)
        {
            comboScript.AddCombo();
            scoreScript.AddScore();
            inHoldCombo = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "EndHoldNote" && buttonScipt.leftHoldPressed && inHoldCombo == true)
        {
            comboScript.AddCombo();
            scoreScript.AddScore();
            inHoldCombo = false;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "HoldNote" && buttonScipt.leftHoldPressed == false && inHoldCombo == true)
        {
            comboScript.ResetCombo();
            Destroy(other.gameObject.transform.parent.gameObject);
            inHoldCombo = false;
        }
    }
}
