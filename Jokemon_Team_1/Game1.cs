using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace Jokemon_Team_1
{
    public class Game1 : Game
    { //Plrease work
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont fontP;

        private const int screenWidth = 800;
        private const int screenHeight = 800;

        private Tree[,] bigTreeTypeSide = new Tree[2, 14];
        private Tree[,] bigTreeTypeBottom = new Tree[2, 16];
        private Tree[,] smallTrees = new Tree[2, 6];
        private List<Tree> treeObjectList = new List<Tree>();


        private Building[] houses = new Building[2];
        private Building laboratory;
        private List<Building> buildingObjectList = new List<Building>();

        private Player player;

        private Sprite flowers = new Sprite();
        private Grass[,] jokemonGrass = new Grass[2, 6];
        private List<Grass> grassObjectList = new List<Grass>();

        private ReadableObject[] signPosts = new ReadableObject[2];
        private ReadableObject[] postBoxes = new ReadableObject[3];
        private List<ReadableObject> readablesObjectList = new List<ReadableObject>();

        private Jokemon[] showJokemonInBattle = new Jokemon[2];

        private StartMenu startMenu = new StartMenu();
        private Sprite playButton = new Sprite();
        private Text playText = new Text();
        private Text skill1text = new Text();
        private Text skill2text = new Text();
        private Text skill3text = new Text();
        private Text skill4text = new Text();
        private Text ownhealth = new Text();
        private Text ownattack = new Text();


        private PhysicsManager pManager = new PhysicsManager();
        private InputManager iManager = new InputManager();

        private Texture2D labTexture;
        private Texture2D bigTreeTexture;
        private Texture2D houseTexture;
        private Texture2D playerTexture;
        private Texture2D smallTreeTexture; //Comment here please work oh my god
        private Texture2D signTextureWood;
        private Texture2D postBoxTexture;
        private Texture2D grassTexture;
        private Texture2D squareTexture;

        public bool inJokemonBattle = false;
        private bool inPauseMenu = false;
        private int countFrames = 0;

        private Jokemon PikaAchu;
        private Jokemon Enemy;
        private Stream music;
        private Texture2D pikaachuback;
        private Texture2D pikaachufront;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            //It's supposed to be 800, 800 // is now a constant go got line 14 & 15
            _graphics.ApplyChanges();



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            fontP = Content.Load<SpriteFont>("File");
            labTexture = Content.Load<Texture2D>("LabFixed");
            bigTreeTexture = Content.Load<Texture2D>("TreeFixed");
            houseTexture = Content.Load<Texture2D>("HouseFixed");
            playerTexture = Content.Load<Texture2D>("PlayerFixed");
            smallTreeTexture = Content.Load<Texture2D>("TreeFixed");
            grassTexture = Content.Load<Texture2D>("GrassFixed");
            squareTexture = Content.Load<Texture2D>("square");
            //pausemenuTexture = Content.Load<Texture2D>("PauseMenuBox");
            //signTextureWood = Content.Load<Texture2D>("Sign_Little");
            //postBoxTexture = Content.Load<Texture2D>("Postbox");
            pikaachufront = Content.Load<Texture2D>("Pika-A-chu");
            pikaachuback= Content.Load<Texture2D>("Pika_Back");

            SpriteFont fontPika = Content.Load<SpriteFont>("File");

            startMenu.hasStarted = false; //makes start menu show when game starts
            playButton = new Sprite(squareTexture, new Vector2((screenWidth / 2) - 200, screenHeight / 3), new Vector2(400, 100));
            playText = new Text(fontPika, "Play", new Vector2((screenWidth / 2) - 50, (screenHeight / 3) + 25), Color.Black);
            skill1text = new Text(fontPika, "Iron Tail", new Vector2(300,500), Color.White);
            skill2text = new Text(fontPika, "Nuzzle", new Vector2(300,650), Color.White);
            skill3text = new Text(fontPika, "Normal Attack", new Vector2(500,500), Color.White);
            skill4text = new Text(fontPika, "Sneeze", new Vector2(500,650), Color.White);




            //The following are TREES
            for (int i = 0; i <= bigTreeTypeSide.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= bigTreeTypeSide.GetUpperBound(1); j++)
                {
                    if (i == 0)
                    {
                        bigTreeTypeSide[i, j] = new Tree(bigTreeTexture, new Vector2(0, j * Window.ClientBounds.Height / bigTreeTypeSide.GetUpperBound(1)), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));
                    }
                    else
                    {
                        bigTreeTypeSide[i, j] = new Tree(bigTreeTexture, new Vector2(Window.ClientBounds.Width - bigTreeTexture.Width * 2, j * Window.ClientBounds.Height / bigTreeTypeSide.GetUpperBound(1)), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));
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
                        bigTreeTypeBottom[i, j] = new Tree(bigTreeTexture, new Vector2(j * Window.ClientBounds.Width / bigTreeTypeBottom.GetUpperBound(1), 0), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));

                    }
                    else
                    {
                        bigTreeTypeBottom[i, j] = new Tree(bigTreeTexture, new Vector2(j * Window.ClientBounds.Width / bigTreeTypeBottom.GetUpperBound(1), Window.ClientBounds.Height - bigTreeTexture.Height * 2), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));
                    }

                    if(j != 8)
                    {
                        treeObjectList.Add(bigTreeTypeBottom[i, j]);
                    }
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
            // Jokemon                            - by charles(just in case of merging error, ignore)
            PikaAchu = new Jokemon(pikaachuback, new Vector2(-100, 450), new Vector2(500, 500),100,10,5,10,5,5,"Normal Attack","Iron Tail","Nuzzle","Sneeze");
            Enemy = new Jokemon(pikaachufront, new Vector2(450, -75), new Vector2(500, 500), 100, 10, 5, 10, 5, 5, "Normal Attack", "Iron Tail", "Nuzzle", "Sneeze");
            ownhealth = new Text(fontPika,"health =" + PikaAchu.health.ToString(), new Vector2(0, 600), Color.Red);
            ownattack = new Text(fontPika, "atk =" + PikaAchu.attack.ToString(), new Vector2(0, 500), Color.Red);

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
            //Buildings end HERE -- RIGHT HERE!

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

            //Grass goes HERE

            for(int i = 0; i <= jokemonGrass.GetUpperBound(0); i++)
            {
                for(int j = 0; j <= jokemonGrass.GetUpperBound(1); j++)
                {
                    jokemonGrass[i, j] = new Grass(grassTexture, new Vector2(Window.ClientBounds.Width / 2 - grassTexture.Width * i, j * grassTexture.Height), new Vector2(grassTexture.Width, grassTexture.Height));
                    grassObjectList.Add(jokemonGrass[i,j]);
                }
            }

            //Grass ends HERE

                for(int i = 0; i <= showJokemonInBattle.GetUpperBound(0); i++)
                {
                    showJokemonInBattle[i] = new Jokemon(playerTexture, new Vector2(), new Vector2(100, 100), 0, 0, 0, 0, 0, 0, "this", "might", "break", "everything");
                }

            player = new Player(playerTexture, new Vector2(200, 100), new Vector2(playerTexture.Width * 2, playerTexture.Height * 2));
            //pausemenu = new PauseMenu(pausemenuTexture, new Vector2(400-pausemenuTexture.Width/2, 400-pausemenuTexture.Height/2), new Vector2(pausemenuTexture.Width, pausemenuTexture.Height), false);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (startMenu.hasStarted == false) //wont show anything until space bar is pressed
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    startMenu.hasStarted = true;
                }
            }
            else if (startMenu.hasStarted == true) //start menu will disappear
            {
                if (inJokemonBattle == false)
                {

                iManager.checkKeyboard(player,PikaAchu);

                    foreach (Tree t in treeObjectList)
                    {
                        pManager.checkCollision(player, t);
                    }

                foreach (Building b in buildingObjectList)
                {
                    pManager.checkCollision(player, b);
                }
                if (!inJokemonBattle)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.T))
                    {
                        inJokemonBattle = true;
                    }
                }
                else if (inJokemonBattle)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Y))
                    {
                        inJokemonBattle = false;
                    }
                }

                    //foreach (ReadableObject r in readablesObjectList)
                    //{
                    //    pManager.checkCollision(player, r);
                    //}

                    //Semi-broken, for now.

                foreach (Grass g in grassObjectList)
                {
                    if (countFrames % 10 == 0)
                    {
                        if (player.goingDown == true || player.goingLeft == true || player.goingRight == true || player.goingUp == true)
                        {
                            if (pManager.checkCollision(player, g) == true)
                            {
                                inJokemonBattle = true;
                            }
                        }
                    }
                }

                    countFrames = countFrames + 1;

                    if (countFrames >= 60)
                    {
                        countFrames = 0;
                    }
                }

                else if (inJokemonBattle == true)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.X))
                    {
                        inJokemonBattle = false;
                    }
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (startMenu.hasStarted == true) //only drwas everything else when the tart menu disappears
            {
                if (inJokemonBattle == false)
                {
                    GraphicsDevice.Clear(Color.LawnGreen);

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

                    foreach (Grass g in jokemonGrass)
                    {
                        g.DrawSprite(_spriteBatch, grassTexture);
                    }

                    laboratory.DrawSprite(_spriteBatch, laboratory.spriteTexture);

                    player.DrawSprite(_spriteBatch, player.spriteTexture);
                }
                else if (inJokemonBattle == true)
                {
                    GraphicsDevice.Clear(Color.Black);
                    PikaAchu.DrawJokemon(_spriteBatch, pikaachuback);
                    Enemy.DrawJokemon(_spriteBatch,pikaachufront);
                    skill4text.DrawText(_spriteBatch);
                    skill3text.DrawText(_spriteBatch);
                    skill2text.DrawText(_spriteBatch);
                    skill1text.DrawText(_spriteBatch);
                    ownhealth.DrawText(_spriteBatch);
                    ownattack.DrawText(_spriteBatch);


                }
            }
            if (startMenu.hasStarted == false) //draws start menu
            {
                GraphicsDevice.Clear(Color.Purple);
                startMenu.DrawStartMenu(_spriteBatch);
                playButton.DrawSprite(_spriteBatch, squareTexture);
                playText.DrawText(_spriteBatch);
            }
            // TODO: Add your drawing code here




            base.Draw(gameTime);
        }
    }
}
