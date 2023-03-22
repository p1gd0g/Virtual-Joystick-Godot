
using Godot;
using System;

public class Player : Sprite
{

    // export (NodePath) var joystickLeftPath
    [Export]
    NodePath joystickLeftPath;

    // export (NodePath) var joystickRightPath
    [Export]
    NodePath joystickRightPath;

    // export var speed : float = 100
    [Export]
    float speed = 100;

    VirtualJoystick joystickLeft;
    VirtualJoystick joystickRight;

    void onReady()
    {
        // onready var joystickLeft : VirtualJoystick = get_node(joystickLeftPath)
        joystickLeft = (VirtualJoystick)GetNode(joystickLeftPath);
        // onready var joystickRight : VirtualJoystick = get_node(joystickRightPath)
        joystickRight = (VirtualJoystick)GetNode(joystickRightPath);

    }

    public override void _Ready()
    {
        onReady();
    }

    public override void _Process(float delta)
    {
        // 	var move := Vector2.ZERO
        Vector2 move = new Vector2(0, 0);
        // move.x = Input.get_axis("ui_left", "ui_right")
        move.x = Input.GetAxis("ui_left", "ui_right");
        // move.y = Input.get_axis("ui_up", "ui_down")
        move.y = Input.GetAxis("ui_up", "ui_down");
        // position += move * speed * delta
        Position += move * speed * delta;

        // if joystickRight and joystickRight.is_pressed():
        if (joystickRight != null && joystickRight._isPressed)
        {
            // rotation = joystickRight.get_output().angle()
            Rotation = joystickRight._getOutput.Angle();
        }
    }


}