using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text objectiveText;
    
    private Queue<string> sentences;
    private Queue<string> objectives;

    private bool shouldGiveItem;

    [SerializeField] public Item currentItemToGive;

    [SerializeField] private Objectives objectivesQueue;
    [SerializeField] private UnityEvent OnDialogueDone;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        sentences = new Queue<string>();
        objectives = new Queue<string>();
    }

    private void Start()
    {
        StartObjectives(objectivesQueue);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }
    
    private void StartObjectives(Objectives objectiveQueue)
    {
        objectives.Clear();

        foreach (string objective in objectiveQueue.objectives)
        {
            objectives.Enqueue(objective);
        }
        
        DisplayNextObjective();
    }
    
    public void DisplayNextObjective()
    {
        if (objectives.Count == 0)
        {
            EndObjectives();
            return;
        }
        
        string objective = objectives.Dequeue();
        objectiveText.text = objective;
    }

    private void EndObjectives()
    {
        Debug.Log("No more objectives!");
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void ShouldGiveItem(bool value)
    {
        shouldGiveItem = value;
    }

    private void EndDialogue()
    {
        OnDialogueDone?.Invoke();
        
        if (currentItemToGive != null && shouldGiveItem)
        {
            currentItemToGive.PickUp();
        }
    }
}
