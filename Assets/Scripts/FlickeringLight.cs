


using UnityEngine;

public class FlickeringLight : MonoBehaviour
{


    [Header("Electronic Brain")]
    [Space]
    [Space]
    [Header("Properties")]

    public Light _Light; // The Light You Want To Flicker.
    public float MinTime; // Minimum value that the timer can have.
    public float MaxTime; // Maximum value that the timer can have.
    public float Timer; // Timer to flicker the light.
    public AudioSource AS; // AudioSource to play the audio.
    public AudioClip LightAudio; // Audio to play.

    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime); // Set a random value to the timer among the Minimum and maximum values.
    }


    void Update()
    {
        FlickerLight(); // Actual method for flickering the light.
    }

    void FlickerLight()
    {
        if (Timer > 0)
            Timer -= Time.deltaTime; // Start decreasing the timer if the timer is bigger than 0.

        if (Timer <= 0)
        {
            _Light.enabled = !_Light.enabled; // If timer is less than 0 start flickering.If the light is enable, disable it otherwise enable it. 
            Timer = Random.Range(MinTime, MaxTime); // Reset the timer to loop the flickering.
            AS.PlayOneShot(LightAudio); // Play the audio.
        }
    }
}
