using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleController : MonoBehaviour
{
    public TextMeshProUGUI puzzleProgress;
    public GameObject[] puzzleStatues;

    bool isPuzzleDone = false;
    int currentPuzzle = 0;
    string[] puzzles = { "Simon Says"};

    // simon says
    public float flashTime = 0.5f;
    public float flashDelay = 0.2f;
    public int maxSequence = 5;

    List<int> sequence = new List<int>();
    bool isPlayerTurn = false;
    int currentSequence = 0;
    int currentStep = 0;
    int statueNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        updatePuzzleProgress(puzzles[currentPuzzle].ToString(), currentSequence.ToString());
    }

    // Update is called once per frame
    void Update()
    {
       if (isPuzzleDone)
        {
            isPuzzleDone = false;

            puzzleProgress.text = $"Puzzle Completed";

            Level2Manager.isDone = true;
        }
    }

    public void StartSimonSays()
    {
        sequence.Clear();
        currentSequence = 0;
        currentStep = 0;

        updatePuzzleProgress(puzzles[currentPuzzle], "0");


        AddToSequence();
        StartCoroutine(ShowSequence());
    }

    void AddToSequence()
    {
        int randomIndex = Random.Range(0, puzzleStatues.Length);
        sequence.Add(randomIndex);
    }

    IEnumerator ShowSequence()
    {
        isPlayerTurn = false;

        for (int i = 0; i < sequence.Count; i++)
        {
            int index = sequence[i];

            GameObject statue = puzzleStatues[index];

            // Highlight the statue to show the sequence
            HighlightStatue(statue);
            yield return new WaitForSeconds(flashTime);

            // unHighlight the statue after showing the sequence
            ResetStatue(statue);
            yield return new WaitForSeconds(flashDelay);
        }

        isPlayerTurn = true;
    }

    void HighlightStatue(GameObject statue)
    {
        statue.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    void ResetStatue(GameObject statue)
    {
        statue.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void nextSequence()
    {
        if (sequence.Count >= 5)
        {
            isPuzzleDone = true;
            return;
        }

       

        currentStep = 0;

        currentSequence++;

        updatePuzzleProgress(puzzles[currentPuzzle], currentSequence.ToString());

        AddToSequence();
        StartCoroutine(ShowSequence());

    }

    public void PlayerInteraction(string statueName)
    {
        if (!isPlayerTurn) return;

        for (int i=0 ; i < puzzleStatues.Length; i++)
        {
            if (puzzleStatues[i].name == statueName)
            {
                statueNum = i;
            }
        }


        if (statueNum == sequence[currentStep])
        {
            currentStep++;

            if (currentStep >= sequence.Count)
            {
                nextSequence();
            }
        }
        else
        {
            StartSimonSays();
        }
    }

    void updatePuzzleProgress(string puzzleName, string text)
    {
        puzzleProgress.text = $"{puzzleName}: {text}";
    }

}
