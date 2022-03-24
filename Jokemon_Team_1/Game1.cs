using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace Jokemon_Team_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player playerSprite;
        private Player playerSprite2;

        private Building home1;
        private Building home2;

        private Building lab;
        // charles comment


        private ReadableObject sign1;
        private ReadableObject sign2;
        private ReadableObject sign3;
        private ReadableObject postbox1;
        private ReadableObject postbox2;

        private Sprite[] flowerRow = new Sprite[8];

        private Tree[] hedgeRow1 = new Tree[8];
        private Tree[] hedgeRow2 = new Tree[8];

        private Tree[] treeColumn1 = new Tree[10];
        private Tree[] treeColumn2 = new Tree[10];
        private Tree[] treeRow1 = new Tree[6];
        private Tree[] treeRow2 = new Tree[6];
        private Tree[] treeRow3 = new Tree[14];

        private List<Tree> treeObjects = new List<Tree>();
        private List<Building> buildings = new List<Building>();
        private Texture2D loadTexture;

        private InputManager iManager = new InputManager();
        private PhysicsManager pManager = new PhysicsManager();





        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 800;   // set this value to the desired height of your window
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            loadTexture = Content.Load<Texture2D>("Player_M");
            playerSprite = new Player(loadTexture, new Vector2(400, 400), new Vector2(30, 50));
            playerSprite2 = new Player(loadTexture, new Vector2(430, 400), new Vector2(30, 50));

            loadTexture = Content.Load<Texture2D>("House");
            home1 = new Building(loadTexture, new Vector2(150, 150), new Vector2(150, 150));
            home2 = new Building(loadTexture, new Vector2(500, 150), new Vector2(150, 150));
            buildings.Add(home1);
            buildings.Add(home2);
            loadTexture = Content.Load<Texture2D>("Lab");
            lab = new Building(loadTexture, new Vector2(475, 400), new Vector2(200, 150));
            buildings.Add(lab);


            loadTexture = Content.Load<Texture2D>("Sign_Little");
            sign1 = new ReadableObject(loadTexture, new Vector2(150, 550), new Vector2(25, 25));




            loadTexture = Content.Load<Texture2D>("Sign_Big");
            sign2 = new ReadableObject(loadTexture, new Vector2(290, 475), new Vector2(25, 25));
            sign3 = new ReadableObject(loadTexture, new Vector2(565, 600), new Vector2(25, 25));


            loadTexture = Content.Load<Texture2D>("Postbox");
            postbox1 = new ReadableObject(loadTexture, new Vector2(115, 265), new Vector2(25, 35));
            postbox2 = new ReadableObject(loadTexture, new Vector2(465, 265), new Vector2(25, 35));





            int posX = 0;
            int posY = 500;
            int xOffset = 150;
            int yOffset = 20;
            loadTexture = Content.Load<Texture2D>("Flower_Red");


            for (int i = 0; i < flowerRow.Length; i++)
            {

                if (i % 2 != 0)
                {
                    posY = posY + yOffset;
                    posX = ((i - 1) * 12) + xOffset;
                }
                else
                {
                    posY = 500;
                    posX = (i * 12) + xOffset;

                }

                flowerRow[i] = new Sprite(loadTexture, new Vector2(posX, posY), new Vector2(25, 25));



            }


            posX = 0;
            posY = 475;
            xOffset = 150;

            loadTexture = Content.Load<Texture2D>("Tree_Little");


            for (int i = 0; i < hedgeRow1.Length; i++)
            {
                posX = (i * 20) + xOffset;

                hedgeRow1[i] = new Tree(loadTexture, new Vector2(posX, posY), new Vector2(25, 25));


            }

            posX = 0;
            posY = 600;
            xOffset = 475;

            for (int i = 0; i < hedgeRow2.Length; i++)
            {
                posX = (i * 20) + xOffset;

                hedgeRow2[i] = new Tree(loadTexture, new Vector2(posX, posY), new Vector2(25, 25));


            }


            posX = 0;
            posY = 0;
            loadTexture = Content.Load<Texture2D>("Tree_Big");

            for (int i = 0; i < treeColumn1.Length; i++)
            {

                posX = 0;
                posY = (i * 80);
                treeColumn1[i] = new Tree(loadTexture, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeColumn1[i]);
            }

            posX = 0;
            posY = 0;
            xOffset = 740;

            for (int i = 0; i < treeColumn2.Length; i++)
            {
                posX = xOffset;
                posY = (i * 80);

                treeColumn2[i] = new Tree(loadTexture, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeColumn2[i]);


            }

            posX = 50;
            posY = 0;
            xOffset = 50;

            for (int i = 0; i < treeRow1.Length; i++)
            {

                posX = xOffset + (i * 50);

                treeRow1[i] = new Tree(loadTexture, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeRow1[i]);


            }

            posX = 50;
            posY = 0;
            xOffset = 440;

            for (int i = 0; i < treeRow2.Length; i++)
            {

                posX = xOffset + (i * 50);

                treeRow2[i] = new Tree(loadTexture, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeRow2[i]);


            }

            posX = 50;
            posY = 740;
            xOffset = 475;

            for (int i = 0; i < treeRow3.Length; i++)
            {

                posX = 50 + (i * 50);

                treeRow3[i] = new Tree(loadTexture, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeRow3[i]);


            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            iManager.checkKeyboard(playerSprite);
            iManager.checkKeyboard(playerSprite2);

            foreach (Tree t in treeObjects)
            {
                pManager.checkCollision(playerSprite, t);
            }
            foreach (Building b in buildings)
            {
                pManager.checkCollision(playerSprite, b);
            }
            if (playerSprite.clone == true)
            {
                foreach (Tree t in treeObjects)
                {
                    pManager.checkCollision(playerSprite2, t);
                }
            }




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MediumSpringGreen);

            foreach (Tree t in treeObjects)
            {
                t.DrawSprite(_spriteBatch, t.spriteTexture);
            }


            foreach (Tree t in hedgeRow1)
            {
                t.DrawSprite(_spriteBatch, t.spriteTexture);
            }
            foreach (Tree t in hedgeRow2)
            {
                t.DrawSprite(_spriteBatch, t.spriteTexture);
            }

            foreach (Sprite f in flowerRow)
            {
                f.DrawSprite(_spriteBatch, f.spriteTexture);
            }



            home1.DrawSprite(_spriteBatch, home1.spriteTexture);
            home2.DrawSprite(_spriteBatch, home2.spriteTexture);
            lab.DrawSprite(_spriteBatch, lab.spriteTexture);
            sign1.DrawSprite(_spriteBatch, sign1.spriteTexture);
            sign2.DrawSprite(_spriteBatch, sign2.spriteTexture);
            sign3.DrawSprite(_spriteBatch, sign3.spriteTexture);
            postbox1.DrawSprite(_spriteBatch, postbox1.spriteTexture);
            postbox2.DrawSprite(_spriteBatch, postbox2.spriteTexture);

            playerSprite.DrawSprite(_spriteBatch, playerSprite.spriteTexture);
            if (playerSprite.clone == true)
            {
                playerSprite2.DrawSprite(_spriteBatch, playerSprite.spriteTexture);

            }

            base.Draw(gameTime);
        }


    }
}
