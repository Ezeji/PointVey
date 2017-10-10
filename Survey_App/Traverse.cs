using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey_App
{
    class Traverse
    {

        public double ddeg;
        public double deg1 = 0;
        public double min1 = 0;
        public double sec1 = 0;



        public double Convert_Angles(int degrees, int minutes, double seconds)
        {


            //Code for collecting observed angles from user
            deg1 = deg1 + degrees;

            min1 = min1 + minutes;

            sec1 = sec1 + seconds;


            //Conversion from degminsec to decimal degrees
            ddeg = deg1 + min1 / 60 + sec1 / 3600;

            return ddeg;
        }

        public double DN_Control;
        public double DE_Control;
        public double D_Control;
        public double QD_Fwd_Brg;
        public double QD_Fwd_Brg_View;
        public double sign1;
        public double sign2;
        public double sign_DN;
        public double WCB_Fwd_Brg;
        public double WCB_Bck_Brg;


        public double Final_WCB_Bck_Brg(double N_Stn1, double E_Stn1, double N_Stn2 , double E_Stn2 )
        {
            //Code to determine the quadrantal forward bearing

            DN_Control = N_Stn2 - N_Stn1;
            DE_Control = E_Stn2 - E_Stn1;
            D_Control = (DE_Control / DN_Control);
            QD_Fwd_Brg = Math.Atan(D_Control);
            QD_Fwd_Brg_View = QD_Fwd_Brg * (180 / Math.PI);

            //Code to extract the coefficient sign from the quadrantal forward bearing which will aid in locating the quadrant a line falls into
            sign1 = Math.Sign(QD_Fwd_Brg_View);
            sign2 = Math.Sign(QD_Fwd_Brg_View);
            sign_DN = Math.Sign(DN_Control);

            //Code for locating the quadrant a line falls and further determine the whole circle bearing
            if (sign1 == -1 && sign_DN == -1)
            {
                WCB_Fwd_Brg = QD_Fwd_Brg_View + 180;
                WCB_Bck_Brg = WCB_Fwd_Brg + 180;

            }

            else if (sign1 == -1 && sign_DN == 1)
            {
                WCB_Fwd_Brg = QD_Fwd_Brg_View + 360;
                WCB_Bck_Brg = WCB_Fwd_Brg + 180;


                if (WCB_Bck_Brg > 360)
                {
                    WCB_Bck_Brg = WCB_Bck_Brg - 360;


                }


            }

            else if (sign2 == 1 && sign_DN == -1)
            {
                WCB_Fwd_Brg = QD_Fwd_Brg_View + 180;
                WCB_Bck_Brg = WCB_Fwd_Brg + 180;


            }

            else if (sign2 == 1 && sign_DN == 1)
            {
                WCB_Fwd_Brg = QD_Fwd_Brg_View;
                WCB_Bck_Brg = WCB_Fwd_Brg + 180;


            }

            return WCB_Bck_Brg;
        }
    }
}
