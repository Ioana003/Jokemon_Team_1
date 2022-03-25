﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Jokemon_Team_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Tree[,] bigTreeTypeSide = new Tree[2, 15];
        private Tree[,] bigTreeTypeBottom = new Tree[2, 15];
        private Tree[,] smallTrees = new Tree[2, 6];
        private List<Tree> treeObjectList = new List<Tree>();


        private Building[] houses = new Building[2];
        private Building laboratory;
        private List<Building> buildingObjectList = new List<Building>();

        private Player player;

        private Sprite flowers = new Sprite();

        private ReadableObject[] signPosts = new ReadableObject[2];
        private ReadableObject[] postBoxes = new ReadableObject[3];
        private List<ReadableObject> readablesObjectList = new List<ReadableObject>();


        private PhysicsManager pManager = new PhysicsManager();
        private InputManager iManager = new InputManager();

        private Texture2D labTexture;
        private Texture2D bigTreeTexture;
        private Texture2D houseTexture;
        private Texture2D playerTexture;
        private Texture2D smallTreeTexture;
        private Texture2D signTextureWood;
        private Texture2D postBoxTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            //It's supposed to be 800, 800
            _graphics.ApplyChanges();



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            labTexture = Content.Load<Texture2D>("Lab");
            bigTreeTexture = Content.Load<Texture2D>("Tree");
            houseTexture = Content.Load<Texture2D>("House");
            playerTexture = Content.Load<Texture2D>("test_Player");
            smallTreeTexture = Content.Load<Texture2D>("Tree");
            //signTextureWood = Content.Load<Texture2D>("Sign_Little");
            //postBoxTexture = Content.Load<Texture2D>("Postbox");


            //The following are TREES
            for (int i = 0; i <= bigTreeTypeSide.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= bigTreeTypeSide.GetUpperBound(1); j++)
                {
                    if (i == 0)
                    {
                        bigTreeTypeSide[i, j] = new Tree(bigTreeTexture, new Vector2(0, j * bigTreeTexture.Height * 2), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));
                    }
                    else
                    {
                        bigTreeTypeSide[i, j] = new Tree(bigTreeTexture, new Vector2(Window.ClientBounds.Width - bigTreeTexture.Width * 2, j * bigTreeTexture.Height * 2), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));
                    }

                    treeObjectList.Add(bigTreeTypeSide[i, j]);
                }
            }

            for (int i = 0; i <= bigTreeTypeBottom.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= bigTreeTypeBottom.GetUpperBound(1); j++)
                {
                    if (i == 0)
                    {
                        bigTreeTypeBottom[i, j] = new Tree(bigTreeTexture, new Vector2(j * bigTreeTexture.Width * 2, 0), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));
                    }
                    else
                    {
                        bigTreeTypeBottom[i, j] = new Tree(bigTreeTexture, new Vector2(j * bigTreeTexture.Width * 2, Window.ClientBounds.Height - bigTreeTexture.Height * 2), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));
                    }

                    treeObjectList.Add(bigTreeTypeBottom[i, j]);
                }
            }

            for (int i = 0; i <= smallTrees.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= smallTrees.GetUpperBound(1); j++)
                {
                    if (i == 0)
                    {
                        smallTrees[i, j] = new Tree(smallTreeTexture, new Vector2(140 + j * smallTreeTexture.Width * 2, 460), new Vector2(smallTreeTexture.Width * 2, smallTreeTexture.Height));
                    }
                    else
                    {
                        smallTrees[i, j] = new Tree(smallTreeTexture, new Vector2(440 + j * smallTreeTexture.Width * 2, 660), new Vector2(smallTreeTexture.Width * 2, smallTreeTexture.Height));
                    }

                    treeObjectList.Add(smallTrees[i, j]);
                }
            }
            //Trees end HERE

            //The following are BUILDINGS
            laboratory = new Building(labTexture, new Vector2(400, 500), new Vector2(labTexture.Width * 2, labTexture.Height * 2));
            buildingObjectList.Add(laboratory);

            for (int i = 0; i <= houses.GetUpperBound(0); i++)
            {
                houses[i] = new Building(houseTexture, new Vector2(), new Vector2(houseTexture.Width * 2, houseTexture.Height * 2));
                buildingObjectList.Add(houses[i]);
            }
            houses[0].spritePosition = new Vector2(Window.ClientBounds.Width / 3 - houses[0].spriteTexture.Width, 200);
            houses[1].spritePosition = new Vector2(2 * Window.ClientBounds.Width / 3 - houses[1].spriteTexture.Width, 200);
            //Buildings end HERE

            //The following are READABLE OBJECTS
            //for (int i = 0; i <= signPosts.GetUpperBound(0); i++)
            //{
            //    signPosts[i] = new ReadableObject(signTextureWood, new Vector2(), new Vector2(signTextureWood.Width * 2, signTextureWood.Height * 2));
            //    readablesObjectList.Add(signPosts[i]);
            //}
            //signPosts[0].spritePosition = new Vector2(smallTrees[0, smallTrees.GetUpperBound(1)].spritePosition.X + signPosts[0].spriteTexture.Width * 2, smallTrees[0, smallTrees.GetUpperBound(1)].spritePosition.Y);
            //signPosts[1].spritePosition = new Vector2(smallTrees[1, smallTrees.GetUpperBound(1)].spritePosition.X + signPosts[1].spriteTexture.Width * 2, smallTrees[1, smallTrees.GetUpperBound(1)].spritePosition.Y);

            //for (int i = 0; i <= postBoxes.GetUpperBound(0); i++)
            //{
            //    postBoxes[i] = new ReadableObject(postBoxTexture, new Vector2(), new Vector2(postBoxTexture.Width * 2, postBoxTexture.Height * 2));
            //    readablesObjectList.Add(postBoxes[i]);
            //}
            //postBoxes[0].spritePosition = new Vector2(houses[1].spritePosition.X - postBoxes[1].spriteTexture.Width);
            //Readable Objects end HERE

            player = new Player(playerTexture, new Vector2(200, 100), new Vector2(playerTexture.Width * 2, playerTexture.Height * 2));

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            iManager.checkKeyboard(player);

            foreach (Tree t in treeObjectList)
            {
                pManager.checkCollision(player, t);
            }

            foreach (Building b in buildingObjectList)
            {
                pManager.checkCollision(player, b);
            }

            //foreach (ReadableObject r in readablesObjectList)
            //{
            //    pManager.checkCollision(player, r);
            //}

            //Semi-broken, for now.

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            player.DrawSprite(_spriteBatch, player.spriteTexture);

            foreach (Tree t in bigTreeTypeSide)
            {
                t.DrawSprite(_spriteBatch, t.spriteTexture);
            }

            foreach (Tree t in bigTreeTypeBottom)
            {
                t.DrawSprite(_spriteBatch, t.spriteTexture);
            }

            foreach (Building b in houses)
            {
                b.DrawSprite(_spriteBatch, b.spriteTexture);
            }

            foreach (Tree t in smallTrees)
            {
                t.DrawSprite(_spriteBatch, t.spriteTexture);
            }

            //foreach (ReadableObject r in signPosts)
            //{
            //    r.DrawSprite(_spriteBatch, r.spriteTexture);
            //}

            laboratory.DrawSprite(_spriteBatch, laboratory.spriteTexture);

            base.Draw(gameTime);
        }
    }
}
