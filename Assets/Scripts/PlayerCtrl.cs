using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public Transform Cam;           // to save the main camera
    public Image CursorGaugeImage;  // to save a cursor image
    private float GaugeTimer = 0;   // to check time

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Cam.position, Cam.forward);   // to create a ray in the direction the camera is facing
        RaycastHit hit;                                 // to save the hit location by RaycastHit event
        CursorGaugeImage.fillAmount = GaugeTimer;       // set the total fill time same as the GaugeTimer value

        // check collision within 100.0f
        if (Physics.Raycast(ray, out hit, 100.0f) && hit.collider.CompareTag("Cube01"))
        {
            GaugeTimer += 1.0f / 3.0f * Time.deltaTime; // increase 1 sec in 3 sec
            if (GaugeTimer >= 1)
            {
                hit.transform.gameObject.SetActive(false);
                GaugeTimer = 0;
            }
        }
        else
            GaugeTimer = 0;
    }
}
