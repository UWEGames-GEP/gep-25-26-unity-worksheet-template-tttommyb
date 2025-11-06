using System;

public class State
{

	private float time_scale;
    private string state_name;

	public State(float ts, string name) 
	{
		time_scale = ts;
		state_name = name;
	}

	public float getTimeScale()
	{
		return time_scale;
	}

    public string getStateName()
    {
		return state_name;
    }

}
