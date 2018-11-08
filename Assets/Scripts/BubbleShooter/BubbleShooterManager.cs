using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShooterManager : MonoBehaviour {

    public static BubbleShooterManager instance;
    public RectTransform canvasTransform;
    public GameObject[] leafPrefabs;
    public GameObject[][] leafs;
    public Vector2 gridStart;
    public float horizontalDistanceBetweenLeafs;
    public float verticalDistanceBetweenLeafs;
    public int rows;
    public int columns;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        leafs = new GameObject[rows][];
        for(int i = 0; i < rows; i++)
        {
            leafs[i] = new GameObject[columns];
        }
    }

    /// <summary>
    /// Populates a given Row with Random Leafes.
    /// Starting with 0 at the top increasing downwards.
    /// When given true as second Parameter the field will travel one row down before population, otherwise it will override the row.
    /// </summary>
    /// <param name="rowNumber">Row Number to populate</param>
    /// <param name="overrideRow">Override the existing Row?</param>

    public void PopulateRow(int rowNumber, bool overrideRow)
    {
        if (!overrideRow)
        {
            bool lastRow = false;
            for (int i = 0; i < columns; i++)
            {
                if (leafs[rows - 1][i] != null)
                {
                    lastRow = true;
                }
            }
            if (lastRow)
            {
                GameOver();
                return;
            }
            else
            {
                for (int i = rows - 1; i >= rowNumber+1; i--)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (leafs[i - 1][j] != null)
                        {
                            leafs[i][j] = leafs[i - 1][j];
                            RectTransform trans = leafs[i][j].GetComponent<RectTransform>();
                            leafs[i][j].GetComponent<RectTransform>().position = new Vector2(trans.position.x + verticalDistanceBetweenLeafs, trans.position.y);
                        }
                        else
                        {
                            leafs[i][j] = null;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < columns; i++)
        {
            int number = Random.Range(0, leafPrefabs.Length + 1);
            if (number < leafPrefabs.Length)
            {
                GameObject leafToSpawn = leafPrefabs[number];
                leafs[rowNumber][i] = Instantiate(leafToSpawn, new Vector2(gridStart.x + (horizontalDistanceBetweenLeafs * i), gridStart.y + (verticalDistanceBetweenLeafs * rowNumber)), Quaternion.identity, transform);
            }
            else
            {
                leafs[rowNumber][i] = null;
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
