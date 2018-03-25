using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrottleController : MonoBehaviour {

    public RectTransform throttle_front;
    public RectTransform throttle_back;
    public string PlayerName = "Player";
    public PlayerMove playerMove;
    private float position;
    private float diff;

    private void Start()
    {
        throttle_front = GameObject.Find("throttle_front").GetComponent<RectTransform>();
        throttle_back = GameObject.Find("throttle_back").GetComponent<RectTransform>();
        playerMove = GameObject.Find(PlayerName).GetComponent<PlayerMove>();
    }

    private void OnGUI()
    {
		
       // diff = (throttle_back.sizeDelta.y) / (playerMove.MAX_SPEED - playerMove.MIN_SPEED);
        //position = -playerMove.MIN_SPEED*diff  + (playerMove.GetCurrentSpeed()*diff);
        //throttle_front.localPosition = new Vector3(-5,position,0);
        
    }
}
