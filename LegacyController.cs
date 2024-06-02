using UnityEngine;

public class LegacyController : MonoBehaviour
{
    public float MoveSpeed = 8.0f;
    public float TurnSpeed = 120.0f;
    public float JumpForce = 6.0f;

    private Rigidbody rb = null;
    float move_value = 0; 
    float turn_value = 0;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        move_value = Input.GetAxis("Vertical");
        turn_value = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.forward * MoveSpeed * move_value * Time.deltaTime);
        this.transform.Rotate(this.transform.up * TurnSpeed * turn_value * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) == true)
            rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
    }
    private void OnGUI()
    {
        //Debugging: display the input values on the screen
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.black;
        style.fontSize = 28;
        string text = string.Format("Legacy Controller ({0:F2},{1:F2})", turn_value, move_value);
        GUI.Label(new Rect(10, 10, 300, 50), text, style);
    }
}
