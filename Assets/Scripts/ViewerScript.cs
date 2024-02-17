using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewerScript : MonoBehaviour
{
    public GameObject Column;
    public int numberOfColumns;
    GameObject[] Columns;
    public float timeBetweenColumns;
    static int coins;
    public Text textCoins;



    public void Start()
    {
        textCoins.text = "";
        coins = 0;
        Columns = new GameObject[numberOfColumns];
        StartCoroutine(SpawnColumns());
    }

    private void Update()
    {
        if (BirdScript.isEnd)
            StopAllCoroutines();
        textCoins.text = coins.ToString();
    }

    IEnumerator SpawnColumns()
    {
        for (int i = 0; i < numberOfColumns; ++i)
        {
            Columns[i] = Instantiate(Column, new Vector3(4, Random.Range(-2f, 3f), 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(timeBetweenColumns - 0.1f, timeBetweenColumns + 0.1f));
        }

        while (true)
        {
            for(int i = 0;i < numberOfColumns; ++i) 
            {
                Columns[i].transform.position = new Vector3(4, Random.Range(-2f, 3f), 0);
                yield return new WaitForSeconds(Random.Range(timeBetweenColumns - 0.1f, timeBetweenColumns + 0.1f));
            }
        }
    }

    public static void PlusCoins()
    {
        coins++;
    }
}