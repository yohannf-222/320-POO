using Drones.Helpers;
using Drones.Model;
using Drones.Properties;

namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Drone
    {
        private int _charge;                        // La charge actuelle de la batterie
        private string _name;                       // Un nom
        private double _x;                          // Position en X depuis la gauche de l'espace aérien
        private double _y;                          // Position en Y depuis le haut de l'espace aérien
        private double _targetX = RndValueHelpers.alea.Next(Config.AIRSPACE_WIDTH);            // Detination en X depuis la gauche de l'espace aérien
        private double _targetY = RndValueHelpers.alea.Next(Config.AIRSPACE_HEIGHT);           // Detination en Y depuis le haut de l'espace aérien
        private State _state;

        public enum State { CRASH, LOW_BATTERY, LOADING, ROAMING };


        public int Charge
        {
            get => _charge;
            set
            {
                if (value > Config.MAX_LOAD)
                    _charge = Config.MAX_LOAD;
                else
                    _charge = value;

            }
        }

        // Constructeur
        public Drone(int x, int y, string name)
        {
            this._x = x;
            this._y = y;
            this._name = name;
            this.Charge = RndValueHelpers.alea.Next(Config.MAX_LOAD); // La charge initiale de la batterie est choisie aléatoirement
            this._state = State.ROAMING;
        }

        #region ================ Modelisation du drone et de son comportement ================

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval, Charger charger)
        {
            if (Charge <= 0) return;  // S'il n'a plus de charge, il ne peut plus bouger                        

            if (_state == State.LOADING)
            {
                if (Charge < Config.MAX_LOAD)
                {
                    if (Charge >= Config.MAX_LOAD - 10)
                        Charge = Config.MAX_LOAD;

                    Charge += 10;
                }
                else
                    _state = State.ROAMING;

            }


            // Si la charge est trop basse, se rend vers la borne de chargement.
            if (Charge <= Config.LOW_BATTERY_LIMIT)
            {
                _state = State.LOW_BATTERY;

                _targetX = charger.X;
                _targetY = charger.Y;
            }

            // L'objectif est atteint (ou tout proche)
            if (MathHelpers.CalculateDistance(_x, _y, _targetX, _targetY) <= Config.SPEED * interval / 1000)
            {
                if (_state == State.ROAMING)
                {
                    _x = _targetX;
                    _y = _targetY;

                    _targetX = RndValueHelpers.alea.Next(Config.AIRSPACE_WIDTH);
                    _targetY = RndValueHelpers.alea.Next(Config.AIRSPACE_HEIGHT);
                }
                else if (_state == State.LOW_BATTERY)
                {

                    _x = charger.X;
                    _y = charger.Y;

                    _state = State.LOADING;
                }

                return;  // Le drone s'immobilise
            }

            double deltaX = _targetX - _x;
            double deltaY = _targetY - _y;
            double distance = MathHelpers.CalculateDistance(_x, _y, _targetX, _targetY);
            double step = (double)Config.SPEED * interval / 1000;   // Distance parcourue pendant l'intervalle,vitesse constante
            _x += Convert.ToInt32(deltaX / distance * step);
            _y += Convert.ToInt32(deltaY / distance * step);

            // Il a dépensé de l'énergie
            Charge--;

        }

        /// <summary>
        /// Crée une liste de drone de longueur nb, jusqu'à 8
        /// </summary>
        /// <param name="nb"> le nombre de drones dans la liste</param>
        /// <returns></returns>
        public static List<Drone> GenerateFleet(int nb)
        {
            if (nb > 8) nb = 8;

            List<Drone> fleet = new List<Drone>();
            string[] names = { "Joe",
                 "Peter",
                 "Cleveland",
                 "Lois",
                 "Meg",
                 "Quagmire",
                 "Chris",
                 "Stewie" };                    //noms possibles

            for (int i = 0; i < nb; i++)
            {
                fleet.Add(new Drone(RndValueHelpers.alea.Next(Config.AIRSPACE_WIDTH), RndValueHelpers.alea.Next(Config.AIRSPACE_HEIGHT), names[RndValueHelpers.alea.Next(names.Length)]));
            }
            return fleet;
        }

        void CheckTarget()
        {

        }
        #endregion

        #region  ================ Rendu graphique  ================

        private const int SIZE = 50;
        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Charge > 0 ? Resources.drone : Resources.boom, Convert.ToSingle(_x) - Drone.SIZE / 2, Convert.ToSingle(_y) - Drone.SIZE / 2, Drone.SIZE, Drone.SIZE);
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, Convert.ToSingle(_x + 5), Convert.ToSingle(_y - 25));
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{_name} ({((int)((double)Charge / 1000 * 100)).ToString()}%)";
        }
        #endregion

    }
}
