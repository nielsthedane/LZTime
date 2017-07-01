using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using LZTime.Var;
using static LZTime.Struct.Entitys.LocalPlayer;
using static LZTime.Var.IncrossVar;


namespace LZTime.Threads
{
				public class Triggerbot
				{
								[DllImport("user32.dll")]
								public static extern short GetAsyncKeyState(int vKey);

								private MMC.MMCManage Memory;
								private Random Random;

								public Triggerbot()
								{
												Memory = MMC.MMCManage.Instance;
												Random = new Random();
								}

								public void Shot()
								{
												Console.WriteLine("Trigger Running!");
												while (true)
												{
																if (GetAsyncKeyState(0x05) != 0)
																{
																				var watch = System.Diagnostics.Stopwatch.StartNew();
																				if (playerInCross > 0 && playerInCross <= 64)
																				{
																								if (enemyHealth > 0 && playerTeam != enemyTeam)
																								{
																												Console.WriteLine("SHOOTING!");
																												Thread.Sleep(120 + Random.Next(1, 40));
																												Memory.WriteMemory<IntPtr>(Offsets.m_ClientPointer + Offsets.m_dwForceAttack, 1);
																												Thread.Sleep(1);
																												Memory.WriteMemory<IntPtr>(Offsets.m_ClientPointer + Offsets.m_dwForceAttack, 4);
																												watch.Stop();
																												Console.WriteLine("It took: " + watch.Elapsed + " to read and shoot!");
																								}

																				}
																}
																Thread.Sleep(5);
												}
								}
				}
}