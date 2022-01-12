using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class JoyconSelectController : MonoBehaviour {
	
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
    private bool isDecided=false;
    [SerializeField]private int characternumber = 0;

    [SerializeField]private Image picImage;
    [SerializeField]private Image check;

    public AudioClip decided;
    public AudioClip cancel;
    public AudioClip selecting;
    
    public AudioSource source;

    public SelectRepository sr;

    [SerializeField]private bool isAttacker = false;

    private bool selecting_flg=true;
    private int SR_flg = 0;
    private int SL_flg = 0;

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
		check.color = new Color(1, 1, 1, 0);

		isAttacker = _rt.anchoredPosition.y > 0;

		PlayerPrefs.SetInt("PlayerSelected", 0);
		characternumber = jc_ind;
		if (!(joycons.Count < jc_ind + 1))
		{
			if (isAttacker)
			{
				picImage.sprite = sr.GetAttackers(jc_ind, 1);
			}
			else
			{
				picImage.sprite = sr.GetDefenders(jc_ind, 1);
			}
		}
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
				picImage.color = new Color(1,1,1,0);
				if (selecting_flg)
				{
					source.PlayOneShot(selecting,0.6f);
					selecting_flg = false;
				}
				if (isAttacker)
				{
					picImage.sprite = sr.GetAttackers(jc_ind,1);
					for (var i = 0; i < SelectRepository.defenders_num.Length; i++)
					{
						if (SelectRepository.defenders_num[i] == jc_ind)
						{
							SelectRepository.defenders_num[i] = -1;
						}
					}
				}
				else
				{
					picImage.sprite = sr.GetDefenders(jc_ind,1);
					for (var i = 0; i < SelectRepository.attackers_num.Length; i++)
					{
						if (SelectRepository.attackers_num[i] == jc_ind)
						{
							SelectRepository.attackers_num[i] = -1;
						}
					}
				}
				picImage.color = new Color(1,1,1,1);

				isAttacker = _rt.anchoredPosition.y > 0;
			}
			else
			{
				selecting_flg = true;
			}

			if (j.GetButtonDown(FixInputButton(Joycon.Button.DPAD_RIGHT)) && !isDecided)
			{
				isDecided = true;
				//_im.color=Color.red;
				check.color = new Color(1, 1, 1, 1);
				int i = PlayerPrefs.GetInt("PlayerSelected");
				PlayerPrefs.SetInt("PlayerSelected",i+1);
				//Debug.LogWarning(PlayerPrefs.GetInt("PlayerSelected"));
				source.PlayOneShot(decided,1);
			}
			
			if (j.GetButtonDown(FixInputButton(Joycon.Button.DPAD_DOWN)) && isDecided)
			{
				isDecided = false;
				//_im.color=Color.white;
				check.color = new Color(1, 1, 1, 0);
				int i = PlayerPrefs.GetInt("PlayerSelected");
				PlayerPrefs.SetInt("PlayerSelected",i-1);
				//Debug.LogWarning(PlayerPrefs.GetInt("PlayerSelected"));
				source.PlayOneShot(cancel,1);
			}

			if (j.GetButtonDown(Joycon.Button.SR) && SR_flg>20)
			{
				source.PlayOneShot(selecting,0.6f);
				if (isAttacker)
				{
					
					picImage.sprite = sr.GetAttackers(jc_ind,1);
				}
				else
				{
					picImage.sprite = sr.GetDefenders(jc_ind,1);
				}

				SR_flg = 0;
			}
			else
			{
				++SR_flg;
			}
			
			if (j.GetButtonDown(Joycon.Button.SL) && SL_flg>20)
			{
				source.PlayOneShot(selecting,0.6f);
				if (isAttacker)
				{
					picImage.sprite = sr.GetAttackers(jc_ind,-1);
				}
				else
				{
					picImage.sprite = sr.GetDefenders(jc_ind,-1);
				}

				SL_flg = 0;
				
			}
			else
			{
				++SL_flg;
			}
        }
    }

    void CharacterSetup()
    {
	    if (isAttacker)
	    {
		    picImage.sprite = sr.GetAttackers(jc_ind,1);
	    }
	    else
	    {
		    picImage.sprite = sr.GetDefenders(jc_ind,1);
	    }
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