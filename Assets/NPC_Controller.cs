using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC_Controller : MonoBehaviour {

    public Text myText;
    private int myCounter = 0;
    private int currentSceneIndex;

	// Use this for initialization
	void Start () {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
        if (myCounter >= 4)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter") 
        {
            Debug.Log("Hullo");
            changeDialogue(myCounter);
            myCounter++;
        }
    }

    void changeDialogue(int state)
    {
        switch (state)
        {
            case 0:
                myText.text = "Hi! My name is Huido.";
                break;
            case 1:
                myText.text = "Welcome to Fairfeather Island!";
                break;
            case 2:
                myText.text = "Oh no! A huge tsunami is coming!! Prepare yourself!!!";
                break;
        }
    }
}
