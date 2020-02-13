using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class FormMain : Form
    {
        private bool bEBL1 = false, bEBL2 = false, bEBL3 = true, bEBL4 = true, NGUON = false;
        private bool  HLF = false;
        private int iDrawEllipse = 60, iDrawLine1 = 90, iDrawLine2 = 40, a, b;
        private int iDrawEllipse2 = 100, n = -135, n2 = -140;
        private int iMoverButton = 410, iCountThread; //vi trí button

        private Point TamHinhTron = new Point() { X = 250, Y = 250 }; // tam cua hinh tròn
        private Point TamPanel = new Point() { X = 250, Y = 280 }; //tam cua cả cái panel
        private Point TamHinhTron2 = new Point() { X = 273, Y = 264 };

        private Point ToaDoChuotHienTai = new Point();
        private Point ToaDoChuotKhiAnButton = new Point();
        private Point ToaDoChuotVeVungBaoDong1 = new Point();
        private Point ToaDoChuotVeVungBaoDong2 = new Point();
        private Size KichThuocHinhTron = new Size() { Width = 501, Height = 501 };

        Timer t = new Timer();
        int width = 500, height = 500, hand = 250;
        int u, number, number2;
        int cx, cy;
        int x, y;
        Pen p, penRed, penYellow, z;
        Graphics g;
        Bitmap bmp;

        public FormMain()
        {
            InitializeComponent();
            setHinhTron();               
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if(NGUON)
            this.BackColor = Color.Black;
            cx = width / 2;
            cy = height / 2;
            u = 0;
            t.Interval = 30;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
            number = n * 2;
            number2 = n * 2; 
        }


        // phần a mới thêm 23/02
        private void setHinhTron()
        {
            bmp = new Bitmap(KichThuocHinhTron.Width,KichThuocHinhTron.Height);
            g = Graphics.FromImage(bmp);
            g.TranslateTransform(0, 0);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0,KichThuocHinhTron.Width,KichThuocHinhTron.Height);
            Region region = new Region(path);
            g.SetClip(region, CombineMode.Replace);         
        }



        private void t_Tick(object sender, EventArgs e)
        {
           
            p = new Pen(Color.Green, 1f);
            z = new Pen(Color.Green, 1f);
            penRed = new Pen(Color.Yellow, 1f);
            penYellow = new Pen(Color.Yellow, 1f);
            //nut nguon bat
            g.Clear(Color.FromArgb(iSetContr, Color.Gray));

            ChonTrangThai();


            VeDuongCung(g);


            //hien do EBL1,2
            if (iDrawLine1 >= 0 && iDrawLine2 >= 0)
            {
                lbebl1.Text = "" + iDrawLine1.ToString();
                lbebl2.Text = "" + iDrawLine2.ToString();
            }
            if (iDrawLine1 <= 0 && iDrawLine2 <= 0)
            {
                lbebl1.Text = "" + (iDrawLine1 + 360).ToString();
                lbebl2.Text = "" + (iDrawLine2 + 360).ToString();

            }
            if (iDrawLine1 <= 0 && iDrawLine2 > 0)
            {
                lbebl1.Text = "" + (iDrawLine1 + 360).ToString();
                lbebl2.Text = "" + iDrawLine2.ToString();
            }
            if (iDrawLine1 > 0 && iDrawLine2 <= 0)
            {
                lbebl1.Text = "" + iDrawLine1.ToString();
                lbebl2.Text = "" + (iDrawLine2 + 360).ToString();
            }
            if (iCountThread >= 400)
            {
                if (u % 4 == 0)
                    ButtonMove();
            }


            // HIEN HLF
            if (HLF)
            {
                g.DrawLine(p, new Point(cx, 80), new Point(cx, height));
            }

            iCountThread++;
            PICBOX1.Image = bmp;
            p.Dispose();

            u++;
            if (u == 360)
            {
                u = 0;
            }
        }
        #region Phương thức


        // lấy tọa độ vòng tròn để vẽ đường line, 
        private Point getPointDrawLine(int iRow, Point pTamHinhTron, int iHand)
        {
            if (iRow >= 0 && iRow <= 180)
            {
                x = pTamHinhTron.X + (int)(iHand * Math.Sin(Math.PI * iRow / 180));
                y = pTamHinhTron.Y - (int)(iHand * Math.Cos(Math.PI * iRow / 180));
                return new Point(x, y);
            }
            else
            {
                x = pTamHinhTron.X - (int)(iHand * -Math.Sin(Math.PI * iRow / 180));
                y = pTamHinhTron.Y - (int)(iHand * Math.Cos(Math.PI * iRow / 180));
                return new Point(x, y);
            }
        }

        private void VeDuongCung(Graphics g)
        {
            // vẽ đường cung  
            int r = 320;  // hay dổi kích cỡ cung 
            Pen pDrawArc = new Pen(Color.White, 1f); // 25f thay đổi độ dày mỏng đường vẽ
            Rectangle rRec = new Rectangle() { Height = r, Width = r, X = width / 2 - r / 2, Y = height / 2 - r / 2 };
            g.DrawArc(pDrawArc, rRec, -35, 40);  // thay đổi cung

            r = 50; 
            rRec = new Rectangle() { Height = r, Width = r, X = width / 2 - r / 2, Y = height / 2 - r / 2 };
            g.DrawArc(pDrawArc, rRec, -35, 40);  // thay đổi cung

            g.DrawLine(pDrawArc, getPointDrawLine(55, TamHinhTron, 30), getPointDrawLine(55, TamHinhTron, 160));
            g.DrawLine(pDrawArc, getPointDrawLine(95, TamHinhTron, 30), getPointDrawLine(95, TamHinhTron, 160));

        }

        private void VeCacVongTron()
        {
            int iSizeDrawArc = 80;
           
            if (NGUON)
            for (int i = 1; i < 3; i++)
            {
                g.DrawEllipse(p, iSizeDrawArc * i, iSizeDrawArc * i, width - iSizeDrawArc * i * 2, height - iSizeDrawArc * i * 2);
                g.DrawEllipse(z, 1, 1, width-1 , height -1);
                
            }
        }


        private void VeVongTronCoTheThayDoi()
        {
            // vẽ 2 vòng tròn
            if (bEBL1)
            {
                if (iDrawEllipse >= 0 && iDrawEllipse <= 280)
                {
                    g.DrawEllipse(penRed, iDrawEllipse, iDrawEllipse, width - iDrawEllipse * 2, width - iDrawEllipse * 2);
                }

            }
            if (bEBL2)
            {
                if (iDrawEllipse2 >= 0 && iDrawEllipse2 <= 280)
                {
                    g.DrawEllipse(penRed, iDrawEllipse2, iDrawEllipse2, width - iDrawEllipse2 * 2, width - iDrawEllipse2 * 2);
                }
            }
        }


        private void VeVongTronCoTheThayDoiTH1(Point ToaDoChuot)
        {
            // vẽ 2 vòng tròn
            if (bEBL1)
            {
                if (iDrawEllipse >= 0 && iDrawEllipse <= 280)
                {
                    int iDrawEllipseNew = 280 - iDrawEllipse;
                    Rectangle rect = new Rectangle() { Width = iDrawEllipseNew, Height = iDrawEllipseNew, X = ToaDoChuot.X - (iDrawEllipseNew / 2), Y = ToaDoChuot.Y - (iDrawEllipseNew / 2) };
                    g.DrawArc(penRed, rect, 0, 360);
                }

            }
            if (bEBL2)
            {
                if (iDrawEllipse2 >= 0 && iDrawEllipse2 <= 280)
                {
                    int iDrawEllipseNew = 280 - iDrawEllipse2;
                    Rectangle rect = new Rectangle() { Width = iDrawEllipseNew, Height = iDrawEllipseNew, X = ToaDoChuot.X - (iDrawEllipseNew / 2), Y = ToaDoChuot.Y - (iDrawEllipseNew / 2) };
                    g.DrawArc(penRed, rect, 0, 360);
                }
            }
        }

        private void VeDauCong(Point ToaDoChuot)
        {
            g.DrawLine(penYellow, new Point(ToaDoChuot.X - 100, ToaDoChuot.Y), new Point(ToaDoChuot.X + 20, ToaDoChuot.Y));
            g.DrawLine(penYellow, new Point(ToaDoChuot.X, ToaDoChuot.Y - 100), new Point(ToaDoChuot.X, ToaDoChuot.Y + 10));

        }

        private void VeDuongLineCoTheThayDoi(Point pTamHinhTron)
        {
            if (NGUON == true)
            {
                //vẽ 2 đường line
                if (bEBL3)
                {
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1, TamHinhTron, hand));
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1 + 30, TamHinhTron, hand ));
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1 + 60, TamHinhTron, hand));
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1 + 90, TamHinhTron, hand));
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1 + 120, TamHinhTron, hand));
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1 + 150, TamHinhTron, hand));
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1 + 180, TamHinhTron, hand));
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1 + 210, TamHinhTron, hand));
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1 + 240, TamHinhTron, hand));
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1 + 270, TamHinhTron, hand));
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1 + 300, TamHinhTron, hand));
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine1 + 330, TamHinhTron, hand));
                }

                if (bEBL4)
                {
                    g.DrawLine(p, pTamHinhTron, getPointDrawLine(iDrawLine2, TamHinhTron, hand*2));
                }
            }
        }

      
        // kiểm tra xem toa độ chuot co nam ngoai dung tron hay không 
        double iR, iX, iY;
        private bool CheckDrawEllipse(Point pValue)
        {
            if (pValue.X < TamHinhTron2.X) iX = TamHinhTron2.X - pValue.X;
            else iX = pValue.X - TamPanel.X - 20;
            if (pValue.Y < TamHinhTron2.Y) iY = TamHinhTron2.Y - pValue.Y;
            else iY = pValue.Y - TamHinhTron2.Y;
            iR = (double)Math.Sqrt(iX * iX + iY * iY);
            if (iR <= 250)  //  là bán kính của vòng tròn, 
            {
                
                return true;
               
            }
           
            return false;
        }

        private int iRow(Point pValue)
        {
            double iCorner = (double)(Math.Asin(iX / iR) * (180 / Math.PI));
            if (pValue.X >= TamHinhTron2.X && pValue.Y >= TamHinhTron2.Y)
            {
                iCorner = (90 - iCorner) + 90;
            }
            if (pValue.X < TamHinhTron2.X && pValue.Y >= TamHinhTron2.Y)
            {
                iCorner += 180;
            }
            if (pValue.X < TamHinhTron2.X && pValue.Y < TamHinhTron2.Y)
            {
                iCorner = (90 - iCorner) + 271;
            }

            return (int)iCorner;
        }

        private int iRow2(Point pValue)
        {
            double iXr,iYr,iRr;
            if (pValue.X < TamHinhTron2.X) iXr = TamHinhTron2.X - pValue.X;
            else iXr = pValue.X - TamPanel.X - 20;
            if (pValue.Y < TamHinhTron2.Y) iYr = TamHinhTron2.Y - pValue.Y;
            else iYr = pValue.Y - TamHinhTron2.Y;
            iRr = (double)Math.Sqrt(iXr * iXr + iYr * iYr);
            double iCorner2r = (double)(Math.Asin(iXr / iRr) * (180 / Math.PI));
            if (pValue.X >= TamHinhTron2.X && pValue.Y >= TamHinhTron2.Y)
            {
                iCorner2r = (90 - iCorner2r) + 90;
            }
            if (pValue.X < TamHinhTron2.X && pValue.Y >= TamHinhTron2.Y)
            {
                iCorner2r += 180;
            }
            if (pValue.X < TamHinhTron2.X && pValue.Y < TamHinhTron2.Y)
            {
                iCorner2r = (90 - iCorner2r) + 271;
            }

            return (int)iCorner2r;
        }

        private void ChonTrangThai()
        {
            if (iR <= 250)
            {
                lbDoCung.Text = iRow(new Point(ToaDoChuotHienTai.X, ToaDoChuotHienTai.Y)).ToString();
                lbBanKinh.Text = ((int)iR * 10 / 21).ToString();
            }
            if (bTH1)   // nếu được ấn thì chuyển sang trạng thái 
            {
                TrangThaiMot();
            }
            else TrangThaiBinhThuong();
        }


        private void TrangThaiBinhThuong()
        {
            VeCacVongTron();
            VeVongTronCoTheThayDoi();
            VeDuongLineCoTheThayDoi(TamHinhTron);
            if (NGUON == true)
            {
                // Đường quét
                for (int i = 0; i < 4; i++)
                {
                    g.DrawLine(p, TamHinhTron, getPointDrawLine(u + i, TamHinhTron, hand));
                }
            }
            if (bTH2)
            {
                TrangThaiDacBiet();
            }
        }

        private void TrangThaiMot()
        {
            if (bClickMouse)
            {
                VeDauCong(ToaDoChuotKhiAnButton);
                VeDuongLineCoTheThayDoi(ToaDoChuotKhiAnButton);
                VeVongTronCoTheThayDoiTH1(ToaDoChuotKhiAnButton);
            }
            if (bTH2)
            {
                TrangThaiDacBiet();
            }
        }

        private void TrangThaiDacBiet()
        {
            if (bClickMouse)
            {
                VeDauCong(ToaDoChuotKhiAnButton);
                g.DrawLine(new Pen(Color.White, 2f), ToaDoChuotKhiAnButton, getPointDrawLine(iDrawLineDacBietTangGiam, ToaDoChuotKhiAnButton, iDrawLineDacBiet));
            }
        }
        #endregion




        // button di
        private void ButtonMove()
        {
            if (NGUON == true)
            {
                pnlMoverFirst.Visible = true;
                pnlMoverFirst.Location = new Point(iMoverButton, 300);
              
                DICHUYEN1.Location = new Point(iMoverButton, 300);

                pnlMoverSecond.Visible = true;
                pnlMoverSecond.Location = new Point(400, iMoverButton - 350);
     
                DICHUYEN2.Location = new Point(400, iMoverButton - 350);

                dichuyen33.Visible = true;
               
                dichuyen33.Location = new Point(iMoverButton + 100,350);
          
                DICHUYEN3.Location = new Point(iMoverButton + 100,350);

                    
                    TH11.Location = new Point(iMoverButton + 50, 400);
                    iMoverButton++;
                    if (iMoverButton >= 500)
                    {
                        iMoverButton = 400;
                    }
                }
            }

        
        #region Events

        private void button3_Click(object sender, EventArgs e)
        { if (NGUON == true)
            bEBL1 = !bEBL1;
        }

        private void EBL2_Click(object sender, EventArgs e)
        {
            bEBL2 = !bEBL2;
        }

        private void GIAM_Click(object sender, EventArgs e)
        {

            if (bEBL1 == true && bEBL2 == false)
            {
                iDrawEllipse += 2;
                n--;
                number = n + 230;
                SO1.Text = number.ToString();

            }
            else
            {
                iDrawEllipse2 += 2;
                n2--;
                number2 = n2 + 230;
                SO2.Text = number2.ToString();
           
            }
        }

        private void TANG_Click(object sender, EventArgs e)
        {
            if (bEBL1 == true && bEBL2 == false)
            {
                iDrawEllipse -= 2;
                n++;
                number = n + 230;
                SO1.Text = number.ToString();
            }
            else
            {
                iDrawEllipse2 -= 2;
                n2++;
                number2 = n2 + 230;
                SO2.Text = number2.ToString();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            bEBL3 = !bEBL3;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bEBL4 = !bEBL4;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (bEBL3 == true && bEBL4 == false)
            {
                iDrawLine1 -= 1;
            }
            else
            {
                iDrawLine2 -= 1;
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (bEBL3 == true && bEBL4 == false)
            {
                iDrawLine1 += 1;
            }
            else
            {
                iDrawLine2 += 1;
            }
        }
    
        private void button11_Click(object sender, EventArgs e)
        {
            NGUON = !NGUON;
              if (NGUON == true)
            {
                pnlMoverFirst.Visible = true;
                pnlMoverSecond.Visible = true;
                   
                       PICBOX1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\7.pNg"); 
             
            }
            else
            {
                dichuyen33.Visible = false;
                 pnlMoverFirst.Visible = false;
                pnlMoverSecond.Visible = false;
              
               
             
                PICBOX1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\110.pNg"); 
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NGUON = !NGUON;
            if (NGUON == true)
            {
                pnlMoverFirst.Visible = true;
                pnlMoverSecond.Visible = true;
              
                        

             
            }
            else
            {
                dichuyen33.Visible = false;
                pnlMoverFirst.Visible = false;
                pnlMoverSecond.Visible = false;
              
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (bEBL3 == true && bEBL4 == false)
            {
                iDrawLine1 -= 1;
            }
            else
            {
                iDrawLine2 -= 1;
            }
            if ( bTH2)
                iDrawLineDacBietTangGiam--;
        }
        private int a1=40;
        private void button18_Click(object sender, EventArgs e)
        {
            if (bEBL3 == true && bEBL4 == false)
            {
                iDrawLine1 += 1;
            }
            else
            {
                iDrawLine2 += 1;
            }
            if (bTH2)
            {
                a1++;
                iDrawLineDacBietTangGiam++;
                lbebl2.Text = "" + a1;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (bEBL1 == true && bEBL2 == false)
            {
                iDrawEllipse += 2;
                n--;
                number = n + 230;
                SO1.Text = number.ToString();

            }
            else
            {
                iDrawEllipse2 += 2;
                n2--;
                number2 = n2 + 230;
                SO2.Text = number2.ToString();

            }
            if (bTH2 )
                iDrawLineDacBiet -= 10;
        }
        private void button19_Click(object sender, EventArgs e)
        {
            if (bEBL1 == true && bEBL2 == false)
            {
                iDrawEllipse -= 2;
                n++;
                number = n + 230;
                SO1.Text = number.ToString();
            }
            else
            {
                iDrawEllipse2 -= 2;
                n2++;
                number2 = n2 + 230;
                SO2.Text = number2.ToString();
            }
            if (bTH2)
                iDrawLineDacBiet += 10;

        }
        #endregion
        // HIEN N VA E
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
          
            ToaDoChuotHienTai = e.Location;
            lbTest.Text = ToaDoChuotHienTai.ToString();
            if (iR > 0)
            {
                a = (int)iR / 4;
                b = (int)iR / 6;


            }
            if (CheckDrawEllipse(e.Location))
            {
                PICBOX1.Cursor = Cursors.Cross;
            }
            else
            {
                PICBOX1.Cursor = Cursors.Default;
            }

                                }
        //TANG RANGE
        private int h1=0;
        private void button20_Click(object sender, EventArgs e)
        {
            
                h1++;
             
                if (h1 == 18) h1 = 17;

        }
        //GIAM RANGE
        private void button21_Click(object sender, EventArgs e)
        {
           
                h1--;
                if (h1 == 0) h1 = 1;
               
        }
       
        //F4
        private void PF44_Click(object sender, EventArgs e)
        {
            HLF = !HLF;
        }
        //HLF OFFSET
        private void button22_Click(object sender, EventArgs e)
        {
            HLF = !HLF;
        }
        //HLF OFFSET
        private void button28_Click(object sender, EventArgs e)
        {
            HLF = !HLF;
        }
        // MUC TIEU PANEL DI CHUYEN

        private void pnlMoverFirst_Click(object sender, EventArgs e)
        {
            
           
            DICHUYEN1.Visible = true;
            pnlMoverFirst.Visible = false;
        }
        private void DICHUYEN1_Click(object sender, EventArgs e)
        {
            
               pnlMoverFirst.Visible = true;
               DICHUYEN1.Visible = false;
              
        }

        private void pnlMoverSecond_Click(object sender, EventArgs e)
        {
            
                DICHUYEN2.Visible = true;
                pnlMoverSecond.Visible = false;
              
        }
           private void DICHUYEN2_Click(object sender, EventArgs e)
        {
            pnlMoverSecond.Visible = true;
            DICHUYEN2.Visible = false;
           
           
        }

       
            private void DICHUYEN3_Click(object sender, EventArgs e)
        {
           
            dichuyen33.Visible = true;
            DICHUYEN3.Visible = false;
        }
         private void dichuyen33_click(object sender, EventArgs e)
            {
                
           DICHUYEN3.Visible = true;
           dichuyen33.Visible = false;
        }
         
        
        //BRILL
        private int iSetContr = 100;
        private void button31_Click(object sender, EventArgs e)
        {
            if (iSetContr <= 224)
                iSetContr += 5;
            if (MAUBRILL.Value >0)
                MAUBRILL.Value--;
            MAUBRIL1.Text = MAUBRILL.Value + "";
        }

        private void BR2_Click(object sender, EventArgs e)
        {
            if (iSetContr > 10)
                iSetContr -= 5;
            if (MAUBRILL.Value <= 100)
                MAUBRILL.Value++;
            MAUBRIL1.Text = MAUBRILL.Value + "";
        }


        // DK GAIN
      


        //DK SEA
        private int s1 = 0;
        private void SEA_Click(object sender, EventArgs e)
        {
            s1++;
            if (s1 == 1)
            {
                lBSEA.Text = "AUTO"; MAU2.Value = 57;
                MAU12.Text = MAU2.Value + "";
            }
            if (s1 == 2) { lBSEA.Text = "MAN"; s1 = 0; }
          
           
        }

        private void GIAMSEA_Click(object sender, EventArgs e)
        {
            if (MAU2.Value > 0 )
                MAU2.Value--;
            MAU12.Text = MAU2.Value + "";
        }

        private void TAGSEA_Click(object sender, EventArgs e)
        {
            if (MAU2.Value <= 100 )
                MAU2.Value++;
            MAU12.Text = MAU2.Value + "";
        }

        //DK RAIN 
        private int R = 0;
        

        private void TAGRAIN_Click(object sender, EventArgs e)
        {
            if (R <=100) R--;
            if (R > 55) PICBOX1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\7.pNg");
            
        }



        //trạng thái vòng tròn xoay quanh con tro
        bool bTH1 = false;
        private void btnTH1_Click(object sender, EventArgs e)
        {
            bTH1 = !bTH1;
        }

        //trang thai thay doi kich thuoc duong line
        bool bTH2 = false;
        private void btnTH2_Click(object sender, EventArgs e)
        {
            bTH2 = !bTH2;
        }

        private bool bClickMouse = false;
        private bool bVVBDToaDo1 = true;
        private bool ClickXong = false;
        private void PICBOX1_Click(object sender, EventArgs e)
        {
            if (bTH1 || bTH2)
            {
                ToaDoChuotKhiAnButton.X = ToaDoChuotHienTai.X - 23;
                ToaDoChuotKhiAnButton.Y = ToaDoChuotHienTai.Y - 15;
                bClickMouse = true;
            }
            if (bVeVungBaoDong && ChoPhepVe)
            {
                if (bVVBDToaDo1)
                {
                    ToaDoChuotVeVungBaoDong1.X = ToaDoChuotHienTai.X - 23;
                    ToaDoChuotVeVungBaoDong1.Y = ToaDoChuotHienTai.Y - 15;
                    bVVBDToaDo1 = false;
                }
                else
                {
                    ToaDoChuotVeVungBaoDong2.X = ToaDoChuotHienTai.X - 23;
                    ToaDoChuotVeVungBaoDong2.Y = ToaDoChuotHienTai.Y - 15;
                    bVVBDToaDo1 = true;
                    ClickXong = true;
                    ChoPhepVe = false;
                }
            }
        }

      

        private int iDrawLineDacBiet = 20;
        private void btnGiam_Click(object sender, EventArgs e)
        {
            iDrawLineDacBiet -=10;
        }
        private void btnTang_Click(object sender, EventArgs e)
        {
            iDrawLineDacBiet +=10;
        }
        private int iDrawLineDacBietTangGiam = 20;
        private void btnTien_Click(object sender, EventArgs e)
        {
            iDrawLineDacBietTangGiam++;
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            iDrawLineDacBietTangGiam--;
        }


        // menu
     

        private void button36_Click(object sender, EventArgs e)
        {
            
        }
      
        private bool bVeVungBaoDong = false;
        private bool ChoPhepVe = false;
        private void btnVeVungBaoDong_Click(object sender, EventArgs e)
        {
            bVeVungBaoDong = !bVeVungBaoDong;
            ChoPhepVe = true;
        }
        //MANHINHRADAR
        private int h2 = 0;
      
     
        
      
        

      
         private int s2=0;
        private void TUNE_Click(object sender, EventArgs e)
        {
            
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (MAU4.Value > 0)
                MAU4.Value--;
            MAU14.Text = MAU4.Value + "";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (MAU4.Value <= 100)
                MAU4.Value++;
            MAU14.Text = MAU4.Value + "";
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {

        }

        private int z1 = 0;
        private void button41_Click_1(object sender, EventArgs e)

        {
            z1++; if (z1 == 1)
            {
                if (DICHUYEN1.Visible == true)
                {
                    DICHUYEN1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\HUONG1.pNg");
                }

                if (DICHUYEN2.Visible == true)
                {
                    DICHUYEN2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\BEN1212.pNg");
                }

                if (DICHUYEN3.Visible == true)
                {

                    DICHUYEN3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\BEN123.pNg");
                }
            } if (z1 == 1) z1 = 0;
        }

       
        private int Th1 = 0;
        private void TH1_Click(object sender, EventArgs e)
        {
            Th1++;
            if (R > 55) Th1 = 2;
            if (Th1 == 1)
            {
                PICBOX1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\MUA.pNg");
                
            }
            if (Th1 == 2)
            {
                PICBOX1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\7.pNg");
               Th1 = 0;
            }
        }

        private void button60_Click(object sender, EventArgs e)
        {
            dichuyen33.Visible = false;
        }

        private int al = 0;
        private void button53_Click(object sender, EventArgs e)
        {
            al++;
            if(al==1)
            PICBOX1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\al1.pNg");
            if (al == 2) { PICBOX1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\7.pNg"); al = 0; }
        }

      
      

       
        
       
        

       
        
    }
   

}








