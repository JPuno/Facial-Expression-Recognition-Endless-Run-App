 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator1 : MonoBehaviour
{
    public ObjectPooler[] ChangeObject;
    public GameObject[] ActivateObj;
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

   
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

   

   

    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

     
    }

    // Update is called once per frame
    void Update()
    {
        ObjectPooling();
        ObjectChange();

    }
    // is where you pre-instantiate all the objects you'll need at any specific moment before gameplay
    void ObjectPooling()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }
    //DDA changing platform difficulties
    void ObjectChange()
    {
        ScoreManager SM = FindObjectOfType<ScoreManager>();
        if (SM.scoreCount>=50)
        {
           
            theObjectPools[1] = ChangeObject[0];
            theObjectPools[2] = ChangeObject[0];
        }
        if (SM.scoreCount >= 100)
        {
            ActivateObj[1].SetActive(true);
            theObjectPools[3] = ChangeObject[1];
            theObjectPools[4] = ChangeObject[1];
        }
        if(SM.scoreCount >= 200)
        {
            ActivateObj[2].SetActive(true);
            theObjectPools[5] = ChangeObject[2];
            theObjectPools[6] = ChangeObject[2];
        }
        if (SM.scoreCount >= 300)
        {
            ActivateObj[3].SetActive(true);
            theObjectPools[7] = ChangeObject[3];
            theObjectPools[8] = ChangeObject[3];
        }
        if (SM.scoreCount >= 400)
        {
            ActivateObj[4].SetActive(true);
            theObjectPools[9] = ChangeObject[4];
            theObjectPools[10] = ChangeObject[4];
        }

    }
}
