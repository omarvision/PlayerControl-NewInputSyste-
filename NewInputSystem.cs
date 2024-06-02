using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystem : MonoBehaviour
{
    public float MoveSpeed = 8.0f;
    public float TurnSpeed = 120.0f;
    public float JumpForce = 6.0f;

    private Rigidbody rb = null;
    private Vector2 move_value;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        this.transform.Translate(Vector3.forward * MoveSpeed * move_value.y * Time.deltaTime);
        this.transform.Rotate(this.transform.up * TurnSpeed * move_value.x * Time.deltaTime);
    }
    private void OnGUI()
    {
        //Debugging: display the input values on the screen
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontSize = 28;
        style.fontStyle = FontStyle.Bold;
        string text = string.Format("New Input System ({0})", move_value);
        GUI.Label(new Rect(10, 10, 500, 50), text, style);
    }
    //Note: the New Input System "Player Input" component will SendMessage
    //      for the following. These function signatures are how we catch
    //      those messages to process
    private void OnJump(InputValue value)
    {
        rb.AddRelativeForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
    }
    private void OnMove(InputValue value)
    {
        //Note: the OnMove is reading from an analog input. The SendMessage
        //      ONLY occurs when there is a change. Therefore, we will 
        //      store the current move value here and take action in Update.
        //      If we didn't do it this way, the player control would be jerky
        //      or not continue to move
        move_value = value.Get<Vector2>();
    }

}
