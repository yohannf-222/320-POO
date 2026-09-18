using Drones.Helpers;
using Drones.Properties;

namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Drone
    {
        private int _charge;                    // La charge actuelle de la batterie
        private string _name;                   // Un nom
        private double _x;                         // Position en X depuis la gauche de l'espace aérien
        private double _y;                         // Position en Y depuis le haut de l'espace aérien
        private double _targetX = RndValueHelpers.alea.Next(Config.AIRSPACE_WIDTH);            // Detination en X depuis la gauche de l'espace aérien
        private double _targetY = RndValueHelpers.alea.Next(Config.AIRSPACE_HEIGHT);           // Detination en Y depuis le haut de l'espace aérien

        // Constructeur
        public Drone(int x, int y, string name)
        {
            this._x = x;
            this._y = y;
            this._name = name;
            this._charge = RndValueHelpers.alea.Next(Config.MAX_LOAD); // La charge initiale de la batterie est choisie aléatoirement
        }

        #region ================ Modelisation du drone et de son comportement ================

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            if (_charge <= 0) return;                                 // S'il n'a plus de charge, il ne peut plus bouger                        
            
            if (MathHelpers.CalculateDistance(_x, _y, _targetX, _targetY) <= Config.SPEED * interval / 1000)           // L'objectif est atteint (ou tout proche)
            {
                _x = _targetX;
                _y = _targetY;
                _targetX = RndValueHelpers.alea.Next(Config.AIRSPACE_WIDTH);
                _targetY = RndValueHelpers.alea.Next(Config.AIRSPACE_HEIGHT);
                return;                                             // Le drone s'immobilise
            }

            double deltaX = _targetX - _x;
            double deltaY = _targetY - _y;            
            double distance = MathHelpers.CalculateDistance(_x, _y, _targetX, _targetY);
            double step = (double)Config.SPEED * interval / 1000;   // Distance parcourue pendant l'intervalle,vitesse constante
            _x += Convert.ToInt32(deltaX / distance * step);
            _y += Convert.ToInt32(deltaY / distance * step);

            _charge--;                                              // Il a dépensé de l'énergie
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
            drawingSpace.Graphics.DrawImage(_charge > 0 ? Resources.drone : Resources.boom, Convert.ToSingle(_x) - Drone.SIZE / 2, Convert.ToSingle(_y) - Drone.SIZE / 2, Drone.SIZE, Drone.SIZE);
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, Convert.ToSingle(_x + 5), Convert.ToSingle(_y - 25));
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{_name} ({((int)((double)_charge / 1000 * 100)).ToString()}%)";
        }
        #endregion

    }
}
