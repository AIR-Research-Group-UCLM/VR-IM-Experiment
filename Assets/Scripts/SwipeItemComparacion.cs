using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeItemComparacion : MonoBehaviour
{
    public List<GameObject> objectsSwiped;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeItem()
    {
        GameObject goingToBeActive;
        int indexObj = 0;
        foreach (GameObject obj in objectsSwiped)
        {
            if (obj.activeSelf)
            {
                obj.SetActive(false);
                indexObj = objectsSwiped.IndexOf(obj);
                continue;
            }
        }

        goingToBeActive = objectsSwiped[(indexObj + 1) % 9];
        goingToBeActive.SetActive(true);
    }
         
}
