using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private static readonly int max = 10;
    private static readonly int min = 0;

    private readonly string titleMessage = $"Guess a number between {min} and {max}";
    private readonly string greaterMessage = $"Your guess number is greater than the number you are trying to guess";
    private readonly string lessMessage = $"Your guess number is less than the number you are trying to guess";
    private readonly Func<int, int, string> successMessage = (int number, int count) => $"You guessed correctly! The sorted number was {number}. It took you {count} guess(ess). Do you want to play again?";

    [SerializeField]
    private Text title;

    [SerializeField]
    private InputField input;

    [SerializeField]
    private GameObject button;

    private int drawnNumber;
    private int guessNumber;
    private int countGuess;

    public void Awake()
    {
        Raffle();
    }

    public void GetInput(string guess)
    {
        Compare(int.Parse(guess));
        input.text = null;
        countGuess++;
    }

    public void PlayAgain()
    {
        Raffle();
        countGuess = 0;
        button.SetActive(false);
    }

    private void Compare(int guess)
    {
        if(guess == drawnNumber)
        {
            title.text = successMessage(drawnNumber, countGuess);
            button.SetActive(true);
        }
        else
        {
            title.text = guess < drawnNumber ? lessMessage : greaterMessage;
        }
    }

    private void Raffle()
    {
        drawnNumber = Random.Range(min, max);
        title.text = titleMessage;
    }
}
