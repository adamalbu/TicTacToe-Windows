using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{

    public partial class Game : Form
    {
        private GameInfo _gameInfo;
        public Game()
        {
            InitializeComponent();
            _gameInfo = new GameInfo();
        }

        
        public void Form1_Load(object sender, EventArgs e)
        {
            Settingspanel.Visible = false;
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            {
                if (_gameInfo.TwoPlayer == true)
                {

                    if (_gameInfo.PlayerOGo == true && btn.Text == "")
                    {
                        btn.Text = "O";
                        _gameInfo.PlayerOGo = false;
                        _gameInfo.Go = false;
                    }
                    else if (_gameInfo.PlayerOGo == false && btn.Text == "")
                    {
                        btn.Text = "X";
                        _gameInfo.PlayerOGo = true;
                        _gameInfo.Go = false;
                    }
                    else if (btn.Text != "")
                    {
                        MessageBox.Show("That box is alredy occupied");
                    }
                }
                else
                {
                    _gameInfo.PlayerOGo = true;
                    if (_gameInfo.PlayerOGo == true && btn.Text == "")
                    {
                        btn.Text = "O";
                        _gameInfo.PlayerOGo = false;
                        _gameInfo.Go = false;
                    }
                    else
                    {
                        MessageBox.Show("That box is alredy occupied");
                    }
                    if (_gameInfo.PlayerOGo == false)
                    {
                        _gameInfo.Go = true;
                        Win();
                        Block();
                    }
                }
                if (S1.Text != "" && S2.Text != "" &&
                    S3.Text != "" && S4.Text != "" &&
                    S5.Text != "" && S6.Text != "" &&
                    S7.Text != "" && S8.Text != "" && S9.Text != "")
                {
                    MessageBox.Show("Draw!");
                    ClearBoard();
                }


                CheckAllTiles();
            }
            _gameInfo.Go = true;
        }
        private void Win()
        {

        }

        private void Block()
        {
            ThreeCheck(S1, S2, S3);
            ThreeCheck(S4, S5, S6);
            ThreeCheck(S7, S8, S9);
            ThreeCheck(S1, S4, S7);
            ThreeCheck(S2, S5, S8);
            ThreeCheck(S3, S6, S9);
            ThreeCheck(S3, S5, S7);
            ThreeCheck(S1, S5, S9);
            EmptyMethod(S1);
            EmptyMethod(S2);
            EmptyMethod(S3);
            EmptyMethod(S4);
            EmptyMethod(S5);
            EmptyMethod(S6);
            EmptyMethod(S7);
            EmptyMethod(S8);
            EmptyMethod(S9);
        }
        private void EmptyMethod(Button btn)
        {
            if (btn.Text == "" && _gameInfo.Go == true)
            {
                btn.Text = "X";
                _gameInfo.Go = false;   
            }
        }
        private void ThreeCheck(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Text == "O" || btn2.Text == "O" || btn3.Text == "O")
            {
                OneCheck(btn1, btn2, btn3);
                OneCheck(btn1, btn3, btn2);
                OneCheck(btn2, btn1, btn3);
                OneCheck(btn2, btn3, btn1);
                OneCheck(btn3, btn2, btn1);
                OneCheck(btn3, btn1, btn2);
            }
        }

        private void OneCheck(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Text == "O" && _gameInfo.Go == true)
            {
                if (btn2.Text == "O" && _gameInfo.Go == true && btn3.Text == "")
                {
                    btn3.Text = "X";
                    _gameInfo.Go = false;
                }
                else if (btn3.Text == "O" && _gameInfo.Go == true && btn2.Text == "")
                {
                    btn2.Text = "X";
                    _gameInfo.Go = false;
                }
            }
        }

        private void CheckAllTiles()
        {
            WinnerCheck(S1, S2, S3);
            WinnerCheck(S4, S5, S6);
            WinnerCheck(S7, S8, S9);
            WinnerCheck(S1, S5, S9);
            WinnerCheck(S7, S5, S3);
            WinnerCheck(S1, S4, S7);
            WinnerCheck(S2, S5, S8);
            WinnerCheck(S3, S6, S9);
        }

        private void WinnerCheck(Button tile1, Button tile2, Button tile3)
        {
            if (tile1.Text == "O" && tile2.Text == "O" && tile3.Text == "O")
            {
                _gameInfo.ScorePlayerO++;
                SFO.Text = _gameInfo.ScorePlayerO.ToString();
                MessageBox.Show("Player O wins!");
                ClearBoard();
            }
            else if (tile1.Text == "X" && tile2.Text == "X" && tile3.Text == "X")
            {
                _gameInfo.ScorePlayerX++;
                SFX.Text = _gameInfo.ScorePlayerX.ToString();
                MessageBox.Show("Player X wins!");
                ClearBoard();
            }
        }

        private void ClearBoard()
        {
            S1.Text = "";
            S2.Text = "";
            S3.Text = "";
            S4.Text = "";
            S5.Text = "";
            S6.Text = "";
            S7.Text = "";
            S8.Text = "";
            S9.Text = "";
            _gameInfo.PlayerOGo = true;
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            ClearBoard();
        }

        private void ResetTiles()
        {
            _gameInfo.ScorePlayerO = 0;
            _gameInfo.ScorePlayerX = 0;
            SFO.Text = "0";
            SFX.Text = "0";
            ClearBoard();
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            ResetTiles();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (_gameInfo.settingsToggle == true)
            {
                Settingspanel.Visible = true;
                _gameInfo.settingsToggle = false;
            }
            else
            {
                Settingspanel.Visible = false;
                _gameInfo.settingsToggle = true;
            }
        }

        private void BgColorChange(Color color)
        {
            Bg.BackColor = color;
        }

        private void YellowBg_CheckedChanged(object sender, EventArgs e)
        {
            BgColorChange(Color.Yellow);
        }

        private void GreenBg_CheckedChanged(object sender, EventArgs e)
        {
            BgColorChange(Color.Green);
        }

        private void RedBg_CheckedChanged(object sender, EventArgs e)
        {
            BgColorChange(Color.Red);
        }

        private void BlueBg_CheckedChanged(object sender, EventArgs e)
        {
            BgColorChange(Color.Blue);
        }
        private void FgColorChange(Color color)
        {
            Header.BackColor = color;
            Body.BackColor = color;
            Title.BackColor = color;
        }

        private void YellowFg_CheckedChanged(object sender, EventArgs e)
        {
            FgColorChange(Color.Gold);
        }

        private void GreenFg_CheckedChanged(object sender, EventArgs e)
        {
            FgColorChange(Color.DarkGreen);
        }

        private void RedFg_CheckedChanged(object sender, EventArgs e)
        {
            FgColorChange(Color.DarkRed);
        }

        private void BlueFg_CheckedChanged(object sender, EventArgs e)
        {
            FgColorChange(Color.DarkBlue);
        }

        private void BtnColorChange(Color color)
        {
            S1.BackColor = color;
            S2.BackColor = color;
            S3.BackColor = color;
            S4.BackColor = color;
            S5.BackColor = color;
            S6.BackColor = color;
            S7.BackColor = color;
            S8.BackColor = color;
            S9.BackColor = color;
        }

        private void YellowBtn_CheckedChanged(object sender, EventArgs e)
        {
            BtnColorChange(Color.LightYellow);
            Clear.BackColor = Color.Peru;
        }

        private void GreenBtn_CheckedChanged(object sender, EventArgs e)
        {
            BtnColorChange(Color.LightGreen);
            Clear.BackColor = Color.DarkSeaGreen;
        }

        private void RedBtn_CheckedChanged(object sender, EventArgs e)
        {
            BtnColorChange(Color.LightCoral);
            Clear.BackColor = Color.Crimson;
        }

        private void BlueBtn_CheckedChanged(object sender, EventArgs e)
        {
            BtnColorChange(Color.LightBlue);
            Clear.BackColor = Color.MediumBlue;
        }
        private void ScoreColorChange(Color color)
        {
            Player_O.BackColor = color;
            Player_X.BackColor = color;
            SFO.BackColor = color;
            SFX.BackColor = color;
        }

        private void YellowSc_CheckedChanged(object sender, EventArgs e)
        {
            ScoreColorChange(Color.Goldenrod);
        }
        private void GreenSc_CheckedChanged(object sender, EventArgs e)
        {
            ScoreColorChange(Color.DarkOliveGreen);
        }
        private void RedSc_CheckedChanged(object sender, EventArgs e)
        {
            ScoreColorChange(Color.Maroon);
        }
        private void BlueSc_CheckedChanged(object sender, EventArgs e)
        {
            ScoreColorChange(Color.MidnightBlue);
        }

        private void YellowAll_CheckedChanged(object sender, EventArgs e)
        {
            YellowBg.Checked = true;
            YellowFg.Checked = true;
            YellowBtn.Checked = true;
            YellowSc.Checked = true;
        }

        private void GreenAll_CheckedChanged(object sender, EventArgs e)
        {
            GreenBg.Checked = true;
            GreenFg.Checked = true;
            GreenBtn.Checked = true;
            GreenSc.Checked = true;
        }

        private void AllRed_CheckedChanged(object sender, EventArgs e)
        {
            RedBg.Checked = true;
            RedFg.Checked = true;
            RedBtn.Checked = true;
            RedSc.Checked = true;
        }

        private void BlueAll_CheckedChanged(object sender, EventArgs e)
        {
            BlueBg.Checked = true;
            BlueFg.Checked = true;
            BlueBtn.Checked = true;
            BlueSc.Checked = true;
        }

        private void PlayerModeSwich_Click(object sender, EventArgs e)
        {
            if (_gameInfo.TwoPlayer == true)
            {
                _gameInfo.TwoPlayer = false;
                PlayerModeSwich.BackColor = Color.Lime;
                PlayerModeSwich.Text = "Disable one-player mode";
            }
            else
            {
                _gameInfo.TwoPlayer = true;
                PlayerModeSwich.BackColor = Color.Maroon;
                PlayerModeSwich.Text = "Enable one-player mode";
            }
            ResetTiles();
            
        }
    }


    
}
