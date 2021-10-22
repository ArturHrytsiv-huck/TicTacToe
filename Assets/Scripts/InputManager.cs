using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private bool xTurn;
    /*public bool XTurn { get { return xTurn; } set { xTurn = XTurn; } }*/

    public bool GetTurn()
    {
        xTurn = !xTurn;
        return !xTurn;
    }


}
