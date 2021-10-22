using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkWithGameField : MonoBehaviour
{
    [SerializeField] private GameObject gameField;

    private List<GameObject> buttonsList = new List<GameObject>();
    private GameObject[][] sortedButtonList;

    private int widthAmount = 1;
    private int heightAmount = 1;

    public int Width { get { return widthAmount; } }
    public int Height { get { return heightAmount; } }
    void Awake()
    {
        GetAllChlidren();
        GetWidthAndHeight();
        SortButtons();
    }

    public GameObject[] GetGameField(int index)
    {
        return sortedButtonList[index];
    }
    private void GetAllChlidren()
    {

        for (int i = 0; i < gameField.transform.childCount/*(gameField.GetComponentsInChildren<GameObject>().Length)*/; i++)
        {
            buttonsList.Add(gameField.transform.GetChild(i).gameObject);
        }
    }

    private void GetWidthAndHeight()
    {

        for (int i = 1; i < buttonsList.Count; i++)
        {
            if (buttonsList[i].transform.position.x == buttonsList[0].transform.position.x)
            {
                heightAmount++;
            }
            if (buttonsList[i].transform.position.z == buttonsList[0].transform.position.z)
            {
                widthAmount++;
            }
        }
        sortedButtonList = new GameObject[heightAmount][];
    }


    private void SortButtons()
    {
        GameObject firstField = buttonsList[0];
        Vector3 fieldPos = buttonsList[0].transform.position;
        for (int i = 1; i < buttonsList.Count; i++)
        {
            if (fieldPos.x > buttonsList[i].transform.position.x && fieldPos.z > buttonsList[i].transform.position.z)
            {
                fieldPos = buttonsList[i].transform.position;
                firstField = buttonsList[i];
            }
        }
        for (int i = 0; i < heightAmount; i++)
        {
            sortedButtonList[i] = new GameObject[widthAmount];
        }
        FindVerticalFields(firstField);
        FindHorizontalFields();
    }
/*    private void InsertionSort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var key = array[i];
            var j = i;
            while ((j > 1) && (array[j - 1] > key))
            {
                Swap(ref array[j - 1], ref array[j]);
                j--;
            }

            array[j] = key;
        }
    }*/

    private void FindVerticalFields(GameObject fieldStart)
    {
        List<GameObject> verticalArr = new List<GameObject>();
        for (int i = 0; i < buttonsList.Count; i++)
        {
            if (fieldStart.transform.position.x == buttonsList[i].transform.position.x)
            {
                verticalArr.Add(buttonsList[i]);
            }
        }

        SortVertical(verticalArr);

        for (int i = 0; i < heightAmount; i++)
        {
            sortedButtonList[i][0] = verticalArr[i];
        }

    }
    private void SortVertical(List<GameObject> list)
    {
        for (int i = 1; i < heightAmount; i++)
        {
            for (int j = 0; j < heightAmount - i; j++)
            {
                if (list[j].transform.position.z < list[j + 1].transform.position.z)
                {
                    Swap(list, j, j + 1);
                }
            }
        }
    }

    private void Swap(List<GameObject> arr, int index1, int index2)
    {
        GameObject temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }

    private void FindHorizontalFields()
    {

        for (int i = 0; i < heightAmount; i++)
        {
            List<GameObject> list = new List<GameObject>();
            for (int j = 0; j < buttonsList.Count; j++)
            {
                if (sortedButtonList[i][0].transform.position.z == buttonsList[j].transform.position.z)
                {
                    list.Add(buttonsList[j]);
                }
            }
            SortHorizontal(list);
            PutHorFieldsIn(i, list);
        }
    }

    private void PutHorFieldsIn(int raw, List<GameObject> list)
    {
        for (int i = 0; i < widthAmount; i++)
        {
            sortedButtonList[raw][i] = list[i];
        }
    }
    private void SortHorizontal(List<GameObject> list)
    {
        for (int i = 1; i < widthAmount; i++)
        {
            for (int j = 0; j < widthAmount - i; j++)
            {
                if (list[j].transform.position.x > list[j + 1].transform.position.x)
                {
                    Swap(list, j, j + 1);
                }
            }
        }
    }
}
