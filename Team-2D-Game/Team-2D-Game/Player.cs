using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Team_2D_Game
{
    class Player : Microsoft.Xna.Framework.Game
    {
        //Useable stuff
        public enum playerState { run, jump, left, right };

        //All variables for the player
        public static int MAX_HEALTH = 100;
        int health; //start with 100 health
        Inventory playerInventory;
        Vector2 position;
        Vector2 fxEmitPosition;
        Vector2 ourOrigin;
        Vector2 hatOrigin;
        Vector2 staffOrigin;
        InventoryLocation selectedLoc;

        //need a constructor
        public Player(Vector2 startPosition)
        {
            //start in whatever spot is passed in.
            this.position = startPosition;
            this.health = 100;
            this.ourOrigin.X = 10; //these depend on the size of our sprite.
            this.ourOrigin.Y = 10; //probably end up being the center.
            this.hatOrigin.X = 10; //depends on where the hat sits on the character
            this.hatOrigin.Y = 2; //ditto
            this.staffOrigin.X = 20; //need pix of stuff to know these coordts
            this.staffOrigin.Y = 10;
            this.fxEmitPosition.X = 22; //this depends on what our guy looks like, place that powers emit from
            this.fxEmitPosition.Y = 10;
            this.playerInventory = new Inventory();
            selectedLoc = playerInventory.loc1;
        }

        public void playerLoadContent()
        {
            //TODO: load all player specific content, he will need body animation, four hat
            // and four staves. sounds too
        }

        public void playerUpdate(GameTime gameTime)
        {
            //TODO: write all the update stuff.  Plan to split it off into other methods.
            // check keyboard state, do updates based on pressed keys
        }

        public void playerDraw(GameTime gameTime)
        {
            //TODO: write all the draw stuff.  We are going to draw different hat/staff sprites
            // based on different power selection.
        }

        public void hurtPlayer(int damage)
        {
            this.health = this.health - damage;
            if (this.health <= 0)
                Exit();
        }

        public void healPlayer(int healthGained)
        {
            this.health = this.health + healthGained;
            if (this.health > MAX_HEALTH)
                this.health = MAX_HEALTH;
        }

        public void pickup(Game1.power pickup, int amountPickedUp)
        {
            this.playerInventory.InventoryPickup(pickup, amountPickedUp);
        }
    }
}
