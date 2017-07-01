using System;
using System.Threading;
using LZTime.Struct;
using LZTime.Threads;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms;
using LZTime.Var;
using static LZTime.MMC;
using static LZTime.Struct.Entitys;
using static LZTime.Struct.Entitys.Entity;


namespace LZTime
{
				class Program
				{
								private static MMC.MMCManage Memory;

								static void Main(string[] args)
								{
												PrepareMemory();
												StartThreads();
								}


								private static void PrepareMemory()
								{
												Memory = MMCManage.Instance;
												Memory.Initialize("csgo");
												//Finds Client.dll addres and saves it in the variable
												Offsets.m_ClientPointer = Memory.GetModuleAdress("client.dll");
												for (var i = 0; i < 64; i++)
												{
																Arrays.Entity[i] = new Entitys.Entity();
												}
								}

								private static void StartThreads()
								{ 
												GameUpdater GameUpdater = new GameUpdater();
												Thread Updater = new Thread(GameUpdater.Read);
												Updater.Start();

												Triggerbot Triggerbot = new Triggerbot();
												Thread Trigger = new Thread(Triggerbot.Shot);
												Trigger.Start();

												IncrossReader incrossReader = new IncrossReader();
												Thread Reader = new Thread(incrossReader.ReadCrosshair);
												Reader.Start();


								}

				}
}
