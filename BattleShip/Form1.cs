namespace BattleShip
{
    public partial class Form1 : Form
    {
        
        int _ship1;
        int _ship2;
        int _ship3;
        int _Computership1;
        int _Computership2;
        int _Computership3;
        int _turnCheck;
        PictureBox[] _playerGameBoard = new PictureBox[100];
        PictureBox[] _computerGameBoard = new PictureBox[100];
        string[] _IfComputerHitPlayer = new string[100];//E = empty, H = hit, M = miss
        string[] _IfPlayerHitComputer = new string[100];//E = empty, H = hit, M = miss
        string loction = "C:/repos/Teaching/C#/explosion-sprite.png";
        
        public Form1()
        {
            InitializeComponent();
        

        }
        public int LocationCheck(int check)//this determines if my Ships are in the right location and not going off the board 
        {
            if ((check + 1) % 10 == 0)
            {

                check -= 1;
                return check;
            }
            else
            {
                return check;
            }
           
        }

        private bool WinCheck()
        {
            
            if (_IfPlayerHitComputer[_Computership1] == "H" && _IfPlayerHitComputer[_Computership2] == "H" && _IfPlayerHitComputer[_Computership3] == "H" && _IfPlayerHitComputer[_Computership1 + 10] == "H" && _IfPlayerHitComputer[_Computership2 + 1] == "H" && _IfPlayerHitComputer[_Computership3 + 1] == "H")
            {
                MessageBox.Show("You win!!");
                ClearBoard();
                return true;
            }
            else if (_IfComputerHitPlayer[_ship1] == "H" && _IfComputerHitPlayer[_ship2] == "H" && _IfComputerHitPlayer[_ship3] == "H"&& _IfComputerHitPlayer[_ship1 +10] == "H" && _IfComputerHitPlayer[_ship2 +1] == "H" && _IfComputerHitPlayer[_ship3 +1] == "H")
            { 
                MessageBox.Show("Computer wins!!");
                ClearBoard();
               return true;

            }
            else
            {
                return false;
            }
            
        }
        private void RandomAssignement()
        {
            var random = new Random();
            
            _ship1 =  random.Next(1, 90);//54 - 63 allows us to assign a random location for our ships
            _ship2 = random.Next(1, 100);
            _ship3 = random.Next(1, 100);
            _Computership1 = random.Next(1, 90);
            _Computership2 = random.Next(1, 100);
            _Computership3 = random.Next(1, 100);
            _ship2 = LocationCheck(_ship2);//if it is off the board move back 1
            _ship3 = LocationCheck(_ship3);
            _Computership2 = LocationCheck(_Computership2);
            _Computership3 = LocationCheck(_Computership3);
            OverlapCheck();
           
        }
        private void ClearBoard()
        {
            RandomAssignement();
            OverlapCheck();
            for (int i = 0; i < _playerGameBoard.Length; i++)
            {             
                _IfComputerHitPlayer[i] = "E";
                _playerGameBoard[i].Image = Image.FromFile("C:/repos/Teaching/C#/geometric-camouflage-seamless-pattern-abstract-260nw-1305564859.jpg");
                _IfPlayerHitComputer[i] = "E";
                _computerGameBoard[i].Image = Image.FromFile("C:/repos/Teaching/C#/geometric-camouflage-seamless-pattern-abstract-260nw-1305564859.jpg");
            }
     
               

            _playerGameBoard[_ship1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle-Verticle.png");
            _playerGameBoard[_ship1].Size = new Size(45, 45);
            _playerGameBoard[_ship1 + 10].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle-VerticleBottom.png");
            _playerGameBoard[_ship1].Size = new Size(45, 45);


            _playerGameBoard[_ship2].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle.png");
            _playerGameBoard[_ship2].Size = new Size(45, 45);
            _playerGameBoard[_ship2 + 1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middleLeft.png");
            _playerGameBoard[_ship2].Size = new Size(45, 45);

            _playerGameBoard[_ship3].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle.png");
            _playerGameBoard[_ship3].Size = new Size(45, 45);
            _playerGameBoard[_ship3 + 1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middleLeft.png");
            _playerGameBoard[_ship3].Size = new Size(45, 45);

            //Computer ships for demonstration

            _computerGameBoard[_Computership1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle-Verticle.png");
            _computerGameBoard[_Computership1].Size = new Size(45, 45);
            _computerGameBoard[_Computership1 + 10].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle-VerticleBottom.png");
            _computerGameBoard[_Computership1].Size = new Size(45, 45);


            _computerGameBoard[_Computership2].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle.png");
            _computerGameBoard[_Computership2].Size = new Size(45, 45);
            _computerGameBoard[_Computership2 + 1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middleLeft.png");
            _computerGameBoard[_Computership2].Size = new Size(45, 45);

            _computerGameBoard[_Computership3].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle.png");
            _computerGameBoard[_Computership3].Size = new Size(45, 45);
            _computerGameBoard[_Computership3 + 1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middleLeft.png");
            _computerGameBoard[_Computership3].Size = new Size(45, 45);


        }
        private void OverlapCheck() 
        {
            if (_ship1 == _ship2 || _ship1 == _ship3 || _ship3 == _ship2)
            {
                RandomAssignement();
            }
            if (_ship1 + 10 == _ship2 || _ship1 + 10 == _ship3 || _ship1 + 10 == _ship2 + 1 || _ship1 + 10 == _ship3 + 1)
            {
                RandomAssignement();
            }
            if (_ship3 + 1 == _ship2 || _ship3 + 1 == _ship2 + 1 || _ship2 + 1 == _ship3 || _ship1 == _ship2 + 1 || _ship1 == _ship3 + 1)
            {
                RandomAssignement();
            }

            if (_Computership1 == _Computership2 || _Computership1 == _Computership3 || _Computership3 == _Computership2)
            {
                RandomAssignement();
            }
            if (_Computership1 + 10 == _Computership2 || _Computership1 + 10 == _Computership3 || _Computership1 + 10 == _Computership2 + 1 || _Computership1 + 10 == _Computership3 + 1)
            {
                RandomAssignement();
            }
            if (_Computership3 + 1 == _Computership2 || _Computership3 + 1 == _Computership2 + 1 || _Computership2 + 1 == _Computership3 || _Computership1 == _Computership2 + 1 || _Computership1 == _Computership3 + 1)
            {
                RandomAssignement();
            }
        }
        public void PrintBoard()
        {
          
            int positionX = 45;
            int positionY = 100;
            int _counter = 1;
            RandomAssignement();
          
            for (int i = 0; i < _playerGameBoard.Length; i++)//player game board
            {
                positionX += 45; //set position number on the x axis
                _IfComputerHitPlayer[i] = "E";//make associated array empty
                _playerGameBoard[i] = new PictureBox();// make the new picture box object
                _playerGameBoard[i].Name = "pictureBox" + i.ToString();//set the name of each picture box
                _playerGameBoard[i].Location = new Point(positionX , positionY);// set the location
                _playerGameBoard[i].Size = new Size(43, 43);// make the pic box size
                    _playerGameBoard[i].Image = Image.FromFile("C:/repos/Teaching/C#/geometric-camouflage-seamless-pattern-abstract-260nw-1305564859.jpg");//choose the picture box image
                _playerGameBoard[i].Visible = true;//make it visible
              this.Controls.Add(_playerGameBoard[i]);//add the controls so the picture box is usable on the form 
                if (_counter == 10)// sets each row 
                {
                    positionY += 45;//adds to the position y
                    positionX = 45;// resets x
                    _counter = 0;// resets the row counter
                }
                _counter++;//row counter ++
            }
             positionX = 645;
             positionY = 100;
            for (int i = 0; i < _computerGameBoard.Length; i++)              
            {
                positionX += 45;
                _IfPlayerHitComputer[i] = "E";
                _computerGameBoard[i] = new PictureBox();
               
                        _computerGameBoard[i].Name = "pictureBox" + i.ToString();//pictureBox0, pictureBox1, picturebox2
                
                        _computerGameBoard[i].Location = new Point(positionX , positionY);
               
                        _computerGameBoard[i].Size = new Size(43, 43);
                
                        _computerGameBoard[i].Image = Image.FromFile("C:/repos/Teaching/C#/geometric-camouflage-seamless-pattern-abstract-260nw-1305564859.jpg");
                
                        _computerGameBoard[i].Visible = true;
                _computerGameBoard[i].Click += this.PictureBoxClick;
                this.Controls.Add(_computerGameBoard[i]);

              if (_counter  == 10)
                {
                    positionY += 45;
                    positionX = 645;
                    _counter = 0;
                }
                _counter++;

            }
           
                _playerGameBoard[_ship1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle-Verticle.png");
            _playerGameBoard[_ship1].Size = new Size(45, 45);
            _playerGameBoard[_ship1 + 10].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle-VerticleBottom.png");
            _playerGameBoard[_ship1 + 10].Size = new Size(45, 45);

            _playerGameBoard[_ship2].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle.png");
            _playerGameBoard[_ship2].Size = new Size(45, 45);

            _playerGameBoard[_ship2 + 1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middleLeft.png");
            _playerGameBoard[_ship2 + 1].Size = new Size(45, 45);

            _playerGameBoard[_ship3 ].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle.png");
            _playerGameBoard[_ship3].Size = new Size(45, 45);

            _playerGameBoard[_ship3 + 1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middleLeft.png");
            _playerGameBoard[_ship3 + 1].Size = new Size(45, 45);



            //Computer ships for demonstration

           /* _computerGameBoard[_Computership1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle-Verticle.png");
            _computerGameBoard[_Computership1].Size = new Size(45, 45);
            _computerGameBoard[_Computership1 + 10].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle-VerticleBottom.png");
            _computerGameBoard[_Computership1].Size = new Size(45, 45);


            _computerGameBoard[_Computership2].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle.png");
            _computerGameBoard[_Computership2].Size = new Size(45, 45);
            _computerGameBoard[_Computership2 + 1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middleLeft.png");
            _computerGameBoard[_Computership2].Size = new Size(45, 45);

            _computerGameBoard[_Computership3].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middle.png");
            _computerGameBoard[_Computership3].Size = new Size(45, 45);
            _computerGameBoard[_Computership3 + 1].Image = Image.FromFile("C:/repos/Teaching/C#/318016-middleLeft.png");
            _computerGameBoard[_Computership3].Size = new Size(45, 45);
*/



        }
        private void ComputersTurn()
        {
            var random = new Random();
            int _computersAttack = random.Next(0, 99);
          

  
            if ((_computersAttack == _ship1 || _computersAttack == _ship2 || _computersAttack == _ship3 || _computersAttack == _ship1 + 10 || _computersAttack == _ship2 + 1 || _computersAttack == _ship3 + 1) && _IfComputerHitPlayer[_computersAttack] == "E")
            {
                MessageBox.Show("Direct Hit!");
                _playerGameBoard[_computersAttack].Image = Image.FromFile("C:/repos/Teaching/C#/explosion-sprite.png");
                _IfComputerHitPlayer[_computersAttack] = "H";               
            }
            else if (_IfComputerHitPlayer[_computersAttack] == "E")
            {
                _IfComputerHitPlayer[_computersAttack] = "M";

                _playerGameBoard[_computersAttack].Image = Image.FromFile("C:/repos/Teaching/C#/download.jfif");
            }
            else
            {
                MessageBox.Show("Computer hit alrady");
                ComputersTurn();
               
            }
            if (WinCheck() == true)
            {
                TurnCheck();
                return;
            }
        }
        private bool TurnCheck()
        {
            var random = new Random();
            _turnCheck = random.Next(1, 10);// this allows us to assign a turn
            if (_turnCheck % 2 == 0)
            {
                MessageBox.Show("Its your turn!");              
                return true;
            }
            else
            {
                MessageBox.Show("Its the Computers turn!");
                return false;


            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PrintBoard();
            
            if (TurnCheck() == false)
            {
                ComputersTurn();
            }
        }
        private void PictureBoxClick(object sender, EventArgs e)
        {
            var picBoxName = ((PictureBox)sender).Name;//
            string stringRemove = picBoxName.Substring(10);//  picturebox  13
            int PictureBoxNumberThatWasAttacked = Convert.ToInt32(stringRemove);//
         
            if ((PictureBoxNumberThatWasAttacked == _Computership1 || PictureBoxNumberThatWasAttacked == _Computership2 || PictureBoxNumberThatWasAttacked == _Computership3 || PictureBoxNumberThatWasAttacked == _Computership1 + 10 || PictureBoxNumberThatWasAttacked == _Computership2 + 1|| PictureBoxNumberThatWasAttacked == _Computership3 + 1) && _IfPlayerHitComputer[PictureBoxNumberThatWasAttacked] == "E")
            {
                MessageBox.Show("Direct Hit!");
                _computerGameBoard[PictureBoxNumberThatWasAttacked].Image = Image.FromFile("C:/repos/Teaching/C#/explosion-sprite.png");
                _IfPlayerHitComputer[PictureBoxNumberThatWasAttacked] = "H";
            }
            else if (_IfPlayerHitComputer[PictureBoxNumberThatWasAttacked] == "E")
            {
                MessageBox.Show("You Missed!");
                _computerGameBoard[PictureBoxNumberThatWasAttacked].Image = Image.FromFile("C:/repos/Teaching/C#/download.jfif");
                _IfPlayerHitComputer[PictureBoxNumberThatWasAttacked] = "M";

            }
            else
            {
                MessageBox.Show("You already hit this one try again!");
                return;
            }
            if (WinCheck() == true)
            {
                TurnCheck();
                return;
            } 
            MessageBox.Show("Computers Turn");
            ComputersTurn();
        }
    }
}