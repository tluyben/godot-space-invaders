using Godot;
using System;

public class Game : Node2D
{

    [Export]
    public PackedScene Enemy;

    public override void _Ready()
    {
		Enemy = ResourceLoader.Load("res://Enemy.tscn") as PackedScene;
		
        spawnEnemies();
    }

	

    private void spawnEnemies()
    {
		
        var screenSize = GetViewport().GetSize();
        for (int y = 100; y <= 200; y += 100)
        {
            for (int x = 100; x < screenSize.x - 100; x += 200)
            {
                var enemy = Enemy.Instance() as Node2D;
                enemy.Position = new Vector2(x + (y - 100), y);
                AddChild(enemy);
            }
        }
    }

    //    public override void _Process(float delta)
    //    {
    //    }
}
