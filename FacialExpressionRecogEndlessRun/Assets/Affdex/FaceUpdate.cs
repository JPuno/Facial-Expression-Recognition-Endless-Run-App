using UnityEngine;
using System.Collections;

public class FaceUpdate : MonoBehaviour
{
	public AnimationClip[] animations;

	Animator anim;

    Transform player;
    PlayerEmotions playerEmotions;

	public float delayWeight;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerEmotions = player.GetComponent<PlayerEmotions> ();
    }

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}


	float current = 0;


	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			current = 1;
		} else {
			current = Mathf.Lerp (current, 0, delayWeight);
		}

        anim.SetLayerWeight (1, 1);
        float dominantEmotion = Mathf.Max (playerEmotions.currentJoy, playerEmotions.currentSurprise);

        if (dominantEmotion <= 5) {
            anim.SetLayerWeight (1, current);
        }
        else if (playerEmotions.currentJoy == dominantEmotion)
        {
            if (playerEmotions.currentJoy > 60) {
                Debug.Log ("smile1@unitychan");
                anim.CrossFade ("smile1@unitychan", 0.1f);
            } else {
                Debug.Log ("smile2@unitychan");
                anim.CrossFade ("smile2@unitychan", 0.1f);
            }
        } 
        else if (playerEmotions.currentSurprise == dominantEmotion) {
            Debug.Log ("sap@unitychan");
            anim.CrossFade ("sap@unitychan", 0.1f);
        }  else {
            Debug.Log ("eye_close@unitychan");
            anim.CrossFade ("eye_close@unitychan", 0.1f);
        }
	}
}
