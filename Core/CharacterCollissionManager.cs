using System.Collections.Generic;
using System.Linq;
using GameDevProject.Core.animations.enemy1;
using GameDevProject.Core.enemies;
using GameDevProject.Map;
using GameDevProject.Map.tiles;
using Microsoft.Xna.Framework;
using AttackState = GameDevProject.Core.animations.mainCharacter.AttackState;
using HurtState = GameDevProject.Core.animations.mainCharacter.HurtState;

namespace GameDevProject.Core;

public class CharacterCollissionManager
{
    private Character _character;

    public CharacterCollissionManager(Character character)
    {
        _character = character;
    }

    public void Update(GameTime time)
    {
        
        List<Tile> collidedTiles = _character._game.MapManager.FindAllCollissionsWithMap(_character.HitBox);
        List<Enemy> collidedEnemies = _character._game.MapManager.FindAllCollissionsWithEnemy(_character.HitBox);

        // Check if player entered the collission of the winning globe
        if (collidedTiles.Any(tile => tile is EndingTile))
        {
            // Next level!
            _character._game.MapManager.GoToNextLevel();
        }
        
        // Enemy collision check, if we are on a damage cooldown don't do it
        if (_character.DamageCooldown > 0)
        {
            _character.DamageCooldown--;
        }
        
        foreach (var enemy in collidedEnemies)
        {
            if (_character.AnimationController.ActiveState is not AttackState && !enemy.Dead)
            {
                if (_character.DamageCooldown > 0) return;

                _character.Lives--;

                if (_character.Lives == 0)
                {
                    _character._game.GoToState<gameStates.DeathState>();
                    return;
                }
            
                _character.DamageCooldown = 100;
                _character.AnimationController.GoToState<HurtState>();
                return;
            }
            
            // Player was attacking so enemy should die
            if (enemy is Enemy1 enemy1)
            {
                if (enemy.ActiveState is not DeathState) enemy1.GoToState<DeathState>();
                enemy.Dead = true;
                return;
            }

            if (enemy is Enemy2 enemy2)
            {
                if (enemy.ActiveState is not DeathState) enemy2.GoToState<animations.enemy2.DeathState>();
                enemy.Dead = true;
                return;
            }

            if (enemy is Enemy3 enemy3)
            {
                if (enemy.ActiveState is not DeathState) enemy3.GoToState<animations.enemy3.DeathState>();
                enemy.Dead = true;
                return;
            }
        }
    }
}