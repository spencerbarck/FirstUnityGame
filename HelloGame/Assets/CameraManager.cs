using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private InputAction action;
    [SerializeField]
    private CinemachineVirtualCamera _vcam1;
    [SerializeField]
    private CinemachineVirtualCamera _vcam2;

    private Animator animator;

    private bool notFollowCam = true;

    void Awake() {
    }

    private void SwitchPriority()
    {
        Debug.Log("You killed them all!");
        if(notFollowCam){
            _vcam1.Priority=0;
            _vcam2.Priority=1;
        }else{
            _vcam1.Priority=1;
            _vcam2.Priority=0;
        }
        notFollowCam = !notFollowCam;
    }

    void OnEnable()
    {
        action.Enable();
        action.performed += ctr => SwitchPriority();
    }
    void OnDisable()
    {
        action.Disable();
    }
}
