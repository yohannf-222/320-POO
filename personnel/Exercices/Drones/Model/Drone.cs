using Drones.Helpers;
using Drones.Properties;

namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Drone
    {
        private int _charge;                    // La charge actuelle de la batterie
        private string _name;                   // Un nom
        private int _x;                         // Position en X depuis la gauche de l'espace aérien
        private int _y;                         // Position en Y depuis le haut de l'espace aérien
        private int _destinationX;              // Detination en X depuis la gauche de l'espace aérien
        private int _destinationY;              // Detination en Y depuis le haut de l'espace aérien

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
            if (_charge <= 0) return;                     // S'il n'a plus de charge, il ne peut plus bouger            
            _x += 2;                                    // Il s'est déplacé de 2 pixels vers la droite
            _y += RndValueHelpers.alea.Next(-2, 3);                     // Il s'est déplacé d'une valeur aléatoire vers le haut ou le bas
            _charge--;                                  // Il a dépensé de l'énergie
        }

        #endregion

        #region  ================ Rendu graphique  ================

        private const int SIZE = 50;
        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(_charge > 0 ? Resources.drone : Resources.boom, _x - Drone.SIZE / 2, _y - Drone.SIZE / 2, Drone.SIZE, Drone.SIZE);
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x + 5, _y - 25);
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{_name} ({((int)((double)_charge / 1000 * 100)).ToString()}%)";
        }
        #endregion

    }
}
