using Drones.Helpers;
using Drones.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Model
{
    public class Client
    {
        private int _x;
        private int _y;
        private string _name;

        public Client(int x, int y, string name)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
        }


        public int X
        {
            get => _x;
            set
            {
                if (value >= Config.AIRSPACE_WIDTH - Config.CLIENT_SIDE_LENGTH / 2)
                    _x = Config.AIRSPACE_WIDTH - Config.CLIENT_SIDE_LENGTH / 2;
                else if (value <= Config.CLIENT_SIDE_LENGTH / 2)
                    _x = Config.CLIENT_SIDE_LENGTH / 2;
                else
                    _x = value;
            }
        }
        public int Y
        {
            get => _y;
            set
            {
                if (value >= Config.AIRSPACE_HEIGHT - Config.CLIENT_SIDE_LENGTH / 2)
                    _y = Config.AIRSPACE_HEIGHT - Config.CLIENT_SIDE_LENGTH / 2;
                else if (value <= Config.CLIENT_SIDE_LENGTH / 2)
                    _y = Config.CLIENT_SIDE_LENGTH / 2;
                else
                    _y = value;
            }
        }
        public string Name { get => _name; set => _name = value; }


        /// <summary>
        /// Crée une liste de drone de longueur nb, jusqu'à 8
        /// </summary>
        /// <param name="nb"> le nombre de drones dans la liste</param>
        /// <returns></returns>
        public static List<Client> GenerateClients(int nb)
        {
            if (nb > 50) nb = 50;

            List<Client> clients = new List<Client>();

            for (int i = 0; i < nb; i++)
            {
                clients.Add(new Client(RndValueHelpers.alea.Next(Config.CLIENT_SIDE_LENGTH / 2, Config.AIRSPACE_WIDTH - Config.CLIENT_SIDE_LENGTH / 2), RndValueHelpers.alea.Next(Config.CLIENT_SIDE_LENGTH / 2, Config.AIRSPACE_HEIGHT - Config.CLIENT_SIDE_LENGTH / 2), $"Client{i + 1}"));
            }
            return clients;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.Pizzeria, Convert.ToSingle(X) - Config.CLIENT_SIDE_LENGTH / 2, Convert.ToSingle(Y) - Config.CLIENT_SIDE_LENGTH / 2, Config.CLIENT_SIDE_LENGTH, Config.CLIENT_SIDE_LENGTH);
            drawingSpace.Graphics.DrawString($"{this.Name}", TextHelpers.drawFont, TextHelpers.writingBrush, Convert.ToSingle(_x + 5), Convert.ToSingle(_y - Config.CLIENT_SIDE_LENGTH / 2));
        }

    }
}
