using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNotesScript : MonoBehaviour
{
    [SerializeField]
    private GameObject note;
    private List<int> filledNumbers = new List<int>();
    void Start()
    {
        for(int i = 0;i < this.transform.childCount; i++)
        {
            int rand = Random.Range(0, 100);
            if(rand >= 50 && this.transform.GetChild(i).gameObject.transform.childCount == 0)
            {
                GameObject spawnedObj = Instantiate(note);
                spawnedObj.transform.parent = this.transform.GetChild(i).gameObject.transform;
                spawnedObj.transform.localPosition = Vector3.zero;
                filledNumbers.Add(i);
            }
            if(filledNumbers.Count < 14 && i == this.transform.childCount - 1)
            {
                i = 0;
            }
            else if(filledNumbers.Count == 14)
            {
                break;
            }
        }
    }
}
