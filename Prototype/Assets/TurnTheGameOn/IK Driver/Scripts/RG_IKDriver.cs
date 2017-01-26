using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

//v1.04
[System.Serializable]
[RequireComponent(typeof (Animator))]
public class RG_IKDriver : MonoBehaviour
{
    public int HorizontalInput = 0;
    public int VerticalInput = 0;
    
    public float LookTarget;

    //reference to the animator component to call IK functions
    protected Animator animator;
    //the look target transform position.x value
    private float lookTargetPosX;
    public float lookTargetPosY;
    private float defaultLookYPos = 1;
    private Vector3 lookPosition;
    //the starting look target transform.x value
    [HideInInspector] public float defaultLookXPos;
    //the maximum distance the look target can move right
    [HideInInspector] public float maxLookRight;
    //the maximum distance the look target can move right
    [HideInInspector] public float maxLookLeft;
    //the speed the look object will move wheen steering
    [HideInInspector] public float minLookSpeed;
    //the snap back speed the look object will use when not steering
    [HideInInspector] public float maxLookSpeed;
    //the speed at which the look target object will move
    private float lookObjMoveSpeed;
    //used to determine when the right hand should target a steering wheel target or shift target
    private bool shifting;
    //enable/disable IK control of the avatar
    [HideInInspector] public bool ikActive = false;
    //maximum rotation of steering wheel transform on x axis
    [HideInInspector] public float steeringWheelRotation;
    [HideInInspector] public float steeringWheelRotationTwoTargets = 85f;
    [HideInInspector] public Transform steeringWheel;
    //the local transform position of the avatar, set in the Start method
    [HideInInspector] public Vector3 avatarPosition;
    //set this bool to true to trigger a shift
    [HideInInspector] public bool shift;
    //assign the gear UI text component, when this components text changes a shift will be triggered
    //IK driver targets
    [HideInInspector] public Transform targetRightHandIK;
    [HideInInspector] public Transform rightHandTarget;
    [HideInInspector] public Transform targetLeftHandIK;
    [HideInInspector] public Transform targetRightFootIK;
    [HideInInspector] public Transform targetLeftFootIK;
    [HideInInspector] public Transform lookObj;
    [HideInInspector] public Transform rightHandObj;
    [HideInInspector] public Transform leftHandObj;
    [HideInInspector] public Transform rightFootObj;
    [HideInInspector] public Transform leftFootObj;
    //steering wheel targets
    [HideInInspector] public Transform steeringW;
    [HideInInspector] public Transform steeringNW;
    [HideInInspector] public Transform steeringN;
    [HideInInspector] public Transform steeringNE;
    [HideInInspector] public Transform steeringE;
    [HideInInspector] public Transform steeringS;
    [HideInInspector] public Transform steeringSE;
    [HideInInspector] public Transform steeringSW;
    //otherIK target objects
    [HideInInspector] public Transform shiftObj;
    [HideInInspector] public Transform leftFootIdle;
    [HideInInspector] public Transform leftFootClutch;
    [HideInInspector] public Transform rightFootBrake;
    [HideInInspector] public Transform rightFootIdle;
    [HideInInspector] public Transform rightFootGas;

    private string gearString;
    private float yVelocity;
    public Vector3 defaultSteering;
    public float steeringRotationSpeed = 0.07f; //0.25f
    private float currentHorizontal;
    [Range(0, 1)] public float wheelShake = 1;
    public WheelCollider wheelCollider;
    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        transform.localPosition = avatarPosition;
        animator = GetComponent<Animator>();
        lookTargetPosX = defaultLookXPos;
        lookTargetPosY = defaultLookYPos;
        TargetShifter();
    }

    private void Update()
    {
        if (shift)
        {
            shift = false;
            TargetShifter();
        }
        if (steeringWheel != null)
        {
            Vector3 temp2;
            float rotationLimit = steeringWheelRotation;
            float tempShake = Random.Range(1.0f, 2.0f);
            tempShake = tempShake*wheelShake*(wheelCollider.rpm/25);
            tempShake = Random.Range(-tempShake, tempShake);
            temp2 = new Vector3(defaultSteering.x, defaultSteering.y, -(horizontalInput*rotationLimit));
            float zAngle = Mathf.SmoothDampAngle(steeringWheel.localEulerAngles.z, temp2.z - tempShake, ref yVelocity,
                steeringRotationSpeed);
            steeringWheel.localEulerAngles = new Vector3(defaultSteering.x, defaultSteering.y, zAngle);
        }
    }

    public void TargetWheel()
    {
        shifting = false;
        targetRightHandIK = rightHandTarget;
    }

    public void TargetShifter()
    {
        shifting = true;
        targetRightHandIK = shiftObj;
        leftFootObj = leftFootClutch;
        Invoke("TargetWheel", 0.35f);
        Invoke("LeftFootIdle", 0.5f);
    }

    public void LeftFootIdle()
    {
        leftFootObj = leftFootIdle;
    }

    private void OnAnimatorIK()
    {

        if (animator)
        {
            if (ikActive)
            {
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, targetLeftHandIK.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, targetLeftHandIK.rotation);

                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, targetRightHandIK.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, targetRightHandIK.rotation);

                    animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, targetLeftFootIK.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, targetLeftFootIK.rotation);

                    animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, targetRightFootIK.position);
                    animator.SetIKRotation(AvatarIKGoal.RightFoot, targetRightFootIK.rotation);


                    lookPosition = lookObj.localPosition;

                    if (HorizontalInput > 0)
                    {
                        if (horizontalInput == 2)
                        {
                            //rightHandObj = steeringSW;
                            leftHandObj = steeringNE;
                        }
                        else if (HorizontalInput == 1)
                        {
                            //rightHandObj = steeringS;
                            leftHandObj = steeringN;
                        }
                        else
                        {
                            //rightHandObj = steeringSE;
                            leftHandObj = steeringNW;
                        }
                        if (!(Math.Abs(LookTarget) > 0))
                            lookTargetPosX = defaultLookXPos + maxLookRight;
                        else
                            lookTargetPosX = defaultLookXPos;

                        if (!Mathf.Approximately(lookPosition.y, lookTargetPosY))
                        {
                            lookObjMoveSpeed = minLookSpeed;
                        }
                        else
                        {
                            lookObjMoveSpeed = Mathf.Lerp(lookObjMoveSpeed, maxLookSpeed, 1 * Time.deltaTime);
                        }
                    }
                    else if (HorizontalInput < 0)
                    {
                        if (HorizontalInput == -2)
                        {
                            //rightHandObj = steeringNW;
                            leftHandObj = steeringSE;
                        }
                        else if (HorizontalInput == 1)
                        {
                            //rightHandObj = steeringN;
                            leftHandObj = steeringS;
                        }
                        else
                        {
                            //rightHandObj = steeringNE;
                            leftHandObj = steeringSW;
                        }
                        if (!(Math.Abs(LookTarget) > 0))
                            lookTargetPosX = defaultLookXPos + maxLookLeft;
                        else
                            lookTargetPosX = defaultLookXPos;


                        lookObjMoveSpeed = !Mathf.Approximately(lookPosition.y, lookTargetPosY) ? minLookSpeed : Mathf.Lerp(lookObjMoveSpeed, maxLookSpeed, 1 * Time.deltaTime);
                    }
                    else
                    {
                        //rightHandObj = steeringE;
                        leftHandObj = steeringW;
                        lookTargetPosX = defaultLookXPos;

                        if (!(Math.Abs(LookTarget) > 0))
                            lookTargetPosY = defaultLookYPos;
                        else
                            lookTargetPosY = defaultLookYPos + LookTarget;

                        if (Mathf.Approximately(lookPosition.x, lookTargetPosX) && Mathf.Approximately(lookPosition.y, lookTargetPosY))
                        {
                            lookObjMoveSpeed = minLookSpeed;
                        }
                        else
                        {
                            lookObjMoveSpeed = Mathf.Lerp(lookObjMoveSpeed, maxLookSpeed, 1*Time.deltaTime);
                        }
                    }
                    //if (!LookAtRoad && OffTarget != null)
                    //{
                    //    lookTargetPosY = OffTarget.transform.position.y;
                    //    lookObjMoveSpeed = Mathf.Lerp(lookObjMoveSpeed, maxLookSpeed, 1*Time.deltaTime);
                    //}
                    //else
                    //{
                    //    lookTargetPosY = lookObj.position.y;
                    //}

                    if (VerticalInput > 0)
                    {
                        rightFootObj = rightFootGas;
                    }
                    else if (VerticalInput < 0)
                    {
                        rightFootObj = rightFootBrake;
                    }
                    else
                    {
                        rightFootObj = rightFootIdle;
                    }

                    targetRightFootIK.localPosition = Vector3.Lerp(targetRightFootIK.localPosition,
                        rightFootObj.localPosition, 2*Time.deltaTime);
                    targetRightFootIK.localRotation = Quaternion.Lerp(targetRightFootIK.localRotation,
                        rightFootObj.localRotation, 2*Time.deltaTime);

                    targetLeftFootIK.localPosition = Vector3.Lerp(targetLeftFootIK.localPosition,
                        leftFootObj.localPosition, 2*Time.deltaTime);
                    targetLeftFootIK.localRotation = Quaternion.Lerp(targetLeftFootIK.localRotation,
                        leftFootObj.localRotation, 2*Time.deltaTime);

                    targetLeftHandIK.localPosition = Vector3.Slerp(targetLeftHandIK.localPosition,
                        leftHandObj.localPosition, 2*Time.deltaTime);
                    targetLeftHandIK.localRotation = Quaternion.Lerp(targetLeftHandIK.localRotation,
                        leftHandObj.localRotation, 2*Time.deltaTime);

                    if (shifting == false)
                    {
                        targetRightHandIK.localPosition = Vector3.Slerp(targetRightHandIK.localPosition,
                            rightHandObj.localPosition, 2*Time.deltaTime);
                        targetRightHandIK.localRotation = Quaternion.Lerp(targetRightHandIK.localRotation,
                            rightHandObj.localRotation, 2*Time.deltaTime);
                    }
                    lookPosition.x = Mathf.Lerp(lookPosition.x, lookTargetPosX, lookObjMoveSpeed*Time.deltaTime);
                    lookPosition.y = Mathf.Lerp(lookPosition.y, lookTargetPosY, lookObjMoveSpeed*Time.deltaTime);
                    lookObj.localPosition = lookPosition;
                }
            }
        }
    }
}