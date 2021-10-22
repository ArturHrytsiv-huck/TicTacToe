using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    private Text letter;
    private Renderer rend;
    
    private Color startColor;


    [SerializeField] private Color hoverColor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private WinCombinations winCombinations;

    private bool isActive = false;
    private bool gameOver = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        letter = GetComponentInChildren<Text>();
        startColor = rend.material.color;
    }


    private void OnMouseDown()
    {
        if (!isActive && !gameOver)
        {
            letter.text = GetLetter().ToString();
            isActive = true;
            winCombinations.Check(gameOver);
        }

    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    private char GetLetter()
    {
        if (inputManager.GetTurn())
        {
            return 'X';
        }
        else
        {
            return 'O';
        }
    }
}
