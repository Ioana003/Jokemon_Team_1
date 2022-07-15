using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System;
using System.Threading;
using Microsoft.Xna.Framework.Media;

namespace Jokemon_Team_1
{
    public class Game1 : Game
    { 
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont battlingfont;
        private SpriteFont statsfont;
        private SpriteFont font;
        private SpriteFont fontPika;

        public const int screenWidth = 800;
        public const int screenHeight = 800;

        private Tree[,] bigTreeTypeSide = new Tree[2, 14];
        private Tree[,] bigTreeTypeBottom = new Tree[2, 16];
        private Tree[,] smallTrees = new Tree[2, 6];
        //All of these are the trees, plus tree collision

        private Camera camera;

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

        private BattleSystem battlesystem = new BattleSystem();

        private StartMenu startMenu = new StartMenu();

        private Text skill1text = new Text();
        private Text skill2text = new Text();
        private Text skill3text = new Text();
        private Text skill4text = new Text();
        private Text eskill1text = new Text();
        private Text eskill2text = new Text();
        private Text eskill3text = new Text();
        private Text eskill4text = new Text();
        private Text ownhealth = new Text();
        private Text ownattack = new Text();
        private Text enemyhealth = new Text();
        private Text enemyattack = new Text();
        private Text showattackorder = new Text();
        private Text encounterattack = new Text();
        private Text encounterrun = new Text();
        private Text encounteritem = new Text();
        private Text encounterchange = new Text();

        private Text playText = new Text();
        private Text exitText = new Text();
        private Text settingsText = new Text();
        private Text returnText = new Text();

        private SettingsMenu settingsMenu = new SettingsMenu();

        private PhysicsManager pManager = new PhysicsManager();
        private InputManager iManager = new InputManager();

        private Texture2D labTexture;
        private Texture2D bigTreeTexture;
        private Texture2D houseTexture;
        private Texture2D playerTexture;
        private Texture2D smallTreeTexture; //Comment here please work oh my god
        //Textures to be used later

        private Texture2D grassTexture;
        //Various textures to be used later
        private Texture2D squareTexture;
        private Texture2D skillbox;

        public bool inJokemonBattle = false;
        private int countFrames = 0;
        //Different booleans used here
        //Additionally, countFrames is used to make sure most people don't constantly get harassed by JokeMons
        
        private bool userattacking = true, enemyattacking = false;
        private bool encounterenemy = false;

        private Jokemon PikaAchu;
        private Jokemon Enemy;
        private Texture2D pikaachuback;
        private Texture2D pikaachufront;
        //Jokemon textures, plus JokeMon stuff

        private List<Rectangle> collisionBoxes = new List<Rectangle>();
        //List of collision boxes used for collision

        private Sprite skillbox1,skillbox2,skillbox3,skillbox4, eskillbox1, eskillbox2, eskillbox3, eskillbox4;

        private HealthBar healthbar;
        private HealthBar enemyhealthbar;

        private Song backgroundMusic;

        private Random randomNumber = new Random();
        private int holdRandom;

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
            //Changes the size of the window



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
            font = Content.Load<SpriteFont>("File");
            labTexture = Content.Load<Texture2D>("LabFixed");
            bigTreeTexture = Content.Load<Texture2D>("TreeFixed");
            houseTexture = Content.Load<Texture2D>("HouseFixed");
            playerTexture = Content.Load<Texture2D>("PlayerFixed");
            smallTreeTexture = Content.Load<Texture2D>("TreeFixed");
            grassTexture = Content.Load<Texture2D>("GrassFixed");
            squareTexture = Content.Load<Texture2D>("square");
            camera = new Camera();
            pikaachufront = Content.Load<Texture2D>("Pika-A-chu-fixed");
            pikaachuback= Content.Load<Texture2D>("Pika_Back");
            skillbox = Content.Load<Texture2D>("box");
            battlingfont = Content.Load<SpriteFont>("File");
            fontPika = Content.Load<SpriteFont>("File");
            statsfont = Content.Load<SpriteFont>("File");
            startMenu.hasStarted = false; //makes start menu show when game starts

            playText = new Text(font, "Play", new Vector2((screenWidth / 2) - 50, (screenHeight / 3) + 25), Color.Black);
            exitText = new Text(font, "Exit", new Vector2((screenWidth / 2) - 50, (screenHeight / 3) + 175), Color.Black);
            settingsText = new Text(font, "Settings", new Vector2((screenWidth / 2) - 85, (screenHeight / 3) - 125), Color.Black);
            returnText = new Text(font, "Return", new Vector2((screenWidth / 2) - 85, 75), Color.Black);

            encounterattack = new Text(fontPika, "Attack(T)", new Vector2((screenWidth / 2) - 50, (screenHeight / 3) + 25), Color.Black);
            encounterrun = new Text(fontPika, "Run(L)", new Vector2((screenWidth / 2) - 50, (screenHeight / 3) + 125), Color.Black);
            encounteritem = new Text(fontPika, "Item()", new Vector2((screenWidth / 2) - 50, (screenHeight / 3) + 225), Color.Black);
            encounterchange = new Text(fontPika, "Change Pokemon()", new Vector2((screenWidth / 2) - 50, (screenHeight / 3) + 325), Color.Black);
            
            settingsMenu.settingsHasStarted = false;

            backgroundMusic = Content.Load<Song>("Wii Music - Background Music");

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);

            //The following are TREES
            for (int i = 0; i <= bigTreeTypeSide.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= bigTreeTypeSide.GetUpperBound(1); j++)
                {
                    if (i == 0)
                    {
                        bigTreeTypeSide[i, j] = new Tree(bigTreeTexture, new Vector2(0, j * Window.ClientBounds.Height / bigTreeTypeSide.GetUpperBound(1)), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));
                        //If we're using the first half of the array, then place it on the left side
                    }
                    else
                    {
                        bigTreeTypeSide[i, j] = new Tree(bigTreeTexture, new Vector2(Window.ClientBounds.Width - bigTreeTexture.Width * 2, j * Window.ClientBounds.Height / bigTreeTypeSide.GetUpperBound(1)), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));
                        //If we're using the second half of the array, place the trees on the right side
                    }

                }
                collisionBoxes.Add(new Rectangle((int)bigTreeTypeSide[i, 0].spritePosition.X, (int)bigTreeTypeSide[i, 0].spritePosition.Y, bigTreeTexture.Width * 2 * bigTreeTypeSide.GetUpperBound(1), bigTreeTexture.Height * 2));
                //Regardless of which side, make a rectangle box for each column
                //Add them to the list to be used later for collision
            }

            for (int i = 0; i <= bigTreeTypeBottom.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= bigTreeTypeBottom.GetUpperBound(1); j++)
                {
                    if (i == 0)
                    {
                        bigTreeTypeBottom[i, j] = new Tree(bigTreeTexture, new Vector2(j * Window.ClientBounds.Width / bigTreeTypeBottom.GetUpperBound(1), 0), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));
                        //First half, place the trees on the top
                    }
                    else
                    {
                        bigTreeTypeBottom[i, j] = new Tree(bigTreeTexture, new Vector2(j * Window.ClientBounds.Width / bigTreeTypeBottom.GetUpperBound(1), Window.ClientBounds.Height - bigTreeTexture.Height * 2), new Vector2(bigTreeTexture.Width * 2, bigTreeTexture.Height * 2));
                        //Second half, place the trees on the bottom
                    }
                }
                collisionBoxes.Add(new Rectangle((int)bigTreeTypeBottom[i, 0].spritePosition.X, (int)bigTreeTypeBottom[i, 0].spritePosition.Y, bigTreeTexture.Width * 2, bigTreeTexture.Height * 2 * bigTreeTypeBottom.GetUpperBound(1)));
                //Make rectangles of all of the tree rows
                //Add them to the list so they can be used for collision
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
                }
                collisionBoxes.Add(new Rectangle((int)smallTrees[i, 0].spritePosition.X, (int)smallTrees[i, 0].spritePosition.Y, smallTreeTexture.Width * 2 * smallTrees.GetUpperBound(1), smallTreeTexture.Height));
            }
            //Trees end HERE
            // Jokemon                            - by charles(just in case of merging error, ignore)
            PikaAchu = new Jokemon(pikaachuback, new Vector2(-100, 400), new Vector2(500, 500),100,10,5,10,5,5,"Normal Attack","Iron Tail","Nuzzle","Sneeze");
            Enemy = new Jokemon(pikaachufront, new Vector2(450, -75), new Vector2(500, 500), 100, 10, 5, 10, 5, 5, "Normal Attack", "Iron Tail", "Nuzzle", "Sneeze");
            ownhealth = new Text(statsfont,"health =" + PikaAchu.health.ToString(), new Vector2(0, 550), Color.White);
            ownattack = new Text(statsfont, "atk =" + PikaAchu.attack.ToString(), new Vector2(0, 500), Color.White);
            enemyhealth = new Text(statsfont, "health =" + Enemy.health.ToString(), new Vector2(500, 300), Color.White);
            enemyattack = new Text(statsfont, "atk =" + Enemy.attack.ToString(), new Vector2(500, 350), Color.White);

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

            skillbox1 = new Sprite(skillbox, new Vector2(300, 500), new Vector2(150, 50));
            skillbox2 = new Sprite(skillbox, new Vector2(300, 650), new Vector2(150, 50));
            skillbox3 = new Sprite(skillbox, new Vector2(500, 500), new Vector2(150, 50));
            skillbox4 = new Sprite(skillbox, new Vector2(500, 650), new Vector2(150, 50));

            skill1text = new Text(battlingfont, "Iron Tail", new Vector2(300, 500), Color.Black);
            skill2text = new Text(battlingfont, "Nuzzle", new Vector2(300, 650), Color.Black);
            skill3text = new Text(battlingfont, "Normal Attack", new Vector2(500, 500), Color.Black);
            skill4text = new Text(battlingfont, "Sneeze", new Vector2(500, 650), Color.Black);

            eskillbox1 = new Sprite(skillbox, new Vector2(50, 50), new Vector2(150, 50));
            eskillbox2 = new Sprite(skillbox, new Vector2(50, 200), new Vector2(150, 50));
            eskillbox3 = new Sprite(skillbox, new Vector2(250, 50), new Vector2(150, 50));
            eskillbox4 = new Sprite(skillbox, new Vector2(250, 200), new Vector2(150, 50));

            eskill1text = new Text(battlingfont, "Iron Tail", new Vector2(50, 50), Color.Black);
            eskill2text = new Text(battlingfont, "Nuzzle", new Vector2(50, 200), Color.Black);
            eskill3text = new Text(battlingfont, "Normal Attack", new Vector2(250, 50), Color.Black);
            eskill4text = new Text(battlingfont, "Sneeze", new Vector2(250, 200), Color.Black);

            showattackorder = new Text(fontPika, "test", new Vector2(300, 350), Color.White);
            healthbar = new HealthBar(skillbox, PikaAchu, new Vector2(10, 400));
            enemyhealthbar = new HealthBar(skillbox, Enemy, new Vector2(690, 400));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.G))
                encounterenemy = true;

            // TODO: Add your update logic here
            if (startMenu.hasStarted == true)
            {
                if (iManager.CheckIsPause(screenWidth, screenHeight) == true)
                {
                    settingsMenu.settingsHasStarted = true;
                }
            }
            if (startMenu.hasStarted == false && settingsMenu.settingsHasStarted == false) //wont show anything until space bar is pressed
            {
                startMenu.hasStarted = iManager.CheckStart(screenWidth, screenHeight);
                settingsMenu.settingsHasStarted = iManager.CheckSettings(screenWidth, screenHeight);
                if (iManager.CheckEnd(screenWidth, screenHeight) == true)
                {
                    Exit();
                }
            }
            else if (startMenu.hasStarted == false && settingsMenu.settingsHasStarted == true)
            {
            //Do settings
                settingsMenu.settingsHasStarted = iManager.CheckReturn(screenWidth, screenHeight);
            }
            else if (startMenu.hasStarted == true && settingsMenu.settingsHasStarted == true)
            {
                settingsMenu.settingsHasStarted = iManager.CheckReturn(screenWidth, screenHeight);
                if (iManager.CheckEnd(screenWidth, screenHeight) == true)
                {
                    Exit();
                }
            }
            //This is INGAME
            else if (startMenu.hasStarted == true && settingsMenu.settingsHasStarted == false)
            {

                if (encounterenemy == false)
                {

                    if (Keyboard.GetState().IsKeyDown(Keys.G))
                    {
                        encounterenemy = true;
                    }


                    iManager.checkKeyboard(player);
                        
                      foreach (Rectangle t in collisionBoxes)
                      {
                          pManager.CheckCollisionTrees(player, t);
                      }

                    pManager.CheckCollisionTrees(player, laboratory.playerRectangle);
                    foreach (Building h in houses)
                    {
                        pManager.CheckCollisionTrees(player, h.playerRectangle);
                    }

                foreach (Building b in buildingObjectList)
                    {
                        pManager.checkCollision(player, b);
                    }


                        countFrames = countFrames + 1;

                     if (countFrames >= 60)
                     {
                          countFrames = 0;
                     }

                    foreach (Grass g in grassObjectList)
                    {
                        if (pManager.GrassCollision(g, player) == true)
                        {
                            holdRandom = randomNumber.Next(0, 100);
                            if (holdRandom >= 70 && countFrames == 1)
                            {
                                encounterenemy = true;
                            }
                        }
                    }

                }

                    else if (encounterenemy == true)
                    {
                        if (inJokemonBattle == false)
                        {

                            iManager.checkKeyboard(player);

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

                                battlesystem.Battling(PikaAchu, Enemy, true, skillbox1, skillbox2, skillbox3, skillbox4);
                            }

                                        

                            countFrames = countFrames + 1;

                            if (countFrames >= 60)
                            {
                                countFrames = 0;
                            }
                            PikaAchu.health = 100;
                            PikaAchu.attack = 10;
                            Enemy.health = 100;
                            Enemy.attack = 10;
                        }

                        else if (inJokemonBattle == true)
                        {
                            player.spritePosition = new Vector2(screenWidth / 2 - player.spriteSize.X / 2, screenHeight / 2 - player.spriteSize.Y / 2);
                            enemyhealth.textContent = "health =" + Enemy.health.ToString();
                            ownhealth.textContent = "health =" + PikaAchu.health.ToString();
                            enemyattack.textContent = "atk =" + Enemy.attack.ToString();
                            ownattack.textContent = "atk =" + PikaAchu.attack.ToString();
                            Rectangle mouserec = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
                            Rectangle skillbox1rec = new Rectangle((int)skillbox1.spritePosition.X, (int)skillbox1.spritePosition.Y, (int)skillbox1.spriteSize.X, (int)skillbox1.spriteSize.Y);
                            Rectangle skillbox2rec = new Rectangle((int)skillbox2.spritePosition.X, (int)skillbox2.spritePosition.Y, (int)skillbox2.spriteSize.X, (int)skillbox2.spriteSize.Y);
                            Rectangle skillbox3rec = new Rectangle((int)skillbox3.spritePosition.X, (int)skillbox3.spritePosition.Y, (int)skillbox3.spriteSize.X, (int)skillbox3.spriteSize.Y);
                            Rectangle skillbox4rec = new Rectangle((int)skillbox4.spritePosition.X, (int)skillbox4.spritePosition.Y, (int)skillbox4.spriteSize.X, (int)skillbox4.spriteSize.Y);
                            Rectangle eskillbox1rec = new Rectangle((int)eskillbox1.spritePosition.X, (int)eskillbox1.spritePosition.Y, (int)eskillbox1.spriteSize.X, (int)eskillbox1.spriteSize.Y);
                            Rectangle eskillbox2rec = new Rectangle((int)eskillbox2.spritePosition.X, (int)eskillbox2.spritePosition.Y, (int)eskillbox2.spriteSize.X, (int)eskillbox2.spriteSize.Y);
                            Rectangle eskillbox3rec = new Rectangle((int)eskillbox3.spritePosition.X, (int)eskillbox3.spritePosition.Y, (int)eskillbox3.spriteSize.X, (int)eskillbox3.spriteSize.Y);
                            Rectangle eskillbox4rec = new Rectangle((int)eskillbox4.spritePosition.X, (int)eskillbox4.spritePosition.Y, (int)eskillbox4.spriteSize.X, (int)eskillbox4.spriteSize.Y);
                            if (Keyboard.GetState().IsKeyDown(Keys.Y))
                            {
                                inJokemonBattle = false;
                            }
                            if (userattacking)
                            {
                                showattackorder = new Text(fontPika, "User turn", new Vector2(300, 400), Color.White);
                                if (mouserec.Intersects(skillbox1rec) || mouserec.Intersects(skillbox2rec) || mouserec.Intersects(skillbox3rec) || mouserec.Intersects(skillbox4rec))
                                {
                                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                                    {
                                        Enemy.health -= 10;
                                        enemyhealth.textContent = "health =" + Enemy.health.ToString();
                                        ownhealth.textContent = "health =" + PikaAchu.health.ToString();
                                        enemyattack.textContent = "atk =" + Enemy.attack.ToString();
                                        ownattack.textContent = "atk =" + PikaAchu.attack.ToString();
                                    userattacking = false;
                                        enemyattacking = true;
                                    }
                                }
                            }

                            else if (enemyattacking)
                            {
                                Thread.Sleep(1000);
                                showattackorder = new Text(fontPika, "Enemy turn", new Vector2(300, 400), Color.White);
                                Random rand = new Random();
                                int randomnum = rand.Next(5);
                                if (randomnum == 1)
                                {
                                    PikaAchu.health -= Enemy.attack / 2;
                                    Enemy.health += 2;
                                }
                                else if (randomnum == 2)
                                {
                                    PikaAchu.health -= Enemy.attack;
                                }
                                else if (randomnum == 3)
                                {
                                    Enemy.attack += 6;
                                }
                                else if (randomnum == 4)
                                {
                                    Enemy.health += 5;
                                }
                            else
                            {
                                PikaAchu.health -= Enemy.attack;
                            }
                                
                                userattacking = true;
                                enemyattacking = false;
                                Thread.Sleep(100);
                            }
                        if (PikaAchu.health <= 0 || Enemy.health <= 0)
                            {
                                inJokemonBattle = false;
                                encounterenemy = false;
                            }


                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.L))
                        {
                            encounterenemy = false;
                        }
                    }
                    camera.Follow(player);

                    base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (startMenu.hasStarted == true && settingsMenu.settingsHasStarted == false) //only draws everything else when the tart menu disappears
            {
                if (encounterenemy == false)
                {
                   
                        GraphicsDevice.Clear(Color.LawnGreen);

                        foreach (Tree t in bigTreeTypeSide)
                        {
                            t.DrawSprite(_spriteBatch, t.spriteTexture, camera);
                        }

                        foreach (Tree t in bigTreeTypeBottom)
                        {
                            t.DrawSprite(_spriteBatch, t.spriteTexture, camera);
                        }

                        foreach (Building b in houses)
                        {
                            b.DrawSprite(_spriteBatch, b.spriteTexture, camera);
                        }

                        foreach (Tree t in smallTrees)
                        {
                            t.DrawSprite(_spriteBatch, t.spriteTexture, camera);
                        }


                    foreach (Grass g in jokemonGrass)
                    {
                        g.DrawSprite(_spriteBatch, grassTexture, camera);
                    }

                    laboratory.DrawSprite(_spriteBatch, laboratory.spriteTexture, camera);

                    player.DrawSprite(_spriteBatch, player.spriteTexture, camera);
                }
                else if (encounterenemy == true)
                {
                    if (inJokemonBattle == true)
                    {
                        GraphicsDevice.Clear(Color.DarkBlue);
                        PikaAchu.DrawJokemon(_spriteBatch, pikaachuback);
                        Enemy.DrawJokemon(_spriteBatch, pikaachufront);

                        ownhealth.DrawText(_spriteBatch);
                        ownattack.DrawText(_spriteBatch);
                        enemyhealth.DrawText(_spriteBatch);
                        enemyattack.DrawText(_spriteBatch);
                        skillbox1.DrawSprite(_spriteBatch, skillbox, camera);
                        skillbox2.DrawSprite(_spriteBatch, skillbox, camera);
                        skillbox3.DrawSprite(_spriteBatch, skillbox, camera);
                        skillbox4.DrawSprite(_spriteBatch, skillbox, camera);
                        skill4text.DrawText(_spriteBatch);
                        skill3text.DrawText(_spriteBatch);
                        skill2text.DrawText(_spriteBatch);
                        skill1text.DrawText(_spriteBatch);
                        eskillbox1.DrawSprite(_spriteBatch, skillbox, camera);
                        eskillbox2.DrawSprite(_spriteBatch, skillbox, camera);
                        eskillbox3.DrawSprite(_spriteBatch, skillbox, camera);
                        eskillbox4.DrawSprite(_spriteBatch, skillbox, camera);
                        eskill4text.DrawText(_spriteBatch);
                        eskill3text.DrawText(_spriteBatch);
                        eskill2text.DrawText(_spriteBatch);
                        eskill1text.DrawText(_spriteBatch);
                        healthbar.DrawHealth(_spriteBatch, PikaAchu);
                        enemyhealthbar.DrawHealth(_spriteBatch, Enemy);
                        showattackorder.DrawText(_spriteBatch);
                    }
                    else
                    {
                        GraphicsDevice.Clear(Color.DarkGreen);
                        encounterattack.DrawText(_spriteBatch);
                        encounterrun.DrawText(_spriteBatch);
                        encounteritem.DrawText(_spriteBatch);
                        encounterchange.DrawText(_spriteBatch);
                    }
                }
            }
            if(startMenu.hasStarted == true)
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(squareTexture, new Rectangle(0, 0, 50, 50), Color.HotPink); //pause button
                _spriteBatch.End();
            }
            if(startMenu.hasStarted == false && settingsMenu.settingsHasStarted == true)
            {
                GraphicsDevice.Clear(Color.OrangeRed);
                _spriteBatch.Begin();
                _spriteBatch.Draw(squareTexture, new Rectangle((screenWidth / 2) - 100, 50, 200, 100), Color.White); //return button
                _spriteBatch.End();

                returnText.DrawText(_spriteBatch);
            }
            if (startMenu.hasStarted == true && settingsMenu.settingsHasStarted == true)
            {
                GraphicsDevice.Clear(Color.OrangeRed);
                _spriteBatch.Begin();
                _spriteBatch.Draw(squareTexture, new Rectangle((screenWidth / 2) - 100, 50, 200, 100), Color.White); //return button
                _spriteBatch.Draw(squareTexture, new Rectangle((screenWidth / 2) - 100, (screenHeight / 3) + 150, 200, 100), Color.White); //exit button
                _spriteBatch.End();

                exitText.DrawText(_spriteBatch);
                returnText.DrawText(_spriteBatch);
            }
            if (startMenu.hasStarted == false && settingsMenu.settingsHasStarted == false) //draws start menu
            {
                GraphicsDevice.Clear(Color.Purple);
                _spriteBatch.Begin();
                _spriteBatch.Draw(squareTexture, new Rectangle((screenWidth / 2) - 200, screenHeight / 3, 400, 100), Color.HotPink); //play button
                _spriteBatch.Draw(squareTexture, new Rectangle((screenWidth / 2) - 100, (screenHeight / 3) + 150, 200, 100), Color.White); //exit button
                _spriteBatch.Draw(squareTexture, new Rectangle((screenWidth / 2) - 150, (screenHeight / 3) - 150, 300, 100), Color.White); //settings button
                _spriteBatch.End();

                playText.DrawText(_spriteBatch);
                exitText.DrawText(_spriteBatch);
                settingsText.DrawText(_spriteBatch);
            }
            // TODO: Add your drawing code here




            base.Draw(gameTime);
        }
    }
}
