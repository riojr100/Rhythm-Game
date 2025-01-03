using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChartSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Spawner Objects")]
    [SerializeField] GameObject leftNoteSpawner;
    [SerializeField] GameObject midNoteSpawner;
    [SerializeField] GameObject rightNoteSpawner;

    [Header("Note Objects")]
    [SerializeField] GameObject leftNote;
    [SerializeField] GameObject midNote;
    [SerializeField] GameObject rightNote;

    [Header("Hold Note Objects")]
    [SerializeField] GameObject leftHoldNote;
    [SerializeField] GameObject midHoldNote;
    [SerializeField] GameObject rightHoldNote;

    [Header("Hold Note Parent")]
    [SerializeField] GameObject holdNoteParent;

    [Header("Song Script")]
    public AudioScript Audio;
    // ================================================================================
    protected StreamReader reader = null;
    protected string text = " "; // assigned to allow first line to be read below
    protected string txt;
    void Start()
    {
        // Debug.Log(StaticData.chartToPick);
        string path = Path.Combine(Application.dataPath, "Charts/", StaticData.chartToPick + ".loler");
        Debug.Log(path);
        StreamReader reader = new StreamReader(path);
        // Audio.play(6.6f);
        Audio.LoadAndSetBackgroundMusic(StaticData.chartToPick, 6.6f);
        txt = reader.ReadLine();
        while (txt != null)
        {
            if (txt.Contains("SpawnNote"))
            {
                string firstArgs = txt.Substring(txt.IndexOf("(") + 1, txt.IndexOf(",") - txt.IndexOf('(') - 1);
                string secondArgs = txt.Substring(txt.IndexOf(",") + 1, txt.IndexOf(')') - txt.IndexOf(",") - 1);
                // Debug.Log("First Argument = " + firstArgs);
                // Debug.Log("Second Argument = " + secondArgs);
                // Debug.Log(firstArgs + " " + secondArgs);
                // StartCoroutine(spawnNote(float.Parse(firstArgs), secondArgs));

                spawnNote(float.Parse(firstArgs), secondArgs);
            }
            else if (txt.Contains("SpawnHoldNote"))
            {
                string arguments = txt.Substring(txt.IndexOf("(") + 1, txt.IndexOf(")") - txt.IndexOf("(") - 1);
                // Debug.Log("Arguments = " + arguments);
                string[] splitArgument = arguments.Split(",");

                // for (int i = 0; i < splitArgument.Length; i++)
                // {
                //     Debug.Log("Splitted Arguments " + i + " = " + splitArgument[i]);
                // }
                spawnHoldNote(float.Parse(splitArgument[0]), splitArgument[1], float.Parse(splitArgument[2]));
            }
            txt = reader.ReadLine();
        }
        reader.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnNote(float timeStamp, string note)
    {
        IEnumerator lol = SN(timeStamp, note);
        StartCoroutine(lol);
    }

    private void spawnHoldNote(float timeStamp, string note, float holdNote)
    {
        IEnumerator lol = SHN(timeStamp, note, holdNote);
        StartCoroutine(lol);
    }

    private IEnumerator SN(float timeStamp, string note)
    {
        yield return new WaitForSeconds(timeStamp);
        if (note == "Left")
        {
            var left = Instantiate(leftNote, leftNoteSpawner.transform.position, transform.rotation);
        }
        else if (note == "Middle")
        {
            var mid = Instantiate(midNote, midNoteSpawner.transform.position, transform.rotation);
        }
        else if (note == "Right")
        {
            var right = Instantiate(rightNote, rightNoteSpawner.transform.position, transform.rotation);

        }
    }

    private IEnumerator SHN(float timeStamp, string note, float howLong)
    {
        // instantiate parent, put holdnote in parent, if parent is null then break loop
        yield return new WaitForSeconds(timeStamp);
        var parentObject = Instantiate(holdNoteParent, midNoteSpawner.transform.position, transform.rotation);
        for (int i = 0; i <= howLong; i++)
        {
            if (parentObject)
            {
                if (i != howLong)
                {
                    if (note == "Left")
                    {
                        var left = Instantiate(leftHoldNote, leftNoteSpawner.transform.position, transform.rotation);
                        left.transform.SetParent(parentObject.transform);
                    }
                    else if (note == "Middle")
                    {
                        var mid = Instantiate(midHoldNote, midNoteSpawner.transform.position, transform.rotation);
                        mid.transform.SetParent(parentObject.transform);
                    }
                    else if (note == "Right")
                    {
                        var right = Instantiate(rightHoldNote, rightNoteSpawner.transform.position, transform.rotation);
                        right.transform.SetParent(parentObject.transform);
                    }
                }
                else
                {
                    if (note == "Left")
                    {
                        var left = Instantiate(leftHoldNote, leftNoteSpawner.transform.position, transform.rotation);
                        left.tag = "EndHoldNote";
                        left.transform.SetParent(parentObject.transform);
                    }
                    else if (note == "Middle")
                    {
                        var mid = Instantiate(midHoldNote, midNoteSpawner.transform.position, transform.rotation);
                        mid.tag = "EndHoldNote";
                        mid.transform.SetParent(parentObject.transform);
                    }
                    else if (note == "Right")
                    {
                        var right = Instantiate(rightHoldNote, rightNoteSpawner.transform.position, transform.rotation);
                        right.tag = "EndHoldNote";
                        right.transform.SetParent(parentObject.transform);
                    }
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
