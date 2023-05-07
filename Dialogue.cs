using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Canvas canvas;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void interact()
    {
        //initeract will start after E key is down in "playerInteract" code

        if (textComponent.text != lines[index])
        {
            startDialogue();
            Debug.Log("START");
        }
        else if (textComponent.text == lines[index])
        {
            nextLine();
            Debug.Log("NEXT");
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    //opens canvas and starts writing lines
    public void startDialogue()
    {
    canvas.gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }
    //gets each charecter puts into array and slowly type it out in-game
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    //gets next line
    public void nextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.gameObject.SetActive(false);
            canvas.gameObject.SetActive(false);
            Debug.Log("END");
        }
    }
}
