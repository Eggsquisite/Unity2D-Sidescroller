using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Frog_Controller : MonoBehaviour {

    public Text myText;
    private int myCounter = 0;
    bool inRange = false;
	
	// Update is called once per frame
	void Update () {
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
            Debug.Log("Hello");
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            Debug.Log("Goodbye");
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
                myText.text = "You saved me! *Ribbit* I will meet you on the other side.";
                break;
            case 1:
                myText.text = "";
                Destroy(gameObject);
                break;
        }
    }
}
