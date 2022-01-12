using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class JoyconGameController : MonoBehaviour {
	
	private List<Joycon> joycons;

    // Values made available via Unity
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;
    private RectTransform _rt;
    private Image _im;
    private bool isLeft=false;
    [SerializeField]private int characternumber = 0;

    public AudioSource source;

    [SerializeField]private bool isAttacker = false;

    private bool selecting_flg=true;


    void Start ()
    {
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind+1){
			Destroy(gameObject);
		}
		PlayerPrefs.SetInt("PlayingPersons",joycons.Count);

		_rt = GetComponent<RectTransform>();
		_im = GetComponent<Image>();
		_im.color=Color.white;

		isAttacker = _rt.anchoredPosition.y > 0;

		PlayerPrefs.SetInt("PlayerSelected", 0);
		characternumber = jc_ind;
    }
    
    
    void Update () {
		if (joycons.Count > 0)
        {
			Joycon j = joycons [jc_ind];
			isLeft = j.isLeft;
			stick = j.GetStick();
			if (Mathf.Abs(stick[0]) > 0.5f)
			{
				_rt.anchoredPosition = 
					new Vector2(_rt.anchoredPosition.x,
						FixInputStick() * 120 * Mathf.Sign(stick[0]));
				if (selecting_flg)
				{
					//source.PlayOneShot(selecting,0.6f);
					selecting_flg = false;
				}


				isAttacker = _rt.anchoredPosition.y > 0;
			}
			else
			{
				selecting_flg = true;
			}

			if (j.GetButtonDown(FixInputButton(Joycon.Button.DPAD_RIGHT)))
			{
				int i = PlayerPrefs.GetInt("PlayerSelected");
				PlayerPrefs.SetInt("PlayerSelected",i+1);
				//Debug.LogWarning(PlayerPrefs.GetInt("PlayerSelected"));
				//source.PlayOneShot(decided,1);
			}
			
			if (j.GetButtonDown(FixInputButton(Joycon.Button.DPAD_DOWN)))
			{

				int i = PlayerPrefs.GetInt("PlayerSelected");
				PlayerPrefs.SetInt("PlayerSelected",i-1);
				//Debug.LogWarning(PlayerPrefs.GetInt("PlayerSelected"));
				//source.PlayOneShot(cancel,1);
			}
			
        }
    }

    void CharacterSetup()
    {

    }

    private float FixInputStick()
    {
	    return isLeft ? 1f : -1f;
    }

    private Joycon.Button FixInputButton(Joycon.Button b)
    {
	    if (isLeft)
	    {
		    if (b == Joycon.Button.DPAD_DOWN) return Joycon.Button.DPAD_LEFT;
		    if (b == Joycon.Button.DPAD_LEFT) return Joycon.Button.DPAD_UP;
		    if (b == Joycon.Button.DPAD_UP) return Joycon.Button.DPAD_RIGHT;
		    if (b == Joycon.Button.DPAD_RIGHT) return Joycon.Button.DPAD_DOWN;
	    }
	    else
	    {
		    if (b == Joycon.Button.DPAD_DOWN) return Joycon.Button.DPAD_RIGHT;
		    if (b == Joycon.Button.DPAD_LEFT) return Joycon.Button.DPAD_DOWN;
		    if (b == Joycon.Button.DPAD_UP) return Joycon.Button.DPAD_LEFT;
		    if (b == Joycon.Button.DPAD_RIGHT) return Joycon.Button.DPAD_UP;
	    }
	    return b;
    }
}