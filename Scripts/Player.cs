using Godot;
using System;

public class Player : Area2D
{
	private Vector2 screenSize;

	[Export]
	public int Speed = 10;

    [Export]
    public PackedScene Missile;

    public override void _Ready()
    {
		Missile = ResourceLoader.Load("res://Missile.tscn") as PackedScene;
				
		screenSize = GetViewport().GetSize();
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_right")) {
            Position += new Vector2(Speed, 0);
        }
        if (Input.IsActionPressed("ui_left")) {
			GD.Print("Hello from C# to Godot :)");
            Position -= new Vector2(Speed, 0);
        }

        if (Input.IsActionJustPressed("action_fire")) {
            var missile =  Missile.Instance() as Area2D;
            missile.Position = Position;
            GetParent().AddChild(missile);
        }

        Position = new Vector2(
            Mathf.Clamp(Position.x, 0, screenSize.x),
            Position.y
        );
    }
}
