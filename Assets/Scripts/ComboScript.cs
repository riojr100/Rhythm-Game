using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour
{
    public int combo = 0;
    public Text comboText;

    private void Update()
    {
        comboText.text = combo.ToString();
    }

    public void AddCombo()
    {
        combo++;
    }

    public void ResetCombo()
    {
        combo = 0;
    }
}
