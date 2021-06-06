using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public HingeJoint mFan;
    public ConstantForce mConstantForce;
    public bool drive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            updateMotor();
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("demo");
        }
        updateMotor();
    }

    private void updateMotor()
    {
        drive = !drive;
        Debug.Log("Keydown" + drive);
        mFan.useMotor = drive;
        mConstantForce.relativeForce = new Vector3(0, 0, drive ? -mFan.motor.force : 0);
    }
}
