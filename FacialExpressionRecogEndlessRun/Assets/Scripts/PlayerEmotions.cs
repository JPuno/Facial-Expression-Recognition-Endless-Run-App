using UnityEngine;
using UnityEngine.UI;
using Affdex;
using System.Collections.Generic;

public class PlayerEmotions : ImageResultsListener
{
    
    public float currentSurprise;
    public float currentJoy;
   
    

    public override void onFaceFound(float timestamp, int faceId)
    {
       
        if (Debug.isDebugBuild) Debug.Log("Found the face");
    }
    //if your face lost value set to 0 value;
    public override void onFaceLost(float timestamp, int faceId)
    {
       
        currentSurprise = 0;
        currentJoy = 0;
       
        if (Debug.isDebugBuild) Debug.Log("Lost the face");
    }
    //to show the value of your emotion
    public override void onImageResults(Dictionary<int, Face> faces)
    {
        if (faces.Count > 0)
        {
            
            faces[0].Emotions.TryGetValue(Emotions.Surprise, out currentSurprise);
            faces[0].Emotions.TryGetValue(Emotions.Joy, out currentJoy);
           

        }
    }
}