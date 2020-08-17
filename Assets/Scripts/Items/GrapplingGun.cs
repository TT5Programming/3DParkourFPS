using UnityEngine;

public class GrapplingGun : MonoBehaviour
{

    public PlayerMovement playerMovement;
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask seenByGrapple, seenByHook;
    public Transform gunTip, camera, player;
    public float maxDistance, maxHookDistance;
    private SpringJoint joint;
    public bool isHookActive;
    public MeshRenderer[] hook;
    
    void Awake()
    {
        isHookActive = false;
        lr = GetComponent<LineRenderer>();
    }
    

    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
                StopGrapple();
        }
        if (isHookActive == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StopHookShot();
            }
        }
        if (playerMovement.grounded == false)
            if (Input.GetMouseButtonDown(0))
            {
                StartHookShot();
            }
    }

    //Called after Update
    void LateUpdate()
    {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple()
    {
        RaycastHit hit;
        
        {
            if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, seenByGrapple))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    Debug.Log("Hit ground");
                }
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Grappleable"))
                {
                    grapplePoint = hit.point;
                    joint = player.gameObject.AddComponent<SpringJoint>();
                    joint.autoConfigureConnectedAnchor = false;
                    joint.connectedAnchor = grapplePoint;
                    int i = 0;
                    for (i = 0; i < hook.Length; ++i)
                    {
                        hook[i].enabled = false;
                    }

                    float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

                    //The distance grapple will try to keep from grapple point. 
                    joint.maxDistance = distanceFromPoint * 0.8f;
                    joint.minDistance = distanceFromPoint * 0.25f;

                    //Adjust these values to fit your game.
                    joint.spring = 4.5f;
                    joint.damper = 7f;
                    joint.massScale = 4.5f;

                    lr.positionCount = 2;
                    currentGrapplePosition = gunTip.position;
                }
            }
        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    public void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
        int i = 0;
        for (i = 0; i < hook.Length; ++i)
        {
            hook[i].enabled = true;
        }
    }

    void StartHookShot()
    {
        RaycastHit hit;
        
        {
            if (Physics.Raycast(camera.position, camera.forward, out hit, maxHookDistance, seenByHook))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    Debug.Log("Hit ground");
                }
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Hookable"))
                {
                    isHookActive = true;
                    grapplePoint = hit.point;
                    joint = player.gameObject.AddComponent<SpringJoint>();
                    joint.autoConfigureConnectedAnchor = false;
                    joint.connectedAnchor = grapplePoint;
                    int i = 0;
                    for (i = 0; i < hook.Length; ++i)
                    {
                        hook[i].enabled = false;
                    }

                    float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

                    //The distance grapple will try to keep from grapple point. 
                    joint.maxDistance = distanceFromPoint * -10f;
                    joint.minDistance = distanceFromPoint * -10f;

                    //Adjust these values to fit your game.
                    joint.spring = 2.5f;
                    joint.damper = 0f;
                    joint.massScale = 40f;

                    lr.positionCount = 2;
                    currentGrapplePosition = gunTip.position;
                }
            }
        }
    }
    public void StopHookShot()
    {
        isHookActive = false;
        lr.positionCount = 0;
        Destroy(joint);
        int i = 0;
        for (i = 0; i < hook.Length; ++i)
        {
            hook[i].enabled = true;
        }
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
