using UnityEngine;

// If using animations which should not be slowed down, change the Update Mode on the animator from "Normal" to "Unscaled Time". 
	
public class TimeManager : MonoBehaviour {

	public float slowdownFactor = 0.05f ;
	public float slowdownLength = 2f;

	void Start () 
	{
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
 	}

	void Update() 
	{
		Time.timeScale += Time.unscaledDeltaTime * (1f / slowdownLength);
		Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}

	public void SlowMotion() 
	{
		Time.timeScale = slowdownFactor;
		Time.fixedDeltaTime = Time.timeScale * .02f;
	}
}