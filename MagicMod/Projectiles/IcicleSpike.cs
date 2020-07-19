using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.Projectiles
{
    class IcicleSpike : ModProjectile
    {
		int timeToFall = 30;
		int particleTime = 20;

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			drawOriginOffsetY = -8;
			drawOriginOffsetX = -2;

			projectile.friendly = true;
			projectile.magic = true;

			projectile.penetrate = 3;
			projectile.timeLeft = 600;

			projectile.light = 0.8f;

			projectile.ignoreWater = false;
			projectile.tileCollide = true;

			projectile.aiStyle = 1;

			projectile.coldDamage = true;
		}

		public override void AI()
        {
			timeToFall--;
			if (timeToFall <= 0)
            {
				if (projectile.velocity.Y <= 8)
                {
					projectile.velocity.Y += 0.1f;
				}
				else
                {
					projectile.velocity.Y = 8;
				}
            }
            else
            {
				projectile.velocity.Y = 0.1f;
            }

			if (projectile.velocity != Vector2.Zero)
			{
				projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			}

			particleTime--;
			if (particleTime <= 0)
			{
				Main.PlaySound(SoundID.Item27, base.projectile.position);
				int num459 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 197);
				Main.dust[num459].noGravity = true;

				particleTime = 20;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();

			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.damage = 2;

			target.AddBuff(BuffID.Slow, 120);

			projectile.penetrate--;

			if (projectile.penetrate <= 0)
            {
				projectile.Kill();
            }
		}

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);

			projectile.damage *= (int)projectile.velocity.Y;
			projectile.damage /= 8;
			damage = projectile.damage;
		}

        public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 10; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Ice, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}

			Main.PlaySound(SoundID.Item27, projectile.position);
		}





		//public void IcicleSpawn()
		//      {
		//	int num342 = 2;
		//	Vector2 vector = new Vector2(0, 0);
		//	float num311;
		//	float num312;

		//	for (int num3 = 0; num3 < num342; num3++)
		//	{
		//		vector = new Vector2(base.projectile.position.X + (float)projectile.width * 0.5f + (float)(Main.rand.Next(201) * -projectile.direction) + ((float)Main.mouseX + Main.screenPosition.X - base.projectile.position.X), MountedCenter.Y - 600f);
		//		vector.X = (vector.X + base.projectile.Center.X) / 2f + (float)Main.rand.Next(-200, 201);
		//		vector.Y -= 100 * num3;
		//		num311 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
		//		num312 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
		//		if (num312 < 0f)
		//		{
		//			num312 *= -1f;
		//		}
		//		if (num312 < 20f)
		//		{
		//			num312 = 20f;
		//		}
		//		float num313;
		//		num313 = (float)Math.Sqrt(num311 * num311 + num312 * num312);
		//		num313 = speed / num313;
		//		num311 *= num313;
		//		num312 *= num313;
		//		float speedX4 = num311 + (float)Main.rand.Next(-40, 41) * 0.02f;
		//		float speedY5 = num312 + (float)Main.rand.Next(-40, 41) * 0.02f;
		//		Projectile.NewProjectile(vector.X, vector.Y, speedX4, speedY5, shoot, Damage, KnockBack, i, 0f, Main.rand.Next(5));
		//	}
		//}
	}
}
