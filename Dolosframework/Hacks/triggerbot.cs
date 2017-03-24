using Colorful;
using Dolosframework.CrosshairManager;
using Dolosframework.EntityManager;
using Dolosframework.Math;
using System.Linq;
using System.Threading;

namespace Dolosframework.Hacks
{
    public class TriggerBot : Module
    {
        public static void Activated()
        {
            var isDown = (Vector3.GetKeyState(0x06) & 0xFF00) != 0;
            if (!isDown) return;

            foreach (var crosshair in Framework.Crosshair.Crosshair)
            {
                if (crosshair.Team == 0) continue;

                foreach (var player in Framework.LocalPlayer.Localplayer)
                {
                    if (crosshair.Team == player.Team) continue;

                    BaseEntity.SetAttack(1);
                    Thread.Sleep(50);
                    BaseEntity.SetAttack(0);
                }
            }
        }
    }
}