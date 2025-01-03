using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDestroyScript : MonoBehaviour
{
    public ComboScript comboScript;
    public ScoreScript scoreScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note" || other.gameObject.tag == "HoldNote" || other.gameObject.tag == "EndHoldNote")
        {
            Destroy(other.gameObject);
            comboScript.ResetCombo();
            scoreScript.SubtractScore();
        }
    }
}
