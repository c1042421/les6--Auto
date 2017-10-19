using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefAuto
{
    class Auto
    {
        private double _litersInTank;
        private int _snelheid;

        public delegate void AutoHandler(Auto sender);

        public event AutoHandler AutoGestartEvent;
        public event AutoHandler AutoGestoptEvent;
        public event AutoHandler TankBijnaOpEvent;
        public event AutoHandler TankChangeEvent;
        public event AutoHandler TankOpEvent;

        public Auto(double litersInTank)
        {
            LitersInTank = litersInTank;
            Snelheid = 0;
        }

        public double LitersInTank {
            get { return _litersInTank; }
            set
            {
                _litersInTank = value;

                TankChangeEvent?.Invoke(this);

                if (value < 10 && value != 0)
                {
                    TankBijnaOpEvent?.Invoke(this);
                }
                else if (value == 0)
                {
                    TankOpEvent?.Invoke(this);
                    Snelheid = 0;
                }
            }
        }

        public int Snelheid
        {
            get { return _snelheid; }
            set
            {
                _snelheid = value;

                (value > 0 ? AutoGestartEvent : AutoGestoptEvent)?.Invoke(sender: this);
            }
        }

        public override string ToString()
        {
            return string.Format("Snelheid: {0}\nLitersInTank: {1}", Snelheid, LitersInTank);
        }
    }
}
