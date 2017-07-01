using System;
using System.Threading;
using LZTime.Var;
using static LZTime.Struct.Entitys.LocalPlayer;
using static LZTime.Var.IncrossVar;

namespace LZTime.Threads
{
				public class IncrossReader
				{
								private MMC.MMCManage Memory;

								public IncrossReader()
								{
												Memory = MMC.MMCManage.Instance;
								}

								public void ReadCrosshair()
								{
												Console.WriteLine("Reading Crosshair!");

												while (true)
												{
																localPlayer = Memory.ReadMemory<int>(Offsets.m_ClientPointer + Offsets.m_dwLocalPlayer);
																playerInCross = Memory.ReadMemory<int>(localPlayer + Offsets.m_iCrosshairId);
																if (playerInCross > 0 && playerInCross <= 64)
																{
																				Enemy = Memory.ReadMemory<int>(Offsets.m_ClientPointer + Offsets.m_dwEntityList + ((playerInCross - 1) * 0x10));
																				playerTeam = Memory.ReadMemory<int>(localPlayer + Offsets.m_iTeamNum);
																				enemyTeam = Memory.ReadMemory<int>(Enemy + Offsets.m_iTeamNum);
																				enemyHealth = Memory.ReadMemory<int>(Enemy + Offsets.m_iHealth);
																				Console.WriteLine("Player in cross " + playerInCross + " Enemy Helth: " + enemyHealth + " Playerteam: " + playerTeam + " Enemyteam: " + enemyTeam);
																				Thread.Sleep(10);
																}
												}


								}


				}
}