using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private GameInput gameInput;

    
    [Header("Player Step Climb")]
    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float stepSmooth = 0.1f;
    [SerializeField] private Rigidbody rigidBody;
    
    
    private bool isWalking;

    private void Awake(){
      stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    }

    void Start(){

    }

    private void Update()
    {
      Vector2 inputVector = gameInput.GetMovementVectorNormalized();

      Vector3 movedir = new Vector3(inputVector.x, 0f, inputVector.y);      

      float playerSize = .8f;
      bool canMove = !Physics.Raycast(transform.position, movedir, playerSize);

      if(canMove){
        transform.position += movedir * moveSpeed * Time.deltaTime;
      }


      isWalking = movedir != Vector3.zero;
      float rotateSpeed = 10f;
      transform.forward = Vector3.Slerp(transform.forward, movedir, Time.deltaTime * rotateSpeed);
      // Debug.Log(inputVector);
    }

    private void FixedUpdate(){
      stepClimb();

    }

    public bool IsWalking (){
      return isWalking;
    }
    
    void stepClimb(){
      RaycastHit hitLower;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.1f))
        {
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }

         RaycastHit hitLower45;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(1.5f,0,1), out hitLower45, 0.1f))
        {

            RaycastHit hitUpper45;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(1.5f,0,1), out hitUpper45, 0.2f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }

        RaycastHit hitLowerMinus45;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(-1.5f,0,1), out hitLowerMinus45, 0.1f))
        {

            RaycastHit hitUpperMinus45;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(-1.5f,0,1), out hitUpperMinus45, 0.2f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
            }
        }
    }


}
