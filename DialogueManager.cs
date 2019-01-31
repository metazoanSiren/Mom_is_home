using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {


	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;
    public static bool GameIsPaused = false;

    // Use this for initialization
    void Start () {
		sentences = new Queue<string>();
	}

    private void Update()
    {

            if (Input.GetKeyDown("space"))
            {
                DisplayNextSentence();
            }
    }


    public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);
        Pause();

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();

	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
            Debug.Log("done");
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
            //dialogueText.color =new Color (Random.value, Random.value, Random.value);
            dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
        Resume();
	}


    void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
