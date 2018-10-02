using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Eagle_Controller : MonoBehaviour {

    public Text myText;
    private int myCounter = 0;
    bool inRange = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            changeDialogue(myCounter);
            myCounter++;
            Debug.Log(myCounter);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            inRange = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WavySprite")
            SceneManager.LoadScene("Lose");
    }

    void changeDialogue(int state)
    {
        switch (state)
        {
            case 0:
                myText.text = "Thank you. I will remember this. *CAW*";
                break;
            case 1:
                myText.text = "";
                Destroy(gameObject);
                break;
        }
    }
}
