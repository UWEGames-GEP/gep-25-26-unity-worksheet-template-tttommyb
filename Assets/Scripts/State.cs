using System;
using UnityEngine;

public class State
{

	private float time_scale;
    private string state_name;
	private CursorLockMode cursor_lock;
    private GameObject ui_panel = null;
    private bool has_ui = false;

	public State(float ts, string name, CursorLockMode clm, GameObject ui) 
	{
		time_scale = ts;
		state_name = name;
		cursor_lock = clm;
        ui_panel = ui;
        has_ui = true;
	}

    public State(float ts, string name, CursorLockMode clm)
    {
        time_scale = ts;
        state_name = name;
        cursor_lock = clm;
    }

    public float getTimeScale()
	{
		return time_scale;
	}

    public string getStateName()
    {
		return state_name;
    }

    public CursorLockMode getCursorLockMode()
    {
        return cursor_lock;
    }

    public GameObject getUIPanel()
    {
        return ui_panel;
    }

    public bool getHasUi()
    {
        return has_ui;
    }
}
