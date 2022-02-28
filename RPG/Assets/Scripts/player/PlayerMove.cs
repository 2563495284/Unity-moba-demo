using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum PlayerState
{
    Moving,
    Idie
}*/
public class PlayerMove : MonoBehaviour
{
    /*public float speedPlayer = 4f;
    private PlayerDir dir;
    public PlayerState state = PlayerState.Idie;
    public CharacterController CharacterController;
    public bool isMoving = false;
    void Start()
    {
        dir = this.GetComponent<PlayerDir>();
        CharacterController = this.GetComponent<CharacterController>();
    }
    
    void Update()
    {
        float distance = Vector3.Distance(dir.targetPosition,transform.position);
        if ((distance>0.3))
        {
            isMoving = true;
            state = PlayerState.Moving;
            CharacterController.SimpleMove(transform.forward * speedPlayer);
        }
        else
        {
            isMoving = false;
            state = PlayerState.Idie;
        }
    }*/
}
