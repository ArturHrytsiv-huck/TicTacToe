using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCombinations : MonoBehaviour
{
    private GameObject[][] gameField;

    private WorkWithGameField field;

    private void Start()
    {
        field = GetComponent<WorkWithGameField>();
        gameField = new GameObject[field.Height][];
        for (int i = 0; i < field.Height; i++)
        {
            gameField[i] = field.GetGameField(i);
        }  
    }

    public void Check(bool gameOver)
    {
        VerticalCheck(gameOver);
        HorizontalCheck(gameOver);
        if (field.Width == field.Height)
        {
            DiagonalCheck(gameOver);
        }
        DrawCheck(gameOver);
    }

    private void VerticalCheck(bool gameOver)
    {
        for (int i = 0; i < field.Width; i++)
        {
            string letter = gameField[0][i].GetComponentInChildren<Text>().text;
            int fullRaw = field.Height;
            for (int j = 0; j < field.Height; j++)
            {
                
                if (letter != gameField[j][i].GetComponentInChildren<Text>().text)
                {
                    break;
                }
                if (letter == "")
                {
                    break;
                }
                else
                {
                    fullRaw--;
                    if (fullRaw == 0)
                    {
                        Debug.Log("Game Over!");
                        Debug.Log(letter + " - Winner!");
                        gameOver = true;
                        SceneManager.LoadScene(0);
                    }
                }
            }
        }
    }
    private void HorizontalCheck(bool gameOver)
    {
        for (int i = 0; i < field.Width; i++)
        {
            string letter = gameField[i][0].GetComponentInChildren<Text>().text;
            int fullRaw = field.Width;
            for (int j = 0; j < field.Height; j++)
            {
                
                if (letter != gameField[i][j].GetComponentInChildren<Text>().text)
                {
                    break;
                }
                if (letter == "")
                {
                    break;
                }
                else
                {
                    fullRaw--;
                    if (fullRaw == 0)
                    {
                        Debug.Log("Game Over!");
                        Debug.Log(letter + " - Winner!");
                        gameOver = true;
                        SceneManager.LoadScene(0);
                    }
                }
            }
        }
    }

    private void DiagonalCheck(bool gameOver)
    {
        if (gameField[0][0].GetComponentInChildren<Text>().text != "")
        {
            string letter = gameField[0][0].GetComponentInChildren<Text>().text;
            int fullDiagonal = field.Height;
            for (int i = 0; i < field.Height; i++)
            {
                if (letter == "")
                {
                    break;
                }
                if (letter != gameField[i][i].GetComponentInChildren<Text>().text)
                {
                    break;
                }
                else
                {
                    fullDiagonal--;
                    if (fullDiagonal == 0)
                    {
                        Debug.Log("Game Over!");
                        Debug.Log(letter + " - Winner!");
                        gameOver = true;
                        SceneManager.LoadScene(0);
                    }
                }
            }
        }
        else if (gameField[field.Height - 1][field.Height - 1].GetComponentInChildren<Text>().text != "")
        { 
            string letter = gameField[field.Height-1][field.Height-1].GetComponentInChildren<Text>().text;
            int fullDiagonal = field.Height;
            for (int i = field.Height - 1, j = 0; i != 0; i--, j++)
            {
                if (letter == "")
                {
                    break;
                }
                if (letter != gameField[i][j].GetComponentInChildren<Text>().text)
                {
                    break;
                }
                else
                {
                    fullDiagonal--;
                    if (fullDiagonal == 0)
                    {
                        Debug.Log("Game Over!");
                        Debug.Log(letter + " - Winner!");
                        SceneManager.LoadScene(0);
                    }
                }
            }
        }

    }

    private void DrawCheck(bool gameOver)
    {
        int allFields = field.Height * field.Width;

        for (int i = 0; i < field.Height; i++)
        {
            for (int j = 0; j < field.Width; j++)
            {
                if (gameField[i][j].GetComponentInChildren<Text>().text != "")
                {
                    allFields--;
                }
            }
        }

        if (allFields == 0)
        {
            Debug.Log("Draw!");
            SceneManager.LoadScene(0);
        }
    }
}
